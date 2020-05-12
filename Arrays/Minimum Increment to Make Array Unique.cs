public class Solution 
{
    public int MinIncrementForUnique(int[] A) 
    {
        var cnt = 0;
        var set = new HashSet<int>();
        
        Array.Sort(A);
        
        for (var i = 0; i < A.Length; ++i)
            set.Add(A[i]);
        
        var closest = int.MinValue;
        
        for (var i = 1; i < A.Length; ++i)
        {
            if (A[i] == A[i - 1])
            {
                closest = Math.Max(closest, A[i] + 1);
                while (set.Contains(closest))
                    closest++;
                
                cnt += closest - A[i];
                
                ++closest;
            }                
        }
        
        return cnt;
    }
}