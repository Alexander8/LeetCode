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
    private const int M = 1000000000 + 7;
    
    public int MaxProduct(TreeNode root) 
    {
        var map = new Dictionary<TreeNode, decimal>();
        var sum = Sum(root, map);

        decimal product = 0;
        MaxProduct(root, map, sum, ref product);
        return (int)(product % M);
    }

    private static decimal Sum(TreeNode root, Dictionary<TreeNode, decimal> map)
    {
        if (root == null) return 0m;
        var sum = root.val + Sum(root.left, map) + Sum(root.right, map);
        map[root] = sum;
        return sum;
    }

    private static void MaxProduct(TreeNode root, Dictionary<TreeNode, decimal> map, decimal sum, ref decimal product)
    {
        if (root == null) return;       

        var leftSum = root.left != null ? map[root.left] : 0m;
        var rightSum = root.right != null ? map[root.right] : 0m;
        var remaining = sum - leftSum - rightSum - root.val;

        var maxTemp = Math.Max((leftSum + root.val + remaining) * rightSum, (rightSum + root.val + remaining) * leftSum);
        product = Math.Max(product, maxTemp);

        MaxProduct(root.left, map, sum, ref product);
        MaxProduct(root.right, map, sum, ref product);
    }
}