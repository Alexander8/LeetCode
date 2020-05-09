public class Solution 
{
    public int MinDeletionSize(string[] A) 
    {
        var indices = new HashSet<int>();
        
        while (true)
        {
            var prevCnt = indices.Count;
            
            for (var i = 1; i < A.Length; ++i)
            {
                var greaterIdx = GetGreaterIdx(A[i - 1], A[i], indices);
                if (greaterIdx != -1)
                {                    
                    indices.Add(greaterIdx);

                    if (indices.Count == A[i - 1].Length)
                        return indices.Count;
                    else
                        break;
                }
            }
            
            if (indices.Count == prevCnt)
                break;
        }
        
        return indices.Count;
    }
    
    private static int GetGreaterIdx(string s1, string s2, HashSet<int> skipIndices)
    {
        for (var i = 0; i < s1.Length; ++i)
        {
            if (skipIndices.Contains(i))
                continue;
            
            if (s1[i] == s2[i]) continue;
            
            if (s1[i] > s2[i]) return i;
            
            return -1;
        }
        
        return -1;
    }
}