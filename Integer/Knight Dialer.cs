public class Solution 
{
    private const int M = 1000000000 + 7;
    
    private static readonly int[][] Cnt = new[] 
    { 
        new[] { 4, 6 }, 
        new[] { 6, 8 }, 
        new[] { 7, 9 }, 
        new[] { 4, 8 }, 
        new[] { 0, 3, 9 }, 
        new int[0], 
        new[] { 0, 1, 7 }, 
        new[] { 2, 6 }, 
        new[] { 1, 3 }, 
        new[] { 2, 4 }
    };

    public int KnightDialer(int N)
    {
        if (N <= 0) return 0;

        var memo = new Dictionary<(int pos, int n), int>();

        var cnt = 0;

        for (var i = 0; i < Cnt.Length; ++i)
        {
            var tmp = GetMoves(i, N - 1, memo);
            cnt = (cnt + tmp) % M;
        }

        return cnt;
    }

    private static int GetMoves(int pos, int N, Dictionary<(int pos, int n), int> memo)
    {
        if (N == 0) return 1;

        if (memo.TryGetValue((pos, N), out var cached)) return cached;

        var cnt = 0;

        for (var i = 0; i < Cnt[pos].Length; ++i)
        {
            var tmp = GetMoves(Cnt[pos][i], N - 1, memo);
            cnt = (cnt + tmp) % M;
        }

        memo[(pos, N)] = cnt;
        return cnt;
    }
}