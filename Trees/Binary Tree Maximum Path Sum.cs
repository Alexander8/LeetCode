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
    private int _maxSum;
    
    public int MaxPathSum(TreeNode root) 
    {
        if (root == null) return 0;
        
        _maxSum = int.MinValue;
        
        GetSum(root);
        
        return _maxSum;
    }
    
    private int? GetSum(TreeNode root)
    {
        if (root == null) return null;
        
        var leftSum = GetSum(root.left);
        var rightSum = GetSum(root.right);
        
         _maxSum = Math.Max(_maxSum, root.val);
        
        if (leftSum.HasValue)
        {
            _maxSum = Math.Max(_maxSum, leftSum.Value);
            _maxSum = Math.Max(_maxSum, root.val + leftSum.Value);
        }
        
        if (rightSum.HasValue)
        {
            _maxSum = Math.Max(_maxSum, rightSum.Value);
            _maxSum = Math.Max(_maxSum, root.val + rightSum.Value);
        }
        
        _maxSum = Math.Max(_maxSum, root.val + (leftSum ?? 0) + (rightSum ?? 0));
        
        var maxPathSum = Math.Max((leftSum ?? 0), (rightSum ?? 0));
        
        return root.val + (maxPathSum > 0 ? maxPathSum : 0);
    }
}