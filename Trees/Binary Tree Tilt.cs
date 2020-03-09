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
    public int FindTilt(TreeNode root) 
    {        
        var sum = 0;
        FindTilt(root, ref sum);
        
        return sum;
    }
    
    private static int FindTilt(TreeNode root, ref int sum) 
    {
        if (root == null) return 0;
        
        var leftSum = FindTilt(root.left, ref sum);
        var rightSum = FindTilt(root.right, ref sum);
        
        sum += Math.Abs(leftSum - rightSum);
        
        return root.val + leftSum + rightSum;
    }
}