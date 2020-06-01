public class Solution 
{
    public int MinReorder(int n, int[][] connections) 
    {
        var cnt = 0;
        var q = new Queue<int>(); 
        var visited = new HashSet<int>();
        var map = new Dictionary<int, List<int>>();
        var initialMap = new Dictionary<int, HashSet<int>>();
        
        foreach (var c in connections)
        {
            if (!initialMap.TryGetValue(c[0], out var set))
            {
                set = new HashSet<int>();
                initialMap.Add(c[0], set);
            }
            
            if (!map.TryGetValue(c[0], out var lst0))
            {
                lst0 = new List<int>();
                map.Add(c[0], lst0);
            }
            
            if (!map.TryGetValue(c[1], out var lst1))
            {
                lst1 = new List<int>();
                map.Add(c[1], lst1);
            }
            
            set.Add(c[1]);
            lst0.Add(c[1]);
            lst1.Add(c[0]);
        }
        
        q.Enqueue(0);
        visited.Add(0);
        
        while (q.Count > 0)
        {
            var vertex = q.Dequeue();
            
            if (map.TryGetValue(vertex, out var lst))
            {
                foreach (var neighbor in lst)
                {
                    if (visited.Add(neighbor))
                    {
                        if (!initialMap.TryGetValue(neighbor, out var vertices) || !vertices.Contains(vertex))
                            ++cnt;
                        
                        q.Enqueue(neighbor);
                    }
                }
            }
        }
        
        return cnt;
    }
}