namespace Transliterator.Schemas;

internal static class National
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
        { 'ь', "" },
        { 'э', "e" },
        { 'ю', "iu" },
        { 'я', "ia" }
    };

    public static Mappings GetMappings()
    {
        return new Mappings
        {
            LetterMapping = letterMapping
        };
    }
}
