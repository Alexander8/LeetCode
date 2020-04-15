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
    public int PathSum(TreeNode root, int sum) 
    {
        var cnt = 0;

        Walk(root, new List<decimal>(), sum, ref cnt);

        return cnt;
    }

    private static void Walk(TreeNode root, List<decimal> sums, int target, ref int cnt)
    {
        if (root == null) return;

        if (sums.Count == 0)
            sums.Add(root.val);
        else
            sums.Add(root.val + sums[sums.Count - 1]);
        
        if (sums[sums.Count - 1] == target)
            ++cnt;

        for (var i = sums.Count - 2; i >= 0; --i)
            if (sums[sums.Count - 1] - sums[i] == target)
                ++cnt;

        Walk(root.left, sums, target, ref cnt);
        Walk(root.right, sums, target, ref cnt);

        sums.RemoveAt(sums.Count - 1);
    }
}