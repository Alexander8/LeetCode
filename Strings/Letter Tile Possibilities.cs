public class Solution 
{
    public int NumTilePossibilities(string tiles)
    {
        var q = new Queue<(string str, int map)>();
        var visited = new HashSet<string>();
        
        for (var i = 0; i < tiles.Length; ++i)
            if (visited.Add(tiles[i].ToString()))             
                q.Enqueue((tiles[i].ToString(), 1 << i));
                
        while (q.Count > 0)
        {
            var item = q.Dequeue();
            
            for (var i = 0; i < tiles.Length; ++i)
            {
                var pos = 1 << i;
                
                if ((item.map & pos) == 0)
                {
                    var s = item.str + tiles[i];
                    
                    if (visited.Add(s))
                    {
                        var map = item.map | pos;
                        q.Enqueue((s, map));
                    }
                }               
            }
        }
        
        return visited.Count;
    }
}