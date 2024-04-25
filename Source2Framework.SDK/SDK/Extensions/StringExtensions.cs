namespace Source2Framework.Extensions
{
    public static partial class StringExtensions
    {
        public static string ReplaceColorTags(this string str)
        {
            for (int i = 0; i < Constants.ColorTags.Length; i++)
            {
                str = str.Replace(Constants.ColorTags[i], Constants.ColorCodes[i]);
            }

            return str;
        }

        public static string CensorText(this string str, int letters, string newletters)
        {
            if (str.Length < letters)
                return str;

            return str.Remove(str.Length - letters, letters) + newletters;
        }

        public static bool IsWeaponClassName(this string str)
        {
            return str.StartsWith("weapon_");
        }

        public static bool IsKnifeClassName(string className)
        {
            return className.Contains("bayonet") || className.Contains("knife");
        }

        public static string ReplaceFirst(this string original, string oldValue, string newValue)
        {
            int index = original.IndexOf(oldValue);

            if (index == -1)
            {
                return original;
            }

            return original.Substring(0, index) + newValue + original.Substring(index + oldValue.Length);
        }
    }
}
