public bool IsValidBST(TreeNode root) 
{
	if (root == null)
		return true;

	return 
		IsValidBST(root.left, long.MinValue, root.val)
		&& 
		IsValidBST(root.right, root.val, long.MaxValue);
}

private static bool IsValidBST(TreeNode root, long min, long max) 
{      
	if (root == null)
		return true;

	if (root.val <= min || root.val >= max)
		return false;

	return 
		IsValidBST(root.left, min, root.val) 
		&& 
		IsValidBST(root.right, root.val, max);
}