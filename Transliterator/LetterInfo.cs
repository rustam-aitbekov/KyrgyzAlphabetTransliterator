namespace Transliterator;

internal class LetterInfo
{
    public char? Previous { get; }
    public char Current { get; }
    public char? Next { get; }

    public LetterInfo(char? previous, char current, char? next)
    {
        Previous = previous;
        Current = current;
        Next = next;
    }
}
