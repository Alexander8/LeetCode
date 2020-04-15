public class Solution 
{
    public int[][] MatrixBlockSum(int[][] mat, int K) 
    {
        var rowSums = new int[mat.Length][];
        var res = new int[mat.Length][];

        for (var i = 0; i < mat.Length; ++i)
        {
            rowSums[i] = new int[mat[i].Length];
            rowSums[i][0] = mat[i][0];

            for (var j = 1; j < mat[i].Length; ++j)
                rowSums[i][j] = rowSums[i][j - 1] + mat[i][j];
        }

        for (var i = 0; i < mat.Length; ++i)
        {
            res[i] = new int[mat[i].Length];

            for (var j = 0; j < mat[i].Length; ++j)
            {
                var jRight = Math.Min(mat[i].Length - 1, j + K);
                var jLeft = j - K - 1 >= 0 ? j - K - 1 : -1;

                var sum = 0;

                for (var k = Math.Max(0, i - K); k <= Math.Min(mat.Length - 1, i + K); ++k)
                {
                    sum += rowSums[k][jRight];
                    if (jLeft >= 0)
                        sum -= rowSums[k][jLeft];
                }

                res[i][j] = sum;
            }
        }

        return res;
    }
}