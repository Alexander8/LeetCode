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
    public bool IsSubtree(TreeNode s, TreeNode t) 
    {        
        if (s == null)
            return false;
        
        return 
            IsSubtreeStrict(s, t) ||
            IsSubtree(s.left, t) ||
            IsSubtree(s.right, t);
    }
    
    private static bool IsSubtreeStrict(TreeNode s, TreeNode t)
    {
        if (s == null && t == null)
            return true;
        
        if (s == null || t == null)
            return false;
        
        return s.val == t.val && IsSubtreeStrict(s.left, t.left) && IsSubtreeStrict(s.right, t.right);
    }
}