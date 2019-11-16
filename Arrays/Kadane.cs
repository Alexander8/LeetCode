private int MaxSumSubArray(int[] nums)
{
	if (nums.Length == 0)
	{
		return 0;
	}

	var maxSum = nums[0];
	var maxSumSoFar = nums[0];

	for (var i = 1; i < nums.Length; ++i)
	{
		maxSumSoFar = Math.Max(maxSumSoFar + nums[i], nums[i]);
		maxSum = Math.Max(maxSumSoFar, maxSum);
	}

	return maxSum;
}