public int MaxLength(IList<string> arr)
{
	return MaxLength("", arr, 0);
}

private static int MaxLength(string current, IList<string> arr, int idx)
{
	if (new HashSet<char>(current).Count != current.Length)
	{
		return -1;
	}

	if (idx == arr.Count)
	{
		return current.Length;
	}

	var len = current.Length;
	for (var i = idx; i < arr.Count; ++i)
	{
		var lenTmp = MaxLength(current + arr[i], arr, i + 1);
		len = Math.Max(len, lenTmp);
	}

	return len;
}