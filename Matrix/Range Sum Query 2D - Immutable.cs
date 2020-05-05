public class NumMatrix 
{
    private readonly int[,] _dp;
    
    public NumMatrix(int[][] matrix) 
    {        
        _dp = new int[matrix.Length + 1, matrix.Length == 0 ? 1 : matrix[0].Length + 1];     
        
        for (var i = 0; i < matrix.Length; ++i)
            for (var j = 0; j < matrix[i].Length; ++j)
                _dp[i + 1, j + 1] = _dp[i, j + 1] + _dp[i + 1, j] + matrix[i][j] - _dp[i, j];
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) 
    {
        return _dp[row2 + 1, col2 + 1] - _dp[row1, col2 + 1] - _dp[row2 + 1, col1] + _dp[row1, col1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */