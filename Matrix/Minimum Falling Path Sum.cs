Matrix / Minimum Falling Path Sum

public int MinFallingPathSum(int[][] A) 
{
    var rows = A.Length;
    var cols = A[0].Length;
    
    var dp = new int[rows, cols];
    
    for (var i = rows - 1; i >= 0; --i)
    {
        for (var j = 0; j < cols; ++j)
        {
            dp[i, j] = i + 1 < rows 
                ? GetMin(dp, i + 1, j, cols) + A[i][j]
                : A[i][j];
        }
    }      
    
    var min = int.MaxValue;
    
    for (var i = 0; i < cols; ++i)
        min = Math.Min(min, dp[0, i]);

    return min;
}

private static int GetMin(int[,] dp, int i, int j, int totalCols)
{
    var cols = new[] { -1, 0, 1 };        
    var min = int.MaxValue;
    
    foreach (var c in cols)
    {
        var col = j + c;
        if (col < 0 || col >= totalCols)
            continue;
        
        min = Math.Min(min, dp[i, col]);
    }
    
    return min;
}