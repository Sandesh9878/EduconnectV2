using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System.Reflection;
using Version = Lucene.Net.Util.Version;
namespace Educonnect.Course.Service.SearchEngine
{
    public class LuceneSearch<T> where T : class, new()
    {
        private static readonly DirectoryInfo _luceneDir = new DirectoryInfo("lucene_index");
        private static FSDirectory _directoryTemp;
        private static FSDirectory _directory
        {
            get
            {
                if (_directoryTemp == null) _directoryTemp = FSDirectory.Open(new DirectoryInfo(_luceneDir.FullName));
                if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
                var lockFilePath = Path.Combine(_luceneDir.FullName, "write.lock");
                if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
                //_directoryTemp.ClearLock("write.lock");
                return _directoryTemp;
            }
        }
        public static IEnumerable<T> Search<O>(O obj)
        {
            var reader = IndexReader.Open(_directory, false);
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hits_limit = 1000;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);
                var query = new BooleanQuery();


                var retList = obj.GetType().GetProperties().Where((oType) =>
                {
                    if (!(oType.PropertyType.IsGenericType && (oType.PropertyType.GetGenericTypeDefinition() == typeof(List<>))))
                    {
                        return oType.GetValue(obj) != null;
                    }
                    return false;
                }
            );

                foreach (var item in retList)
                {


                    if (Attribute.GetCustomAttribute(item, typeof(LucenseNotSearchAttribute)) == null)
                    {
                        var objValue = (string)item.GetValue(obj);
                        if (item.Name != "SearchText")
                        {
                            var a = new QueryParser(Version.LUCENE_30, item.Name, analyzer)
                            {
                                AllowLeadingWildcard = true,
                            };

                            //var query1 = a.Parse(parseObj);

                            if (item.Name == "CourseFee")
                            {
                                var splitedRanges = NumericRangeHelper.GetSplitedData(objValue);
                                for (int i = 0; i < splitedRanges.Count(); i++)
                                {
                                    var numericRangeOptions = NumericRangeHelper.GetNumericOptions(splitedRanges[i]);
                                    var q =
                                        NumericRangeQuery.NewDoubleRange(
                                            "CourseFee",
                                            numericRangeOptions.Min,
                                            numericRangeOptions.Max,
                                            true,
                                            true);
                                    query.Add(q, Occur.MUST);
                                }

                            }
                            else
                            {
                                var query1 = a.Parse(objValue);
                                query.Add(query1, Occur.MUST);
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(objValue))
                            {
                                MultiFieldQueryParser queryParser = new MultiFieldQueryParser(Version.LUCENE_30,
                                        new string[] { "CourseName", "InstituteName", "State", "Suburb" },
                                        analyzer);
                                var query2 = queryParser.Parse(objValue);
                                query.Add(query2, Occur.SHOULD);
                            }
                        }
                    }
                }

                if (query.Clauses.Count() == 0)
                {
                    return GetAllIndexRecords();
                }
                var hits = searcher.Search(query, null, hits_limit, Sort.RELEVANCE).ScoreDocs;
                var results = _mapLuceneToDataList(hits, searcher);
                analyzer.Close();
                searcher.Dispose();
                return results;

            }
        }
        public static IEnumerable<T> GetAllIndexRecords()
        {
            Lucene.Net.Store.Directory _directory = FSDirectory.Open(_luceneDir);
            //if (!System.IO.Directory.EnumerateFiles(_lu).Any()) return new List<T>();
            var searcher = new IndexSearcher(_directory, false);
            var reader = IndexReader.Open(_directory, false);
            var docs = new List<Document>();
            var term = reader.TermDocs();
            while (term.Next()) docs.Add(searcher.Doc(term.Doc));
            reader.Dispose();
            searcher.Dispose();
            return _mapLuceneToDataList(docs);
        }
        public static void AddUpdateLuceneIndex(IEnumerable<T> data)
        {
            Optimize((writer) =>
            {
                foreach (var sampleData in data) _addToLuceneIndex(sampleData, writer);
            });
        }
        static void _addToLuceneIndex(T obj, IndexWriter writer)
        {
            var propName = GetKeyPropertyName();
            var pkVal = obj.GetType().GetProperty(propName).GetValue(obj)?.ToString();
            writer.UpdateDocument(new Term(propName, pkVal), CreateDocument(obj));
        }
        static Document CreateDocument(T obj)
        {
            Document doc = new Document();

            var fullText = new List<string>();
            foreach (var prop in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var propName = prop.Name;
                var propVal = prop.GetValue(obj)?.ToString() ?? string.Empty;

                Field.Index index;
                if (Attribute.GetCustomAttribute(prop, typeof(LucenseKeyAttribute)) != null)
                {
                    index = Field.Index.NOT_ANALYZED;
                }
                else
                {
                    if (Attribute.GetCustomAttribute(prop, typeof(LucenseNotSearchAttribute)) != null)
                    {
                        index = Field.Index.NO;
                        doc.Add(new Field(propName, propVal.Trim(), Field.Store.YES, index));
                    }
                    else if (Attribute.GetCustomAttribute(prop, typeof(LucenePriceFieldAttribute)) != null)
                    {
                        if (!string.IsNullOrEmpty(propVal))
                        {
                            doc.Add(new NumericField(propName, Field.Store.YES, true).SetDoubleValue(Convert.ToDouble(propVal.Trim())));
                        }
                        else
                        {
                            doc.Add(new Field(propName, propVal.Trim(), Field.Store.YES, Field.Index.NO));
                        }
                    }
                    else if (Attribute.GetCustomAttribute(prop, typeof(LuceneArrayFieldAttribute)) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(propVal))
                        {
                            var arr = propVal.Trim().Split(',');
                            for (int i = 0; i < arr.Count(); i++)
                            {
                                doc.Add(new Field(propName, arr[i], Field.Store.NO, Field.Index.ANALYZED));
                            }
                        }
                        else
                        {
                            doc.Add(new Field(propName, propVal.Trim(), Field.Store.YES, Field.Index.NO));
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(propVal))
                        {
                            fullText.Add(propVal);
                        }
                        index = Field.Index.ANALYZED;
                        doc.Add(new Field(propName, propVal.Trim(), Field.Store.YES, index));
                    }
                }
            }
            doc.Add(new Field("FullText", String.Join(" ", fullText).Replace(",", " ").Trim(), Field.Store.YES, Field.Index.ANALYZED));
            return doc;
        }
        private static string GetKeyPropertyName()
        {

            var prop = typeof(T).GetProperties().FirstOrDefault(x => Attribute.GetCustomAttribute(x, typeof(LucenseKeyAttribute)) != null);
            return prop != null ? prop.Name : string.Empty;
        }
        private static void Optimize(Action<IndexWriter> callBack)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);
            //if (IndexWriter.IsLocked(_directory)) 
            // IndexWriter.Unlock(_directory);
            //_directoryTemp = FSDirectory.Open(new DirectoryInfo(_luceneDir.FullName));
            using (var writer = new IndexWriter(_directory, analyzer,true, IndexWriter.MaxFieldLength.UNLIMITED))
            {

                try
                {

                    callBack(writer);
                }
                catch (Exception ex)
                {
                }

                finally
                {
                    analyzer.Close();
                    writer.Optimize();
                    writer.Dispose();
                }

            }
        }
        private static IEnumerable<T> _mapLuceneToDataList(IEnumerable<Document> hits)
        {
            return hits.Select(_mapLuceneDocumentToData).ToList();
        }
        private static IEnumerable<T> _mapLuceneToDataList(IEnumerable<ScoreDoc> hits, IndexSearcher searcher)
        {
            return hits.Select(hit => _mapLuceneDocumentToData(searcher.Doc(hit.Doc))).ToList();
        }
        private static T _mapLuceneDocumentToData(Document doc)
        {

            var obj = new T();
            foreach (var prop in typeof(T).GetProperties())
            {
                var luceneVal = doc.GetField(prop.Name)?.StringValue ?? string.Empty;
                obj.GetType().GetProperty(prop.Name).SetValue(obj, luceneVal);

            }
            return (T)obj;
        }
        public static void ClearLuceneIndex()
        {
            Optimize((writer) =>
            {
                writer.DeleteAll();

            });
        }
    }
}
