public class Solution 
{
    public int GetKth(int lo, int hi, int k)
    {
        var map = new Dictionary<int, int>();
        var memo = new Dictionary<int, int>();

        for (var i = lo; i <= hi; ++i)
            map[i] = GetPow(i, memo);

        var ordered = map.OrderBy(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key).ToArray();

        return ordered[k - 1];
    }

    private static int GetPow(int num, Dictionary<int, int> memo)
    {
        if (memo.TryGetValue(num, out var cached)) return cached;

        if (num == 1)
            return 0;

        var res = num % 2 == 0 ? 1 + GetPow(num / 2, memo) : 1 + GetPow(3 * num + 1, memo);

        memo[num] = res;

        return res;
    }
}