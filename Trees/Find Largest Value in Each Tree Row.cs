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
    public IList<int> LargestValues(TreeNode root) 
    {
        var map = new Dictionary<int, int>();
        LargestValues(root, 0, map);
        return map.OrderBy(x => x.Key).Select(x => x.Value).ToList();
    }
    
    private static void LargestValues(TreeNode root, int depth, Dictionary<int, int> map)
    {
        if (root == null) return;
        
        if (map.TryGetValue(depth, out var max))
            map[depth] = Math.Max(max, root.val);
        else
            map[depth] = root.val;
        
        LargestValues(root.left, depth + 1, map);
        LargestValues(root.right, depth + 1, map);
    }
}