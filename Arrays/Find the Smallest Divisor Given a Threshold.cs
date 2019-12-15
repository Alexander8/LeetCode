public int SmallestDivisor(int[] nums, int threshold)
{
    var left = 1;
    var right = int.MaxValue;

    while (left <= right)
    {
        var div = left + (right - left) / 2;

        var sum = 0;
        foreach (var num in nums)
        {
            sum += num / div;
            if (num % div != 0)
                sum += 1;
        }

        if (sum > threshold)
            left = div + 1;
        else
            right = div - 1;
    }

    return left;
}