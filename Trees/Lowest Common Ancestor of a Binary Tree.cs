public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) 
{
	if (root == null)
	{
		return null;
	}

	var pathP = new List<TreeNode>();
	var pathQ = new List<TreeNode>();

	FindPath(root, p, pathP);
	FindPath(root, q, pathQ);

	pathQ.Reverse();

	for (var i = pathP.Count - 1; i >= 0; --i)
	{
		if (pathQ.Any(qq => qq.val == pathP[i].val))
		{
			return pathP[i];
		}
	}

	return null;
}

private static void FindPath(TreeNode root, TreeNode x, List<TreeNode> path)
{        
	path.Add(root);

	if (root.val == x.val)
	{
		return;
	}

	if (root.left != null)
	{
		var cnt = path.Count;
		FindPath(root.left, x, path);

		if (path[path.Count - 1].val == x.val)
		{
			return;
		}

		path.RemoveRange(cnt, path.Count - cnt);
	}

	if (root.right != null)
	{
		var cnt = path.Count;
		FindPath(root.right, x, path);

		if (path[path.Count - 1].val == x.val)
		{
			return;
		}

		path.RemoveRange(cnt, path.Count - cnt);
	}
}