public class Solution 
{
    public int NumRollsToTarget(int d, int f, int target)
    {
        var m = 1_000_000_000 + 7;
        var dp = new int[d + 1, target + 1];
        dp[0, 0] = 1;

        for (var die = 1; die <= d; ++die)
        {
            for (var num = 1; num <= target; ++num)
            {
                for (var face = 1; face <= f; ++face)
                {
                    if (face > num)
                        break;

                    dp[die, num] = (dp[die, num] + dp[die - 1, num - face] % m) % m;
                }
            }
        }

        return dp[d, target];
    }
}