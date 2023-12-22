using Lucene.Net.Documents;

namespace Educonnect.Course.Service.SearchEngine
{
    public class LucenseKeyAttribute:Attribute
    {
        Field.Store _store;
        Field.Index _index;
        public LucenseKeyAttribute(Field.Store store = Field.Store.YES, Field.Index fieldIndex = Field.Index.ANALYZED)
        {
            _store = store;
            _index = fieldIndex;
        }
    }
}
