public class Solution 
{
    public int MinTime(int n, int[][] edges, IList<bool> hasApple) 
    {
        var edgesMap = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            if (!edgesMap.TryGetValue(edge[0], out var list))
            {
                list = new List<int>();
                edgesMap.Add(edge[0], list);
            }

            list.Add(edge[1]);
        }

        return MinTime(0, edgesMap, hasApple);
    }   

    private static int MinTime(int current, Dictionary<int, List<int>> edgesMap, IList<bool> hasApple)
    {
        if (!edgesMap.TryGetValue(current, out var list))    
            return hasApple[current] ? 1 : 0;

        var time = 0;

        foreach (var neighbor in list)
        {
            var timeTmp = MinTime(neighbor, edgesMap, hasApple);
            if (timeTmp > 0)
                time += timeTmp + 1;
        }

        if ((time > 0 || hasApple[current]) && current != 0)
            time += 1;

        return time;
    }    
}