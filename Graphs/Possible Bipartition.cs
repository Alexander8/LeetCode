public class Solution 
{
    public bool PossibleBipartition(int N, int[][] dislikes) 
    {
        var edges = new Dictionary<int, List<int>>();
        var visited = new Dictionary<int, bool>();
        
        foreach (var dislike in dislikes)
        {
            if (!edges.TryGetValue(dislike[0], out var list0))
            {
                list0 = new List<int>();
                edges.Add(dislike[0], list0);
            }
            
            if (!edges.TryGetValue(dislike[1], out var list1))
            {
                list1 = new List<int>();
                edges.Add(dislike[1], list1);
            }
            
            list0.Add(dislike[1]);
            list1.Add(dislike[0]);
        }
        
        for (var i = 1; i <= N; ++i)
        {
            if (visited.ContainsKey(i)) continue;
            
            if (!DFS(i, edges, visited, true)) return false;
        }
        
        return true;
    }
    
    private static bool DFS(
        int n, 
        Dictionary<int, List<int>> edges, 
        Dictionary<int, bool> visited, 
        bool isInFirstGroup)
    {
        if (visited.TryGetValue(n, out var isInFirstGroupTmp))
            return isInFirstGroupTmp == isInFirstGroup;
        
        visited.Add(n, isInFirstGroup);
        
        if (edges.TryGetValue(n, out var list))
        {
            foreach (var item in list)
            {
                if (!DFS(item, edges, visited, !isInFirstGroup))
                    return false;
            }
        }
        
        return true;
    }
}