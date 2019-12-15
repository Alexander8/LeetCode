public class Solution 
{
    public int MaxSideLength(int[][] mat, int threshold) 
    {
        var side = 0;

        for (var i = 0; i < mat.Length; ++i)
        {
            for (var j = 0; j < mat[i].Length; ++j)
            {
                side = Math.Max(side, GetSide(mat, threshold, i, j, side));
            }
        }

        return side;
    }

    private static int GetSide(int[][] mat, long threshold, int i, int j, int maxSoFar)
    {
        var maxSide = Math.Min(mat.Length - i, mat[i].Length - j);
        var side = Math.Max(1, maxSoFar);

        if (side > maxSide) return 0;

        for (; side <= maxSide; ++side)
        {
            long sum = 0L;

            for (var a = i; a < i + side; ++a)
            {
                for (var b = j; b < j + side; ++b)
                {
                    sum += mat[a][b];
                    if (sum > threshold) break;
                }

                if (sum > threshold) break;
            }

            if (sum > threshold)
            {
                if (side > 1) return side - 1;
                else return 0;
            }
        }

        return side - 1;
    }
}