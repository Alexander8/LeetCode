public int LongestConsecutive(int[] nums)
{
	var set = new HashSet<int>();
	
	foreach (var n in nums)
	{
		set.Add(n);
	}
	
	var length = 0;
	
	foreach (var n in nums)
	{
		if (set.Contains(n - 1))
		{
			continue;
		}
		
		var currLen = 1;
		var currNum = n + 1;
		
		while (set.Contains(currNum))
		{
			++currLen;
			++currNum;
		}
		
		length = Math.Max(currLen, length);
	}
	
	return length;
}