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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) 
    {
        var map = new Dictionary<int, List<int>>();
        var res = new List<IList<int>>();
        
        Walk(root, 0, map);
        
        for (var i = 0; ; ++i)
        {
            if (!map.TryGetValue(i, out var lst))
                break;
            
            if (i % 2 != 0)
                lst.Reverse();

            res.Add(lst);
        }
        
        return res;
    }
    
    private static void Walk(TreeNode root, int depth, Dictionary<int, List<int>> map)
    {
        if (root == null) return;
        
        Walk(root.left, depth + 1, map);
        
        if (!map.TryGetValue(depth, out var lst))
        {
            lst = new List<int>();
            map.Add(depth, lst);
        }        
        
        lst.Add(root.val);
        
        Walk(root.right, depth + 1, map);
    }
}