namespace Etechnosoft.Common.Extensions
{
    public static class StringExtension
    {
        public static string TrimStartingZeros(this string number)
        {
            return number.TrimStart('0');
        }
    }
}