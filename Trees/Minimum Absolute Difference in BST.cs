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
    private int _min;
    private int? _prev;
    
    public int GetMinimumDifference(TreeNode root) 
    {
        _min = int.MaxValue;
        _prev = null;
        
        Walk(root);
        
        return _min;        
    }
    
    private void Walk(TreeNode root)
    {      
        if (root == null) return;
        
        Walk(root.left);
        
        if (_prev.HasValue)
            _min = Math.Min(_min, Math.Abs(root.val - _prev.Value));
        
        _prev = root.val;
        
        Walk(root.right);
    }
}