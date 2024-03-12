

public class Program
{
    public static void Main(string[] args)
    {
        var words = new[] { "COW", "DOG", "SEA", "RUG", "ROW", "MOB", "BOX", "TAB", "BAR", "EAR", "TAR", "DIG", "BIG", "TEA", "NOW", "FOX" };

        Console.WriteLine("Original array:");
        PrintArray(words);

        Sort(words);

        Console.WriteLine("\nSorted array:");
        PrintArray(words);
    }

    private static void Sort(string[] words)
    {
        var maxLength = words.Max(word => word.Length);

        for (var digit = maxLength - 1; digit >= 0; digit--)
        {
            CountingSort(words, digit);
        }
    }

    private static void CountingSort(string[] words, int digit)
    {
        const int alphabetSize = 26;

        var buckets = new List<string>[alphabetSize];
        for (var i = 0; i < alphabetSize; i++)
        {
            buckets[i] = new List<string>();
        }

        foreach (var word in words)
        {
            var index = (word.Length > digit) ? (char.ToUpperInvariant(word[word.Length - digit - 1]) - 'A') : 0;
            buckets[index].Add(word);
        }

        var currentIndex = 0;
        foreach (var bucket in buckets)
        {
            if (bucket.Count > 0)
            {
                bucket.CopyTo(words, currentIndex);
                currentIndex += bucket.Count;
                bucket.Clear();
            }
        }
    }

    private static void PrintArray(string[] words)
    {
        Console.WriteLine($"[{string.Join(", ", words)}]");
    }
}