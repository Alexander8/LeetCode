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
    public TreeNode RemoveLeafNodes(TreeNode root, int target) 
    {
        if (CanRemove(root, target))
        {
            return null;
        }
        
        return root;
    }
    
    private static bool CanRemove(TreeNode root, int target)
    {
        if (root == null) return false;
        
        if (CanRemove(root.left, target))
            root.left = null;
        
        if (CanRemove(root.right, target))
            root.right = null;
        
        return root.left == null && root.right == null && root.val == target;
    }
}