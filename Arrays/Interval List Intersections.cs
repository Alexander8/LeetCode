public class Solution 
{
    public int[][] IntervalIntersection(int[][] A, int[][] B) 
    {
        var res = new List<int[]>();
        if (A.Length == 0 || B.Length == 0)
            return res.ToArray();
        
        var i = 0;
        var j = 0;
        
        while (i < A.Length && j < B.Length)
        {
            if (A[i][1] < B[j][0])
            {
                ++i;
                continue;
            }
            
            if (B[j][1] < A[i][0])
            {
                ++j;
                continue;
            }
            
            var x = Math.Max(A[i][0], B[j][0]);
            var y = Math.Min(A[i][1], B[j][1]);
            
            res.Add(new[] { x, y });
            
            if (A[i][1] < B[j][1])
                ++i;
            else
                ++j;
        }
        
        return res.ToArray();
    }
}