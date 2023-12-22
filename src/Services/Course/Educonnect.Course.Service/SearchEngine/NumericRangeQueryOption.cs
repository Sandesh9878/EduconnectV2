namespace Educonnect.Course.Service.SearchEngine
{
    public class NumericRangeQueryOption
    {
        public double? Min { get; set; }
        public double? Max { get; set; }
        public bool MinInclusive { get; set; }
        public bool MaxInclusive { get; set; }
    }
}
