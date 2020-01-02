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
    public int DiameterOfBinaryTree(TreeNode root) 
    {
        var max = 0;
        GetLength(root, ref max);
        return max;
    }
    
    private static int GetLength(TreeNode root, ref int max)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return 1;
           
        var left = GetLength(root.left, ref max);
        var right = GetLength(root.right, ref max);
        
        max = Math.Max(max, left + right);
        
        return 1 + Math.Max(left, right);
    }
}