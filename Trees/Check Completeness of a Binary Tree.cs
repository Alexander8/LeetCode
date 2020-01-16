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
    private static bool _hasGap = false;

    public bool IsCompleteTree(TreeNode root)
    {
        var height = GetTreeHeight(root);
        _hasGap = false;

        return IsCompleteTree(root, height);
    }

    private static int GetTreeHeight(TreeNode root)
    {
        if (root == null) return 0;

        return 1 + Math.Max(GetTreeHeight(root.left), GetTreeHeight(root.right));
    }

    private static bool IsCompleteTree(TreeNode root, int height, int currentHeight = 1)
    {
        if (root.left != null && root.right != null)
            return IsCompleteTree(root.left, height, currentHeight + 1) && IsCompleteTree(root.right, height, currentHeight + 1);

        if (root.left == null && root.right != null) return false;

        if (root.left != null && root.right == null)
        {
            if (_hasGap) return false;
            _hasGap = true;
            return currentHeight == height - 1;
        }

        if (currentHeight == height - 1)
            _hasGap = true;

        return !_hasGap && currentHeight == height || _hasGap && currentHeight == height - 1;
    }
}