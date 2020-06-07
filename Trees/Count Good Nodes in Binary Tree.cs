/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution 
{
    public int GoodNodes(TreeNode root) 
    {
        return GoodNodes(root, int.MinValue);
    }
    
    private static int GoodNodes(TreeNode root, int maxSoFar) 
    {
        if (root == null) return 0;
        
        var cnt = root.val >= maxSoFar ? 1 : 0;
        
        maxSoFar = Math.Max(maxSoFar, root.val);
        
        return cnt + GoodNodes(root.left, maxSoFar) + GoodNodes(root.right, maxSoFar);
    }
}