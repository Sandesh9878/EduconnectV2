using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index; 
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
namespace Educonnect.Course.Service.SearchEngine
{
    public class SearchEngine
    {
        public static IndexWriter Writer { get; set; }
        public static List<Person> Data { get; set; }
        private static RAMDirectory _directory;
        private static string _personGuidToBeUpdated;

        public static void GetData()
        {
            Data = new List<Person>()
            {
                new Person(Guid.NewGuid().ToString(),"Fred","George","Herb","A tall thin man."),
                new Person(Guid.NewGuid().ToString(),"Frank","Ed","Stevens","A short fat man."),
                new Person(Guid.NewGuid().ToString(),"Alfred","Edward","Stewart","A medium average man."),
                new Person(Guid.NewGuid().ToString(),"Joe","Rand","Smith","A very tall large man."),
                new Person(Guid.NewGuid().ToString(),"Abigal","Elizabeth","Spear","A tall thin woman."),
                new Person(Guid.NewGuid().ToString(),"Michael","Rose","Garcia","A small average woman."),
                new Person(Guid.NewGuid().ToString(),"Deborah","Jordan","Davis","A tall large woman."),
                new Person(Guid.NewGuid().ToString(),"Bertha","Madison","Jones","A short fat woman."),
                new Person(Guid.NewGuid().ToString(),"Clint","Johnny","Williams","A very tiny boy."),
                new Person(Guid.NewGuid().ToString(),"Susan","Michele","Brown","A very tiny girl.")
            };
        }

    }
}
