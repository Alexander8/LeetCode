public class Solution 
{
    public int MaxFreq(string s, int maxLetters, int minSize, int maxSize) 
    {
        var cnt = 0;
        var map = new Dictionary<string, int>();
        
        for (var i = 0; i < s.Length - minSize + 1; ++i)
        {
            var ss = s.Substring(i, minSize);
            
            var arr = new int[26];
            var uniq = 0;
            foreach (var c in ss)
            {
                arr[c - 'a'] += 1;
                if (arr[c - 'a'] == 1) ++uniq;
            }
            
            if (uniq > maxLetters) continue;
            
            if (!map.TryGetValue(ss, out var tmp))
            {
                tmp = 1;
                map.Add(ss, tmp);
            }
            else
            {
                ++tmp;
                map[ss] = tmp;
            }
            
            cnt = Math.Max(cnt, tmp);
        }
        
        return cnt;
    }
}