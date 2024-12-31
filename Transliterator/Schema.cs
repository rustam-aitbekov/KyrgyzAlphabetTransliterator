namespace Transliterator;

internal class Scheme
{
    private readonly IDictionary<char, string> letterMapping;
    private readonly IDictionary<string, string> previousMapping;
    private readonly IDictionary<string, string> nextMapping;
    private readonly IDictionary<string, string> endingMapping;

    public Scheme(Mappings mappings)
    {
        letterMapping = GetMapping(mappings.LetterMapping) ?? new Dictionary<char, string>();
        previousMapping = GetPreviousMapping(mappings.PreviousMapping) ?? new Dictionary<string, string>();
        nextMapping = GetNextMapping(mappings.NextMapping) ?? new Dictionary<string, string>();
        endingMapping = GetEndingMapping(mappings.EndingMapping) ?? new Dictionary<string, string>();
    }

    private static Dictionary<char, string> GetMapping(IDictionary<char, string> mapping)
    {
        if (mapping == null)
            return new Dictionary<char, string>();

        var result = new Dictionary<char, string>(mapping);

        foreach (var pair in mapping)
            result[char.ToUpper(pair.Key)] = pair.Value.ToUpperFirstLetter();

        return result;
    }

    private static Dictionary<string, string> GetPreviousMapping(IDictionary<string, string>? mapping)
    {
        if (mapping == null)
            return new Dictionary<string, string>();

        var result = new Dictionary<string, string>(mapping);

        foreach (var pair in mapping)
        {
            result[pair.Key.ToUpperFirstLetter()] = pair.Value;
            result[pair.Key.ToUpper()] = pair.Value.ToUpperFirstLetter();
        }

        return result;
    }

    private static Dictionary<string, string> GetNextMapping(IDictionary<string, string>? mapping)
    {
        if (mapping == null)
            return new Dictionary<string, string>();

        var result = new Dictionary<string, string>(mapping);

        foreach (var pair in mapping)
        {
            result[pair.Key.ToUpperFirstLetter()] = pair.Value.ToUpperFirstLetter();
            result[pair.Key.ToUpper()] = pair.Value.ToUpperFirstLetter();
        }

        return result;
    }

    private static Dictionary<string, string> GetEndingMapping(IDictionary<string, string>? mapping)
    {
        if (mapping == null)
            return new Dictionary<string, string>();

        var result = new Dictionary<string, string>(mapping);

        foreach (var pair in mapping)
            result[pair.Key.ToUpper()] = pair.Value.ToUpper();

        return result;
    }

    private string TranslitLetter(char? previous, char current, char? next)
    {
        var previousKey = previous == null ? current.ToString() : $"{previous}{current}";
        if (previousMapping.TryGetValue(previousKey, out var letter))
            return letter;

        var nextKey = next == null ? current.ToString() : $"{current}{next}";
        if (nextMapping.TryGetValue(nextKey, out letter))
            return letter;

        return letterMapping.TryGetValue(current, out letter) ? letter : current.ToString();
    }

    internal string TranslitLetter(LetterInfo letterInfo) => TranslitLetter(letterInfo.Previous, letterInfo.Current, letterInfo.Next);

    internal bool TryTranslitEnding(string ending, out string translated)
    {
        return endingMapping.TryGetValue(ending, out translated);
    }
}
