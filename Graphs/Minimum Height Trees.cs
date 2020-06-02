public class Solution
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        var map = GetEdgesMap(edges);
        var heightCache = new Dictionary<(int vertex, int parent), int>();
        var trees = new Dictionary<int, List<int>>();
        var minHeight = int.MaxValue;

        for (var i = 0; i < n; ++i)
        {
            var height = GetHeight(i, -1, map, heightCache);

            if (height <= minHeight)
            {
                minHeight = height;

                if (!trees.TryGetValue(height, out var lst))
                {
                    lst = new List<int>();
                    trees.Add(height, lst);
                }

                lst.Add(i);
            }
        }

        return trees.TryGetValue(minHeight, out var result) ? result : new List<int>();
    }

    private static Dictionary<int, List<int>> GetEdgesMap(int[][] edges)
    {
        var map = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            if (!map.TryGetValue(edge[0], out var lst0))
            {
                lst0 = new List<int>();
                map.Add(edge[0], lst0);
            }

            if (!map.TryGetValue(edge[1], out var lst1))
            {
                lst1 = new List<int>();
                map.Add(edge[1], lst1);
            }

            lst0.Add(edge[1]);
            lst1.Add(edge[0]);
        }

        return map;
    }

    private static int GetHeight(int vertex, int parent, Dictionary<int, List<int>> edges, Dictionary<(int vertex, int parent), int> heightCache)
    {
        if (heightCache.TryGetValue((vertex, parent), out var cached)) return cached;

        var height = 0;

        if (edges.TryGetValue(vertex, out var neighbors))
        {
            foreach (var neighbor in neighbors)
            {
                if (neighbor != parent)
                    height = Math.Max(height, 1 + GetHeight(neighbor, vertex, edges, heightCache));
            }
        }

        heightCache.Add((vertex, parent), height);

        return height;
    }
}