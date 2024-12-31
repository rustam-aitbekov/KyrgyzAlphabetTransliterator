namespace Transliterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var foo = Transliterator.Transliterate("щавел деген тамак үлгүлүү өңдөнөт", TranslitSchema.Icao);

            Console.WriteLine(foo);

            var bar = Transliterator.Transliterate("щавел деген тамак үлгүлүү өңдөнөт", TranslitSchema.Wikipedia);

            Console.WriteLine(bar);
        }
    }
}
