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
    public int KthSmallest(TreeNode root, int k) 
    {
        var kCurr = 0;
        var elem = 0;
        GetKthSmallest(root, k, ref kCurr, ref elem);
        
        return elem;
    }
    
    private static void GetKthSmallest(TreeNode root, int k, ref int kCurr, ref int elem) 
    {
        if (kCurr == k) return;
        if (root == null) return;
        
        GetKthSmallest(root.left, k, ref kCurr, ref elem);
        
        ++kCurr;
        if (kCurr == k) elem = root.val;
        
        GetKthSmallest(root.right, k, ref kCurr, ref elem);
    }
}