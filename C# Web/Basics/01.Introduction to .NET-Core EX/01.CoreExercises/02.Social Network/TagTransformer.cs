using System.Text.RegularExpressions;

namespace _02.Social_Network
{
    public class TagTransformer
    {
        public static string Transform(string tag)
        {
            if (tag[0] != '#')
            {
                return "#" + Truncate(Regex.Replace(tag, @"\s+", ""), 19);
            }
            return Truncate(Regex.Replace(tag, @"\s+", ""), 20);
        }

        private static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}