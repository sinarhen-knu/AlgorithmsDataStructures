namespace ASDLab1;

public class RandomNumberGenerator
{
    private readonly Random _random = new();

    public int[] GenerateNumbers(int count, int maxValue)
    {
        if (count < 0)
        {
            throw new ArgumentException("Count cannot be negative");
        }
        
        var numbers = new int[count];
        for (var i = 0; i < count; i++)
        {
            numbers[i] = _random.Next(maxValue);
        }
        return numbers;
    }
}