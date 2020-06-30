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
    public int SumNumbers(TreeNode root) 
    {
        if (root == null) return 0;
        
        var nums = new List<int>();
        GetNums(root, 0, nums);        
        return nums.Sum();
    }
    
    private static void GetNums(TreeNode root, int sumSoFar, List<int> nums)
    {
        sumSoFar = sumSoFar * 10 + root.val;
        
        if (root.left != null)
            GetNums(root.left, sumSoFar, nums);
        
        if (root.right != null)
            GetNums(root.right, sumSoFar, nums);
        
        if (root.left == null && root.right == null)
            nums.Add(sumSoFar);
    }
}