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
    public TreeNode SortedArrayToBST(int[] nums) 
    {
        return SortedArrayToBST(nums, 0, nums.Length - 1);
    }
    
    private static TreeNode SortedArrayToBST(int[] nums, int left, int right) 
    {
        if (left > right) return null;

        var m = left + (right - left) / 2;
        var root = new TreeNode(nums[m]);
        root.left = SortedArrayToBST(nums, left, m - 1);
        root.right = SortedArrayToBST(nums, m + 1, right);
        return root;
    }
}