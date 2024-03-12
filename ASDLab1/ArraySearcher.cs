namespace ASDLab1;

public class ArraySearcher : Searcher
{
    private readonly int[] _array;

    public ArraySearcher(int[] array)
    {
        _array = array;
    }


    public override int LinearSearch(int target)
    {
        for (var i = 0; i < _array.Length; i++)
        {
            if (_array[i] == target)
            {
                return i;
            }
        }
        return -1;
    }

    public override int BinarySearch(int target)
    {
        var left = 0;
        var right = _array.Length - 1;
        while (left <= right)
        {
            var middle = (left + right) / 2;
            if (_array[middle] == target)
            {
                return middle;
            }

            if (_array[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;

    }

    public override int GoldenRatioSearch(int target)
    {
        int left = 0, right = _array.Length - 1;
        while (left <= right)
        {
            var mid = Convert.ToInt32((right - left) / 1.618 + left);
            if (_array[mid] == target) return mid;
            if (_array[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }

    public override int BarrierSearch(int target)
    {
        var i = 0;
        for(; _array[i] != target; i++) { }
        return i;
    }
}