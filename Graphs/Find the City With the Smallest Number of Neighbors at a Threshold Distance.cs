public class Solution 
{
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) 
    {
        var map = new Dictionary<int, List<(int to, int weight)>>();
        var cities = new Dictionary<int, HashSet<int>>();
        
        foreach (var edge in edges)
        {
            if (!map.TryGetValue(edge[0], out var lst1))
            {
                lst1 = new List<(int, int)>();
                map.Add(edge[0], lst1);
            }
            
            lst1.Add((edge[1], edge[2]));
            
            if (!map.TryGetValue(edge[1], out var lst2))
            {
                lst2 = new List<(int, int)>();
                map.Add(edge[1], lst2);
            }
            
            lst2.Add((edge[0], edge[2]));
        }
        
        for (var i = 0; i < n; ++i)
        {
            var neighbors = BFS(i, map, distanceThreshold);
            cities.Add(i, neighbors);
        }
        
        return cities
            .OrderBy(c => c.Value.Count)
            .ThenByDescending(c => c.Key)
            .Select(c => c.Key)
            .First();
    }
    
    private static HashSet<int> BFS(int start, Dictionary<int, List<(int to, int weight)>> map, int distanceThreshold)
    {
        var q = new Queue<(int city, int distance)>();
        var visited = new Dictionary<int, int>();
        var res = new HashSet<int>();
        
        q.Enqueue((start, 0));
        visited.Add(start, 0);
        
        while (q.Count > 0)
        {
            var point = q.Dequeue();
            
            if (point.city != start)
                res.Add(point.city);
            
            if (map.TryGetValue(point.city, out var neighbors))
            {          
                foreach (var n in neighbors)
                {
                    var distance = point.distance + n.weight;
                    if (distance <= distanceThreshold)
                    {
                        if (!visited.TryGetValue(n.to, out var currentDistance) || currentDistance > distance)
                        {
                            visited[n.to] = distance;
                            q.Enqueue((n.to, distance));
                        }
                    }
                }
            }
        }
        
        return res;
    }
}