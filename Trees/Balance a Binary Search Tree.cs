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
    public TreeNode BalanceBST(TreeNode root) 
    {
        var sorted = new List<TreeNode>();
        Fill(sorted, root);
        
        return BuildBalanced(sorted, 0, sorted.Count - 1);
    }
    
    private static void Fill(List<TreeNode> sorted, TreeNode root)
    {
        if (root == null)
            return;
        
        Fill(sorted, root.left);
        
        sorted.Add(root);
        
        Fill(sorted, root.right);       
    }
    
    private static TreeNode BuildBalanced(List<TreeNode> sorted, int left, int right)
    {
        if (left > right) return null;
        
        var middle = left + (right - left) / 2;
        
        var root = sorted[middle];
        
        root.left = BuildBalanced(sorted, left, middle - 1);
        root.right = BuildBalanced(sorted, middle + 1, right);
        
        return root;
    }
}