public class Solution 
{
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) 
    {
        var result = 0;
        var mapAB = new Dictionary<int, int>();
        
        for (var i = 0; i < A.Length; ++i)
        {
            for (var j = 0; j < B.Length; ++j)
            {
                var cnt = mapAB.GetValueOrDefault(A[i] + B[j], 0);
                mapAB[A[i] + B[j]] = cnt + 1;
            }
        }
        
        for (var i = 0; i < C.Length; ++i)
        {
            for (var j = 0; j < D.Length; ++j)
            {
                var sum = C[i] + D[j];
                result += mapAB.GetValueOrDefault(-sum, 0);
            }
        }
        
        return result;
    }
}