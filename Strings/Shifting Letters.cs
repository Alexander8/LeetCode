Matrix / Largest 1-Bordered Square

public int Largest1BorderedSquare(int[][] grid)
{
    var maxSide = 0;

    for (var i = 0; i < grid.Length; ++i)
    {
        for (var j = 0; j < grid[i].Length; ++j)
        {
            if (grid[i][j] == 0) continue;
            maxSide = Math.Max(GetMaxSide(grid, i, j), maxSide);

            if (maxSide == grid.Length || maxSide == grid[i].Length)
                return maxSide * maxSide;
        }
    }

    return maxSide * maxSide;
}

private static int GetMaxSide(int[][] grid, int i, int j)
{
    var maxSize = Math.Min(grid.Length - i, grid[i].Length - j);

    for (; maxSize > 1; --maxSize)
    {
        var bottom = i + maxSize;
        var right = j + maxSize;

        var zeroFound = false;

        for (var iTmp = i; iTmp < bottom && !zeroFound; ++iTmp)
            if (grid[iTmp][j] == 0)
                zeroFound = true;

        for (var iTmp = i; iTmp < bottom && !zeroFound; ++iTmp)
            if (grid[iTmp][right - 1] == 0)
                zeroFound = true;

        for (var jTmp = j; jTmp < right && !zeroFound; ++jTmp)
            if (grid[i][jTmp] == 0)
                zeroFound = true;

        for (var jTmp = j; jTmp < right && !zeroFound; ++jTmp)
            if (grid[bottom - 1][jTmp] == 0)
                zeroFound = true;

        if (!zeroFound)
            return maxSize;
    }

    return maxSize;
}