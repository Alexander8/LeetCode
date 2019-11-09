public int LongestSubstring(string s, int k) 
{
	if (string.IsNullOrEmpty(s))
	{
		return 0;
	}

	if (s.Length < k)
	{
		return 0;
	}

	var charsToRemove = GetCharsToRemove(s, k);
	if (charsToRemove.Length == 0)
	{
		return s.Length;
	}

	var maxLen = 0;
	var candidates = s.Split(charsToRemove, StringSplitOptions.RemoveEmptyEntries);
	 
	foreach (var candidate in candidates.Where(c => c.Length >= k))
	{
		var len = LongestSubstring(candidate, k);
	
		maxLen = Math.Max(maxLen, len);
	}

	return maxLen;
}

private static char[] GetCharsToRemove(string s, int k)
{
	var arr = new int[26];

	for (var i = 0; i < s.Length; ++i)
	{
		arr[s[i] - 'a'] += 1;
	} 

	var charsToRemove = new List<char>();

	for (var i = 0; i < arr.Length; ++i)
	{
		if (arr[i] > 0 && arr[i] < k)
		{
			charsToRemove.Add((char)(i + 'a'));
		}
	}

	return charsToRemove.ToArray();        
}