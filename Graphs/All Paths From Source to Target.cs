public class Solution 
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) 
    {        
        var q = new Queue<int>();
        var visited = new HashSet<int>();
        var paths = new Dictionary<int, List<int>>();

        q.Enqueue(0);
        visited.Add(0);
        paths[0] = new List<int>();

        while (q.Count > 0)
        {
            var p = q.Dequeue();

            if (graph[p] != null)
            {
                foreach (var n in graph[p])
                {                
                    if (!paths.TryGetValue(n, out var list))
                    {
                        list = new List<int>();
                        paths.Add(n, list);
                    }

                    list.Add(p);

                    if (visited.Add(n))
                        q.Enqueue(n);
                }
            }
        }

        if (!paths.ContainsKey(graph.Length - 1))
            return new List<IList<int>>();

        var res = new List<IList<int>> { new List<int> { graph.Length - 1 } };

        while (true)
        {
            var resTmp = new List<IList<int>>();
            var pathAdded = false;

            foreach (var option in res)
            {   
                if (paths.TryGetValue(option[0], out var items) && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        var optionTmp = new List<int>(option);
                        optionTmp.Insert(0, item);
                        resTmp.Add(optionTmp);
                    }

                    pathAdded = true;
                }
                else
                {
                    resTmp.Add(option);
                }
            }

            res = resTmp;

            if (!pathAdded)
                break;
        }

        return res;
    }
}