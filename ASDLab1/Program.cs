using System.Diagnostics;

namespace ASDLab1;

class Program
{
    private const string InvalidInputMessage = "Invalid input. Please enter a valid integer.";
    private const string AlgorithmChoicePrompt = "Choose an algorithm:";
    private const string NumberOfElementsPrompt = "Enter the number of elements in the array: ";
    private const string MaxValuePrompt = "Enter the maximum value of the elements in the array: ";

    private static int GetInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (int.TryParse(input, out var value))
            {
                return value;
            }
            Console.WriteLine(InvalidInputMessage);
        }
    }

    private static void PerformAndTimeSearch(ArraySearcher searcher, Func<int, int> searchMethod, string methodName)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine(searchMethod(3));
        stopwatch.Stop();
        Console.WriteLine($"Time taken by {methodName}: {stopwatch.Elapsed}");
    }

    private static void DisplayMenu()
    {
        Console.WriteLine(AlgorithmChoicePrompt);
        Console.WriteLine("1. Linear Search");
        Console.WriteLine("2. Binary Search");
        Console.WriteLine("3. Jump Search");
        Console.WriteLine("4. Interpolation Search");
        Console.WriteLine("5. Compare all");
        Console.WriteLine("6. Exit");
    }

    public static void Main(string[] args)
    {
        var count = GetInput(NumberOfElementsPrompt);
        var maxValue = GetInput(MaxValuePrompt);

        var generator = new RandomNumberGenerator();
        var array = generator.GenerateNumbers(count, maxValue);
        var searcher = new ArraySearcher(array);

        while (true)
        {
            DisplayMenu();

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformAndTimeSearch(searcher, searcher.LinearSearch, "LinearSearch");
                    break;
                case "2":
                    PerformAndTimeSearch(searcher, searcher.BinarySearch, "BinarySearch");
                    break;
                case "3":
                    PerformAndTimeSearch(searcher, searcher.JumpSearch, "JumpSearch");
                    break;
                case "4":
                    PerformAndTimeSearch(searcher, searcher.InterpolationSearch, "InterpolationSearch");
                    break;
                case "5":
                    PerformAndTimeSearch(searcher, searcher.LinearSearch, "LinearSearch");
                    PerformAndTimeSearch(searcher, searcher.BinarySearch, "BinarySearch");
                    PerformAndTimeSearch(searcher, searcher.JumpSearch, "JumpSearch");
                    PerformAndTimeSearch(searcher, searcher.InterpolationSearch, "InterpolationSearch");
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }
}