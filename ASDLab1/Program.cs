using System.Diagnostics;

namespace ASDLab1;

public static class Program
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

    private static TimeResult PerformAndTimeSearch(Func<int, int> searchMethod, int target)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = searchMethod(target);
        stopwatch.Stop();
        return new TimeResult(result, stopwatch.Elapsed.TotalMilliseconds);
    }
    private static void PerformSearchAndDisplayTime(Searcher searcher, int target, AlgorithmChoice methodName)
    {
        Console.WriteLine($"{searcher.GetType().Name}:");
        TimeResult result;
        switch (methodName)
        {
            case AlgorithmChoice.LinearSearch:
                result = PerformAndTimeSearch(searcher.LinearSearch, target);
                Console.WriteLine($"Index: {result.Index}, Time: {result.Time}ms");
                break;
            case AlgorithmChoice.BinarySearch:
                result = PerformAndTimeSearch(searcher.BinarySearch, target);
                Console.WriteLine($"Index: {result.Index}, Time: {result.Time}ms");
                break;
            case AlgorithmChoice.GoldenRatioSearch:
                result = PerformAndTimeSearch(searcher.GoldenRatioSearch, target);
                Console.WriteLine($"Index: {result.Index}, Time: {result.Time}ms");
                break;
            case AlgorithmChoice.BarrierSearch:
                result = PerformAndTimeSearch(searcher.BarrierSearch, target);
                Console.WriteLine($"Index: {result.Index}, Time: {result.Time}ms");
                break;

            case AlgorithmChoice.CompareAll:
                result = PerformAndTimeSearch(searcher.LinearSearch, target);
                Console.WriteLine($"Linear Search: Index: {result.Index}, Time: {result.Time}ms");
                result = PerformAndTimeSearch(searcher.BinarySearch, target);
                Console.WriteLine($"Binary Search: Index: {result.Index}, Time: {result.Time}ms");
                result = PerformAndTimeSearch(searcher.GoldenRatioSearch, target);
                Console.WriteLine($"Golden Ratio Search: Index: {result.Index}, Time: {result.Time}ms");
                result = PerformAndTimeSearch(searcher.BarrierSearch, target);
                Console.WriteLine($"Barrier Search: Index: {result.Index}, Time: {result.Time}ms");
                break;
            
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine(AlgorithmChoicePrompt);
        Console.WriteLine("1. Linear Search");
        Console.WriteLine("2. Binary Search");
        Console.WriteLine("3. Golden Ratio Search");
        Console.WriteLine("4. Barrier Search");
        Console.WriteLine("5. Compare all");
        Console.WriteLine("6. Exit");
    }

    public static void Main()
    {
        var count = GetInput(NumberOfElementsPrompt);
        var maxValue = GetInput(MaxValuePrompt);

        var generator = new RandomNumberGenerator();
        
        var array = generator.GenerateNumbers(count, maxValue);
        Array.Sort(array);
        
        var arraySearcher = new ArraySearcher(array);
    
        var myList = new NodeList();
        foreach (var num in array)
        {
            myList.Add(num);
        }
        var nodeListSearcher = new NodeListSearcher(myList);
        
        var continueCalculations = true;
        while (continueCalculations)
        {
            PrintArray(array);
            DisplayMenu();
            var choice = (AlgorithmChoice) GetInput(AlgorithmChoicePrompt);
            if (choice == AlgorithmChoice.Exit)
            {
                return;
            }
            var target = GetInput("Enter the target value: ");
            
            PerformSearchAndDisplayTime(arraySearcher, target, choice);
            PerformSearchAndDisplayTime(nodeListSearcher, target, choice);
            
            Console.WriteLine("Continue calculations? (y/n)");
            continueCalculations = Console.ReadLine()?.ToLower() == "y";
        }
    }
    private static void PrintArray(IEnumerable<int> array)
    {
        Console.WriteLine($"[{string.Join(", ", array)}]");
    }

}