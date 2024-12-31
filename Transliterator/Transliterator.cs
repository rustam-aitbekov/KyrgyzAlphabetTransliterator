using Transliterator.Schemas;

namespace Transliterator;

public static class Transliterator
{
    private const int ENDING_LENGTH = 2;

    /// <summary>
    /// Транслитирирует кириллическую строку в латинскую (включая кыргызские буквы ө,ү,ң)
    /// </summary>
    /// <param name="source">Строка для транслитерации</param>
    /// <param name="translitScheme">Схема транслитерации</param>
    /// <returns></returns>
    public static string Transliterate(string source, TranslitSchema translitScheme)
    {
        var mapping = translitScheme switch
        {
            TranslitSchema.Icao => National.GetMappings(),
            _ => Wikipedia.GetMappings()
        };

        var scheme = new Scheme(mapping);

        return string.Join(" ", source.Split().Select(w => TranslateWord(w, scheme)));
    }

    private static string TranslateWord(string word, Scheme scheme)
    {
        var wordInfo = SplitWord(word);
        if (scheme.TryTranslitEnding(wordInfo.Ending, out var translatedEnding))
            return string.Join(TranslateLetters(wordInfo.Stem, scheme), translatedEnding);

        return TranslateLetters(word, scheme);
    }

    private static string TranslateLetters(string letters, Scheme scheme)
    {
        return string.Join(string.Empty, ReadLetters(letters).Select(scheme.TranslitLetter));
    }

    private static WordInfo SplitWord(string word)
    {
        if (word.Length <= ENDING_LENGTH)
            return new WordInfo(word, string.Empty);

        return new WordInfo(word.Substring(0, word.Length - ENDING_LENGTH), word.Substring(word.Length - ENDING_LENGTH));
    }

    private static IEnumerable<LetterInfo> ReadLetters(string stem)
    {
        for (int i = 0; i < stem.Length; i++)
        {
            var previous = i > 0 ? stem[i - 1] : (char?)null;
            var next = i + 1 < stem.Length ? stem[i + 1] : (char?)null;

            yield return new LetterInfo(previous, stem[i], next);
        }
    }
}
