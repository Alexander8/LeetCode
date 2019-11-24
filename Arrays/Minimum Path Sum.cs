public int MinPathSum(int[][] grid) 
{       
	if (grid.Length == 0)
		return 0;
	
	if (grid[0].Length == 0)
		return 0;
	
	for (var i = 0; i < grid.Length; ++i)
	{
		for (var j = 0; j < grid[i].Length; ++j)
		{
			if (i == 0 && j == 0) continue;
			
			int val = grid[i][j], tmp1 = int.MaxValue, tmp2 = int.MaxValue;
			
			if (i - 1 >= 0) tmp1 = val + grid[i - 1][j];            
			if (j - 1 >= 0) tmp2 = val + grid[i][j - 1];
			
			grid[i][j] = Math.Min(tmp1, tmp2);              
		}
	}
	
	return grid[grid.Length - 1][grid[grid.Length - 1].Length - 1];
}