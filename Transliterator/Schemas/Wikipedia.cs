namespace Transliterator.Schemas;

internal static class Wikipedia
{
    private static readonly Dictionary<char, string> letterMapping = new()
    {
            { 'а', "a" },
            { 'б', "b" },
            { 'в', "v" },
            { 'г', "g" },
            { 'д', "d" },
            { 'е', "e" },
            { 'ё', "e" },
            { 'ж', "zh" },
            { 'з', "z" },
            { 'и', "i" },
            { 'й', "i" },
            { 'к', "k" },
            { 'л', "l" },
            { 'м', "m" },
            { 'н', "n" },
            { 'ң', "n" },
            { 'о', "o" },
            { 'ө', "o" },
            { 'п', "p" },
            { 'р', "r" },
            { 'с', "s" },
            { 'т', "t" },
            { 'у', "u" },
            { 'ү', "u" },
            { 'ф', "f" },
            { 'х', "kh" },
            { 'ц', "ts" },
            { 'ч', "ch" },
            { 'ш', "sh" },
            { 'щ', "shch" },
            { 'ъ', "ie" },
            { 'ы', "y" },
            { 'ь', "" } ,
            { 'э', "e" },
            { 'ю', "iu" },
            { 'я', "ia" }
    };

    private static readonly Dictionary<string, string> previousMapping = new()
    {
            { "е", "ye" },
            { "ае", "ye" },
            { "ие", "ye" },
            { "ое", "ye" },
            { "уе", "ye" },
            { "эе", "ye" },
            { "юе", "ye" },
            { "яе", "ye" },
            { "ье", "ye" },
            { "ъе", "ye" }
    };

    private static readonly Dictionary<string, string> nextMapping = new()
    {
            { "ъа", "y" },
            { "ъи", "y" },
            { "ъо", "y" },
            { "ъу", "y" },
            { "ъы", "y" },
            { "ъэ", "y" },
            { "ьа", "y" },
            { "ьи", "y" },
            { "ьо", "y" },
            { "ьу", "y" },
            { "ьы", "y" },
            { "ьэ", "y" }
    };

    private static readonly Dictionary<string, string> endingMapping = new()
    {
            { "ый", "y" },
            { "ий", "y" }
    };

    public static Mappings GetMappings()
    {
        return new Mappings
        {
            LetterMapping = letterMapping,
            PreviousMapping = previousMapping,
            NextMapping = nextMapping,
            EndingMapping = endingMapping,
        };
    }
}
