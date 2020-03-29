public class Solution 
{
    const int Base = 4;
    
    public IList<string> FindRepeatedDnaSequences(string s) 
    {
        var arr = new int[s.Length];
        var hash = new HashSet<int>();
        var res = new HashSet<string>();
        
        for (var i = 0; i < s.Length; ++i)
        {
            switch (s[i])
            {
                case 'A': arr[i] = 1; break;
                case 'C': arr[i] = 2; break;
                case 'G': arr[i] = 3; break;
                case 'T': arr[i] = 4; break;
            }
        }
        
        for (var i = 0; i < arr.Length - 9; ++i)
        {
            var h = GetHash(arr, i);
            if (!hash.Add(h))
                res.Add(s.Substring(i, 10));
        }
        
        return res.ToList();
    }
    
    private static int GetHash(int[] arr, int pos)
    {
        var hash = 0;
        
        for (var i = pos; i < pos + 10; ++i)
            hash = hash * Base + arr[i];
        
        return hash;
    }
}