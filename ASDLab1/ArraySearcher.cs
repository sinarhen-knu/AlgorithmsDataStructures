namespace ASDLab1;

public class ArraySearcher
{
    private readonly int[] _array;
    
    public ArraySearcher(int[] array)
    {
        _array = array;
    }
    
    public int LinearSearch(int number)
    {
        for (var i = 0; i < _array.Length; i++)
        {
            if (_array[i] == number)
            {
                return i;
            }
        }
        return -1;
    }
    
    public int BinarySearch(int number)
    {
        var left = 0;
        var right = _array.Length - 1;
        while (left <= right)
        {
            var middle = (left + right) / 2;
            if (_array[middle] == number)
            {
                return middle;
            }
            
            if (_array[middle] < number)
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
    
    public int JumpSearch(int number)
    {
        var step = (int)Math.Floor(Math.Sqrt(_array.Length));
        var prev = 0;
        while (_array[Math.Min(step, _array.Length) - 1] < number)
        {
            prev = step;
            step += (int)Math.Floor(Math.Sqrt(_array.Length));
            if (prev >= _array.Length)
            {
                return -1;
            }
        }
        while (_array[prev] < number)
        {
            prev++;
            if (prev == Math.Min(step, _array.Length))
            {
                return -1;
            }
        }
        if (_array[prev] == number)
        {
            return prev;
        }
        return -1;
    }
    
    public int InterpolationSearch(int number)
    {
        var left = 0;
        var right = _array.Length - 1;
        while (left <= right && number >= _array[left] && number <= _array[right])
        {
            var pos = left + ((number - _array[left]) * (right - left) / (_array[right] - _array[left]));
            if (_array[pos] == number)
            {
                return pos;
            }
            if (_array[pos] < number)
            {
                left = pos + 1;
            }
            else
            {
                right = pos - 1;
            }
        }
        return -1;
    }

}