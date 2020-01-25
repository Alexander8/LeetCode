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
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) 
    {
        var map = new Dictionary<string, int>();
        var res = new List<TreeNode>();
        
        Walk(root, map, res);
        
        return res;
    }
    
    private static string Walk(TreeNode root, Dictionary<string, int> map, List<TreeNode> res)
    {
        if (root == null) return "n";
            
        var s = root.val + "," + Walk(root.left, map, res) + "," + Walk(root.right, map, res);
        
        if (!map.TryGetValue(s, out var cnt))
        {
            cnt = 0;
            map.Add(s, cnt);
        }
        
        map[s] = cnt + 1;
        
        if (cnt + 1 == 2)
            res.Add(root);
        
        return s;
    }
}