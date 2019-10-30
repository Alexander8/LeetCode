public IList<int> CircularPermutation(int n, int start)
{
	var begin = 0;
	var gray = new int[1 << n];
	var result = new List<int>(1 << n);

	for (var i = 0; i < 1 << n; ++i)
	{
		gray[i] = IntToGray(i);
		if (gray[i] == start) 
		{
			begin = i;
		}
	}

	for (var i = begin; i < 1 << n; ++i) 
	{
		result.Add(gray[i]);
	}

	for (var i = 0; i < begin; ++i) 
	{
		result.Add(gray[i]);
	}

	return result;
}

private static int IntToGray(int i)
{
	return (i >> 1) ^ i;
}

private static int GrayToInt(int gray)
{
	int i;
	for (i = 0; gray != 0; gray >>= 1) 
	{
		i ^= gray;
	}

	return i;
}