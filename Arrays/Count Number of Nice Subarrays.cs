public int NumberOfSubarrays(int[] nums, int k) 
{
	var count = 0;
	var lst = new List<int> { -1 };

	for (var i = 0; i < nums.Length; ++i) 
	{
		if (nums[i] % 2 == 1) 
		{
			lst.Add(i);
		}
	}

	lst.Add(nums.Length);

	for (var i = 1; i + k < lst.Count; ++i) 
	{
		var left = lst[i] - lst[i - 1];
		var right = lst[i + k] - lst[i + k - 1];
		count += left * right;
	}

	return count;
}