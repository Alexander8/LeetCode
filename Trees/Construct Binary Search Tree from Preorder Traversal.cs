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
    public TreeNode BstFromPreorder(int[] preorder) 
    {
        int i = 0;
        return BstFromPreorder(preorder, ref i, int.MinValue, int.MaxValue);
    }
    
    private static TreeNode BstFromPreorder(int[] preorder, ref int i, int min, int max)
    {
        if (i == preorder.Length) return null;
        
        if (preorder[i] < min || preorder[i] > max) return null;      
        
        var root = new TreeNode(preorder[i]);
        
        ++i;
        
        root.left = BstFromPreorder(preorder, ref i, min, root.val);
        root.right = BstFromPreorder(preorder, ref i, root.val, max);
        
        return root;
    }
}