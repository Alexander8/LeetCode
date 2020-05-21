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
    public IList<IList<int>> LevelOrderBottom(TreeNode root) 
    {
        var list = new List<IList<int>>();
        
        LevelOrderBottom(root, 0, list);
        
        list.Reverse();
        
        return list;
    }
    
    private static void LevelOrderBottom(TreeNode root, int depth, List<IList<int>> list)
    {
        if (root == null) return;
        
        if (list.Count < depth + 1)
            list.Add(new List<int>());
        
        LevelOrderBottom(root.left, depth + 1, list);
        
        list[depth].Add(root.val);
        
        LevelOrderBottom(root.right, depth + 1, list);            
    }
}