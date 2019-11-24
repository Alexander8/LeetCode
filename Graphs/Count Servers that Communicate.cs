public int CountServers(int[][] grid) 
{
	var cnt = 0;
	var rowServers = new Dictionary<int, List<Node>>();
	var colServers = new Dictionary<int, List<Node>>();

	for (var i = 0; i < grid.Length; ++i)
	{
		for (var j = 0; j < grid[i].Length; ++j)
		{
			if (grid[i][j] != 1) continue;

			var node = new Node();

			if (!rowServers.TryGetValue(i, out var rowNodes))
			{
				rowNodes = new List<Node>();
				rowServers.Add(i, rowNodes);
			}

			if (!colServers.TryGetValue(j, out var colNodes))
			{
				colNodes = new List<Node>();
				colServers.Add(j, colNodes);
			}

			if (rowNodes.Count == 0 && colNodes.Count == 0)
			{
			}
			else
			{
				var unlinkedRowNode = rowNodes.FirstOrDefault(n => !n.IsLinked);
				var unlinkedColNode = colNodes.FirstOrDefault(n => !n.IsLinked);

				var inc = 1;
				if (unlinkedRowNode != null) ++inc;
				if (unlinkedColNode != null) ++inc;

				node.IsLinked = true;
				if (unlinkedRowNode != null) unlinkedRowNode.IsLinked = true;
				if (unlinkedColNode != null) unlinkedColNode.IsLinked = true;

				cnt = cnt + inc;
			}

			rowNodes.Add(node);
			colNodes.Add(node);
		}
	}

	return cnt;
}

private sealed class Node
{
	public bool IsLinked { get; set; }
}