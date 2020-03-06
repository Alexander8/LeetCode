public class Solution 
{
    public int FindNthDigit(int n)
    {
        var arr = new (long num, (long start, long finish, long cnt) boundaries)[]
        {
            (9, (1, 9, 1)),
            (180, (10, 99, 2)),
            (2700, (100, 999, 3)),
            (36_000, (1000, 9999, 4)),
            (450_000, (10_000, 99_999, 5)),
            (5_400_000, (100_000, 999_999, 6)),
            (63_000_000, (1_000_000, 9_999_999, 7)),
            (720_000_000, (10_000_000, 99_999_999, 8)),
            (8_100_000_000, (100_000_000, 999_999_999, 9))
        };

        long num = n;
        long tmp = num;
        long sum = 0;
        var i = 0;

        for (; i < arr.Length; ++i)
        {
            sum += arr[i].num;
            if (num <= sum) break;

            tmp -= arr[i].num;
        }

        var idx = tmp / arr[i].boundaries.cnt;

        var remainder = tmp % arr[i].boundaries.cnt;
        if (remainder != 0)
            ++idx;

        var tmpNum = arr[i].boundaries.start + idx - 1;

        if (remainder == 0) return (int)(tmpNum % 10);

        var cnt = arr[i].boundaries.cnt - remainder;

        while (cnt > 0)
        {
            tmpNum /= 10;
            --cnt;
        }

        return (int)(tmpNum % 10);
    }
}