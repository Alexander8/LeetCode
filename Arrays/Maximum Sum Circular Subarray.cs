public class Solution 
{
    public int MaxSubarraySumCircular(int[] A)
    {
        var sum = A.Sum();
        var negativeMaxSum = Kadane(A, -1);
        
        var res = Math.Max(Kadane(A, 1), sum + negativeMaxSum);
        return res == 0 ? A.Max() : res;
    }
    
    private static int Kadane(int[] A, int sign) 
    {
        var maxSoFar = sign * A[0];
        var max = sign * A[0];
        
        for (var i = 1; i < A.Length; ++i) 
        {
            maxSoFar = Math.Max(maxSoFar + sign * A[i], sign * A[i]);
            max = Math.Max(max, maxSoFar);
        }
        
        return max;
    }
}