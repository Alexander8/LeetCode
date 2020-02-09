public int Change(int amount, int[] coins)
{
	var dp = new int[amount + 1];
	dp[0] = 1;

	foreach (var coin in coins)
	{
		for (var i = 1; i <= amount; ++i)
		{
			if (i >= coin)
				dp[i] += dp[i - coin];
		}
	}

	return dp[amount];
}