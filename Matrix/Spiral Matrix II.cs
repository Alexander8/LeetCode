public int[][] GenerateMatrix(int n) 
{
	var res = new int[n][];
	var num = 0;
	
	for (var i = 0; i < n; ++i)
		res[i] = new int[n];
   
	for (var i = 0; i < n; ++i)
	{
		GoForward(res, i, i, n - i - 1, ref num);
		if (i == n - i - 1) break;
		
		GoDown(res, n - i - 1, i + 1, n - i - 1, ref num);    
		
		GoRight(res, n - i - 1, n - i - 2, i, ref num);
		if (n - i - 2 == i) break;
		
		GoUp(res, i, n - i - 2, i + 1, ref num);            
		
	}
	
	return res;
}

private static void GoForward(int[][] res, int row, int colStart, int colEnd, ref int num)
{
	for (var i = colStart; i <= colEnd; ++i)
		res[row][i] = ++num;
}

private static void GoDown(int[][] res, int col, int rowStart, int rowEnd, ref int num)
{
	for (var i = rowStart; i <= rowEnd; ++i)
		res[i][col] = ++num;
}

private static void GoRight(int[][] res, int row, int colStart, int colEnd, ref int num)
{
	for (var i = colStart; i >= colEnd; --i)
		res[row][i] = ++num;
}

private static void GoUp(int[][] res, int col, int rowStart, int rowEnd, ref int num)
{
	for (var i = rowStart; i >= rowEnd; --i)
		res[i][col] = ++num;
}