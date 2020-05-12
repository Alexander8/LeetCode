public class Solution 
{
    public bool IsBipartite(int[][] graph) 
    {        
        var visited = new Dictionary<int, bool>(graph.Length);

        for (var i = 0; i < graph.Length; ++i)
            if (!visited.ContainsKey(i))
                if (!Dfs(i, true, graph, visited))
                    return false;

        return true;
    }

    private static bool Dfs(int edge, bool isInFirstSubset, int[][] graph, Dictionary<int, bool> visited)
    {
        if (visited.TryGetValue(edge, out var isInFirstSubsetTmp))
            return isInFirstSubset == isInFirstSubsetTmp;

        visited.Add(edge, isInFirstSubset);

        foreach (var e in graph[edge])
        {
            if (visited.TryGetValue(e, out isInFirstSubsetTmp))
            {
                if (isInFirstSubset != !isInFirstSubsetTmp)
                    return false;
            }
            else
            {
                if (!Dfs(e, !isInFirstSubset, graph, visited))
                    return false;
            }
        }

        return true;
    }
}