namespace Educonnect.Course.Service.SearchEngine
{
    public static class NumericRangeHelper
    {
        public static NumericRangeQueryOption GetNumericOptions(string input)
        {
            NumericRangeQueryOption result = new NumericRangeQueryOption();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var split = input.Split('-');
                result.Min = Convert.ToDouble(split[0]);
                result.Max = Convert.ToDouble(split[1]);
            }
            return result;
        }
        public static string[] GetSplitedData(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                var split = input.Split(',');
                return split;
            }
            else
            {
                return null;
            }
        }
    }
}
