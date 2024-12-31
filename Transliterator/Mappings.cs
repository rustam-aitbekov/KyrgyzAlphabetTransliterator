namespace Transliterator;

public sealed class Mappings
{
    public required Dictionary<char, string> LetterMapping;

    public Dictionary<string, string>? PreviousMapping;

    public Dictionary<string, string>? NextMapping;

    public Dictionary<string, string>? EndingMapping;
}
