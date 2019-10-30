public int SumOfLeftLeaves(TreeNode root) 
{
    return SumOfLeftLeaves(root, false);
}

private static int SumOfLeftLeaves(TreeNode root, bool isLeft)
{
    if (root == null)
    {
        return 0;
    }
    
    if (root.left == null && root.right == null && isLeft)
    {
        return root.val;
    }        
    
    var left = SumOfLeftLeaves(root.left, true);
    var right = SumOfLeftLeaves(root.right, false);
    
    return left + right;
}
