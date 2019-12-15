public int CountSquares(int[][] matrix) 
{
	var cnt = 0;
	var r = matrix.Length;
	var c = matrix[0].Length;

	var s = new int[r][];
	for (var i = 0; i < r; ++i)
		s[i] = new int[c];
  
	for (var i = 0; i < r; ++i) 
		s[i][0] = matrix[i][0]; 
  
	for (var j = 0; j < c; ++j) 
		s[0][j] = matrix[0][j]; 
	  
	for (var i = 1; i < r; ++i) 
	{ 
		for (var j = 1; j < c; ++j) 
		{ 
			if(matrix[i][j] == 1)  
				s[i][j] = Math.Min(s[i][j - 1], Math.Min(s[i - 1][j], s[i - 1][j - 1])) + 1;
			else
				s[i][j] = 0; 
		}  
	}

	for (var i = 0; i < r; ++i)
		for (var j = 0; j < c; ++j)
			cnt += s[i][j];

	return cnt;
} 