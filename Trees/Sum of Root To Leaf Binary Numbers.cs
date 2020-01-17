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
    public int SumRootToLeaf(TreeNode root) 
    {
        if (root == null) return 0;
        
        var sum = 0;
        SumRootToLeaf(root, 0, ref sum);
        return sum;
    }
    
    private static void SumRootToLeaf(TreeNode root, int num, ref int sum)
    {
        if (num != 0 || root.val != 0)
        {
            num <<= 1;
            num |= root.val;
        }

        if (root.left == null && root.right == null)
        {
            sum += num;
            return;
        }

        if (root.left != null) SumRootToLeaf(root.left, num, ref sum);
        if (root.right != null) SumRootToLeaf(root.right, num, ref sum);
    }
}