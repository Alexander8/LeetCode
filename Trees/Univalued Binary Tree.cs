/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution 
{
    public bool IsUnivalTree(TreeNode root) 
    {
        if (root == null) return false;
        
        return IsUnivalTree(root.left, root.val) && IsUnivalTree(root.right, root.val);
    }
    
    private static bool IsUnivalTree(TreeNode root, int val)
    {
        if (root == null) return true;
        
        if (root.val != val) return false;
        
        return IsUnivalTree(root.left, root.val) && IsUnivalTree(root.right, root.val);
    }
}