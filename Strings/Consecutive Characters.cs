public class Solution 
{
    public int MaxPower(string s) 
    {
        var start = 0;
        var stop = 0;
        var map = new Dictionary<char, int>();
        var len = 0;
        
        while (stop < s.Length)
        {
            var cnt = map.GetValueOrDefault(s[stop], 0);
            map[s[stop]] = cnt + 1;
            
            while (map.Count > 1)
            {
                cnt = map[s[start]];
                if (cnt > 1)
                    map[s[start]] = cnt - 1;
                else
                    map.Remove(s[start]);
                
                ++start;
            }

            len = Math.Max(len, stop - start + 1);
            ++stop;
        }
        
        return len;
    }
}