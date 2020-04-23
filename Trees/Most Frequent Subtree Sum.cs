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
    public int[] FindFrequentTreeSum(TreeNode root) 
    {
        if (root == null) return new int[0];
        
        var map = new Dictionary<int, int>();
        
        GetSum(root, map);
        
        if (map.Count == 0) return new int[0];
        
        return map
            .GroupBy(x => x.Value)
            .OrderByDescending(gr => gr.Key)
            .First()
            .Select(gr => gr.Key)
            .ToArray();
    }
    
    private static int GetSum(TreeNode root, Dictionary<int, int> map)
    {
        if (root == null) return 0;
        
        var sum = root.val + GetSum(root.left, map) + GetSum(root.right, map);
        
        map.TryGetValue(sum, out var cnt);
        map[sum] = cnt + 1;
        
        return sum;
    }
}