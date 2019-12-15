public int PalindromePartition(string s, int k) 
{
	var memo = new Dictionary<string, int>[k + 1];
	
	for (var i = 1; i < k + 1; ++i)
	{
		memo[i] = new Dictionary<string, int>();
	}
	
	return FindSolution(s, k, memo);
}

private static int FindSolution(string s, int k, Dictionary<string, int>[] memo) 
{        
	if(k == 1) return CountSteps(s);
	if(memo[k].ContainsKey(s)) return memo[k][s];
	
	var result = int.MaxValue;
	
	for (var i = 1; i <= s.Length - k + 1; ++i)
	{
		var first = FindSolution(s.Substring(0, i), 1, memo);
		var rest = FindSolution(s.Substring(i, s.Length - i), k - 1, memo);
		result = Math.Min(result, first + rest);
	}
	
	memo[k][s] = result;
	
	return result;
}

private static int CountSteps(string s)
{
	var cnt = 0;
	
	for (int i = 0, j = s.Length - 1; i < j; ++i, --j)
	{
		if (s[i] != s[j])
			++cnt;
	}
	
	return cnt;
}