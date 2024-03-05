# Лабораторна робота № 1
## Тема: Пошук елементів у масивах

### 1. Мета:
- Дослідити ефективність різних алгоритмів пошуку елементів у масивах.
- Порівняти час виконання алгоритмів пошуку в масивах та зв'язних списках.
- Вивчити алгоритми:
  - Пошуку перебором
  - Пошуку з бар'єром
  - Бінарного пошуку
  - Бінарного пошуку на основі золотого перерізу

### 2. Умови задачі:
- Написати програму мовою C#.
- Продемонструвати роботу та ефективність (час виконання) програм на різних структурах даних (масив, лінійний зв'язаний список).
- Навести аналіз отриманих результатів.

### 3. Алгоритми:
#### 3.1. Лінійний пошук:
```csharp
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
```

#### 3.2. Пошук з бар'єром:
```csharp
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
```

#### 3.3. Бінарний пошук:

```csharp
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
```

#### 3.4. Бінарний пошук на основі золотого перерізу:
```csharp
public int GoldenRatioBinarySearch(int number)
{
    var left = 0;
    var right = _array.Length - 1;
    var phi = (1 + Math.Sqrt(5)) / 2;
    while (left <= right)
    {
        var middle = (int)Math.Floor(left + (right - left) / phi);
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

```

### 4. Тести: