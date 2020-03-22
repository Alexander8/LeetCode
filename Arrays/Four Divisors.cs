public class Solution 
{
    public int SumFourDivisors(int[] nums) 
    {
        var s = 0;
        var memo = new Dictionary<int, int>
        {
            {0, 0}
        };

        for (var i = 0; i < nums.Length; ++i)
        {
            s += GetSum(nums[i], memo);
        }

        return s;
    }

    private static int GetSum(int num, Dictionary<int, int> memo)
    {
        if (memo.TryGetValue(num, out var cached))
            return cached;

        var cnt = 2;
        var sum = 1 + num;

        for (var i = 2; i <= Math.Sqrt(num); ++i)
        {
            if (num % i == 0)
            {
                if ((double)i == Math.Sqrt(num))
                {
                    cnt += 1;
                    sum += i;
                }
                else
                {
                    cnt += 2;
                    sum += i;
                    sum += num / i;
                }
            }

            if (cnt > 4)
            {
                memo[num] = 0;
                return 0;
            }
        }

        if (cnt != 4)
        {
            memo[num] = 0;
            return 0;
        }

        memo[num] = sum;
        return sum;
    }
}