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
    public int WidthOfBinaryTree(TreeNode root) 
    {
        if (root == null) return 0;

        var width = 1;
        var map = new Dictionary<int, int>();
        
        WidthOfBinaryTree(root, 0, 1, map, ref width);
        return width;
    }
    
    private static void WidthOfBinaryTree(TreeNode root, int level, int idx, Dictionary<int, int> map, ref int width)
    {
        if (!map.ContainsKey(level))
            map[level] = idx;
        
        width = Math.Max(width, idx - map[level] + 1);
        
        idx *= 2;             
        
        if (root.left != null)
            WidthOfBinaryTree(root.left, level + 1, idx - 1, map, ref width);
        
        if (root.right != null)
            WidthOfBinaryTree(root.right, level + 1, idx, map, ref width);
    }
}