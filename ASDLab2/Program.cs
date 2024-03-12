namespace ASDLab2;

class Program
{
    public static void Main(string[] args)
    {
        // Illustrate the work of the PARTITION procedure with the array A = (13,19,9,5,12,8,7,4,21,2,6,11).
        var array1 = new[] { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };
        Console.WriteLine($"Array before partition: [{string.Join(", ", array1)}]");
        var pivot1 = Partition(array1, 0, array1.Length - 1);
        Console.WriteLine($"Partitioned array: [{string.Join(", ", array1)}], Pivot index: {pivot1}\n\n");

        // Illustrate the work of the PARTITION procedure with an array where all elements are the same.
        var array2 = new[] { 5, 5, 5, 5, 5 };
        Console.WriteLine("Array with identical elements: [5, 5, 5, 5, 5]");
        var pivot2 = Partition(array2, 0, array2.Length - 1);
        Console.WriteLine($"Partitioned array with identical elements: [{string.Join(", ", array2)}], Pivot index: {pivot2}\n");

        // Use the QUICKSORT procedure to sort in non-ascending order.
        var array3 = new[] { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };
        Console.WriteLine($"Array before sorting: [{string.Join(", ", array3)}]");
        QuickSortDescending(array3, 0, array3.Length - 1);
        Console.WriteLine($"Array sorted in non-ascending order: [{string.Join(", ", array3)}]\n");
        
        // Use the RANDOMIZED-QUICKSORT procedure to sort in non-ascending order.
        var array4 = new[] { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };
        Console.WriteLine($"Array before sorting using randomized quicksort: [{string.Join(", ", array4)}]");
        RandomizedQuickSort(array4, 0, array4.Length - 1);
        Console.WriteLine($"Array sorted in non-ascending order using randomized quicksort: [{string.Join(", ", array4)}]\n");

        // Illustrate the processing of the array A = (6,0,2,0,1,3,4,6,1,3,2) by the COUNTING-SORT procedure.
        var array5 = new[] { 6, 0, 2, 0, 1, 3, 4, 6, 1, 3, 2 };
        CountingSort(array5, array5.Max());
        Console.WriteLine($"Array after counting sort: [{string.Join(", ", array5)}]\n");

        // Illustrate the work of the RADIX-SORT algorithm with the following list of English words: COW, DOG, SEA, RUG, ROW, MOB, BOX, TAB, BAR, EAR, TAR, DIG, BIG, TEA, NOW, FOX.
        var words = new[] { "COW", "DOG", "SEA", "RUG", "ROW", "MOB", "BOX", "TAB", "BAR", "EAR", "TAR", "DIG", "BIG", "TEA", "NOW", "FOX" };
        RadixSort(words);
        Console.WriteLine($"Words after radix sort: [{string.Join(", ", words)}]\n");

        // Illustrate the work of the BUCKET-SORT algorithm with the array A = (.79, .13, .16, .64, .39, .20, .89, .53, .71, .42).
        // var array6 = new[] { .79f, .13f, .16f, .64f, .39f, .20f, .89f, .53f, .71f, .42f };
        // BucketSort(array6);
        // Console.WriteLine($"Array after bucket sort: [{string.Join(", ", array6)}]");

        // Illustrate the optimal pipeline location with the given well coordinates.
        var wellCoordinates = new[] { 1f, 2f, 3f, 4f, 5f };
        var optimalLocation = OptimalPipelineLocation(wellCoordinates);
        Console.WriteLine($"Optimal pipeline location: {optimalLocation}");
    }
    
    private static float OptimalPipelineLocation(float[] wellCoordinates)
    {
        Array.Sort(wellCoordinates);
        return wellCoordinates[wellCoordinates.Length / 2];
    }
    private static void QuickSortDescending(int[] array, int left, int right)
    {
        if (left < right)
        {
            var pivot = Partition(array, left, right);
            QuickSortDescending(array, left, pivot - 1);
            QuickSortDescending(array, pivot + 1, right);
        }
    }

    private static void CountingSort(int[] array, int range)
    {
        var count = new int[range + 1];
        var output = new int[array.Length];
        for (var i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }
        for (var i = 1; i <= range; i++)
        {
            count[i] += count[i - 1];
        }
        for (var i = array.Length - 1; i >= 0; i--)
        {
            output[count[array[i]] - 1] = array[i];
            count[array[i]]--;
        }
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = output[i];
        }
    }

    private static void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            var pivot = Partition(array, left, right);
            QuickSort(array, left, pivot - 1);
            QuickSort(array, pivot + 1, right);
        }
    }

    private static void RandomizedQuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            var pivotIndex = new Random().Next(left, right);
            Swap(array, right, pivotIndex);
            var pivot = Partition(array, left, right);
            RandomizedQuickSort(array, left, pivot - 1);
            RandomizedQuickSort(array, pivot + 1, right);
        }
    }

    private static int Partition(int[] array, int left, int right)
    {
        var pivot = array[right];
        var low = left - 1;
        for (var i = left; i < right; i++)
        {
            if (array[i] < pivot)
            {
                low++;
                Swap(array, low, i);
            }
        }
        Swap(array, low + 1, right);
        return low + 1;
    }

    private static void Swap(int[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }
    private static void Swap(string[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }

    private static void PrintArray(string[] words)
    {
        Console.WriteLine($"[{string.Join(", ", words)}]");
    }
    
    private static void RadixSort(string[] words)
    {
        var maxLength = words.Max(word => word.Length);

        for (var position = maxLength - 1; position >= 0; position--)
        {
            CountingSortByPosition(words, position);
        }
    }

    private static void CountingSortByPosition(string[] words, int position)
    {
        const int alphabetSize = 26;
        var count = new int[alphabetSize];
        var output = new string[words.Length];

        foreach (var word in words)
        {
            var index = position < word.Length ? word[position] - 'A' : 0;
            count[index]++;
        }

        for (var i = 1; i < alphabetSize; i++)
        {
            count[i] += count[i - 1];
        }

        for (var i = words.Length - 1; i >= 0; i--)
        {
            var index = position < words[i].Length ? words[i][position] - 'A' : 0;
            output[count[index] - 1] = words[i];
            count[index]--;
        }

        for (var i = 0; i < words.Length; i++)
        {
            words[i] = output[i];
        }
    }
    
}