public class Solution 
{
    public IList<int> PartitionLabels(string s) 
    {
        var res = new List<int>();
        var map = new int[26];
        var prev = 0;
        
        for (var i = 0; i < s.Length; ++i)
            map[s[i] - 'a'] = i;
        
        for (var i = 0; i < s.Length;)
        {
            if (map[s[i] - 'a'] == i)
            {
                res.Add(i - prev + 1);
                ++i;
                prev = i;
            }
            else
            {
                var start = i + 1;
                var stop = map[s[i] - 'a'];
                
                while (true)
                {
                    var nextStop = stop;
                
                    for (var j = start; j <= stop; ++j)
                        nextStop = Math.Max(nextStop, map[s[j] - 'a']);
                
                    if (nextStop == stop)
                    {
                        break;
                    }
                    else
                    {
                        start = stop + 1;
                        stop = nextStop;
                    }
                }
                
                res.Add(stop - prev + 1);
                i = stop + 1;
                prev = i;
            }
        }
        
        return res;
    }
}