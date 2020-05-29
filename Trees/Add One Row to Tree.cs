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
    public TreeNode AddOneRow(TreeNode root, int v, int d) 
    {
        if (d == 1)
            return new TreeNode(v, root);
        
        AddOneRow(root, null, true, v, 1, d);
        
        return root;
    }
    
    private static void AddOneRow(TreeNode current, TreeNode parent, bool isLeft, int value, int currentDepth, int depth)
    {
        if (current == null && currentDepth < depth) return;
        
        if (currentDepth == depth)
        {
            var node = new TreeNode(value);            
            if (isLeft)
            {
                parent.left = node;
                node.left = current;
            }
            else
            {
                parent.right = node;
                node.right = current;
            }
        }
        else
        {
            AddOneRow(current.left, current, true, value, currentDepth + 1, depth);
            
            AddOneRow(current.right, current, false, value, currentDepth + 1, depth);
        }
    }
}