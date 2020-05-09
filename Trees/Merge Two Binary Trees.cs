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
    public TreeNode MergeTrees(TreeNode t1, TreeNode t2) 
    {
        if (t1 == null && t2 == null) return null;
        
        return new TreeNode(
            (t1?.val ?? 0) + (t2?.val ?? 0),
            MergeTrees(t1?.left, t2?.left),
            MergeTrees(t1?.right, t2?.right)
        );
    }
}