public int IntegerReplacement(int n) 
{
	var memo = new Dictionary<long, int>();
	return IntegerReplacement(n, memo);
}

private static int IntegerReplacement(long n, Dictionary<long, int> memo) 
{
	if (n == 1)        
	{
		return 0;
	}

	if (memo.TryGetValue(n, out var res))
	{
		return res;
	}

	var originalN = n;
	var cnt = 0;
	while (n % 2 == 0)
	{
		n /= 2;
		++cnt;
	}    

	if (n == 1)        
	{
		memo[originalN] = cnt;
		return cnt;
	}    

	cnt = cnt > 0 ? cnt + 1 : 1;        

	var add = cnt + IntegerReplacement(n + 1, memo);
	var substr = cnt + IntegerReplacement(n - 1, memo);

	var result = Math.Min(add, substr);
	memo[n] = result;
	return result;
}