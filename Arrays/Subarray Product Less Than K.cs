public int NumSubarrayProductLessThanK(int[] nums, int k)
{
    if (nums.Length == 0 || k <= 1)
    {
        return 0;
    }

    var cnt = 0;
    var current = 1l;
    var start = 0;

    for (var i = 0; i < nums.Length; ++i)
    {
        current *= nums[i];

        while (current >= k)
        {
            current /= nums[start];
            ++start;
        }

        cnt += i - start + 1;
    }

    return cnt;
}



