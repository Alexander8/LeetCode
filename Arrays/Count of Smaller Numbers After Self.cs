public IList<int> CountSmaller(int[] nums) 
{
	var res = new List<int>(nums.Length);
	if (nums.Length == 0) return res;
	
	var sArr = new SortedArray(nums.Length);
	
	for (var i = nums.Length - 1; i >= 0; --i)
	{
		var cnt = sArr.Add(nums[i]);
		res.Insert(0, cnt);
	}
	
	return res;
}

private sealed class SortedArray
{
	private readonly List<int> _list;
	
	public SortedArray(int len)
	{
		_list = new List<int>(len);
	}
	
	public int Add(int num)
	{
		var idx = _list.BinarySearch(num);
		if (idx < 0) 
		{
			idx = ~idx;            
			_list.Insert(idx, num);
			return idx;
		}
		else
		{
			while (idx - 1 >= 0 && _list[idx - 1] == num)
				--idx;
			
			_list.Insert(idx, num);
			return idx;
		}
	}
}