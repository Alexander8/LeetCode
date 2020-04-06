public class Solution 
{    
    public IList<IList<string>> GroupAnagrams(string[] strs) 
    {
        var map = new Dictionary<string, IList<string>>();
        
        for (var i = 0; i < strs.Length; ++i)
        {
            var key = GetKey(strs[i]);
            
            if (!map.TryGetValue(key, out var lst))
            {
                lst = new List<string>();
                map.Add(key, lst);
            }
            
            lst.Add(strs[i]);
        }
        
        return map.Values.ToList();
    }
    
    private static readonly StringBuilder sb = new StringBuilder();
    
    private static string GetKey(string str)
    {
        Span<int> arr = stackalloc int[26];
        
        for (var i = 0; i < str.Length; ++i)
            arr[str[i] - 'a'] += 1;
        
        sb.Clear();
        
        for (var i = 0; i < arr.Length; ++i)
            sb.Append(arr[i] + "#");
        
        return sb.ToString();
    }
}