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
    public bool IsValidSequence(TreeNode root, int[] arr) 
    {
        return IsValidSequence(root, arr, 0);
    }
    
    private static bool IsValidSequence(TreeNode root, int[] arr, int i)
    {
        if (root == null)
            return false;
        
        if (root.val != arr[i])
            return false;
                 
        if (i == arr.Length - 1)
            return root.left == null && root.right == null;
        
        return IsValidSequence(root.left, arr, i + 1) || IsValidSequence(root.right, arr, i + 1);
    }
}