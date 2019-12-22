public class Solution 
{
    public bool IsBalanced(TreeNode root) 
    {
        if (root == null) return true;
        
        int left = GetDepth(root.left);
        int right = GetDepth(root.right);
        
        return Math.Abs(left - right) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }
    
    private static int GetDepth(TreeNode root) 
    {
        if (root == null) return 0;
        return Math.Max(GetDepth(root.left), GetDepth(root.right)) + 1;
    }
}