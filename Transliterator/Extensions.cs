namespace Transliterator;

internal static class Extensions
{
    public static string ToUpperFirstLetter(this string s)
    {
        return !string.IsNullOrWhiteSpace(s) ? $"{char.ToUpper(s[0]) + s.Substring(1)}" : string.Empty;
    }
}
