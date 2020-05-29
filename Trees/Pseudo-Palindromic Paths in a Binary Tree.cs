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
    public int PseudoPalindromicPaths(TreeNode root) 
    {             
        var paths = new List<List<int>>();
        
        GetPaths(root, paths, new List<int>());
        
        var cnt = 0;
        
        foreach (var p in paths)
            if (IsPalindromic(p))
                ++cnt;
        
        return cnt;
    }
    
    private static void GetPaths(TreeNode root, List<List<int>> paths, List<int> currentPath)
    {
        if (root == null) return;
        
        currentPath.Add(root.val);
        
        if (root.left == null && root.right == null)
        {
            paths.Add(new List<int>(currentPath));
            currentPath.RemoveAt(currentPath.Count - 1);
            return;
        }
        
        GetPaths(root.left, paths, currentPath);
        
        GetPaths(root.right, paths, currentPath);
        
        currentPath.RemoveAt(currentPath.Count - 1);
    }
 
    private static bool IsPalindromic(List<int> path)
    {
        var map = new int[9];
        
        foreach (var item in path)
            map[item - 1] += 1;
        
        var hasOdd = false;
        
        foreach (var item in map)
        {
            if (item % 2 == 0)
                continue;
            
            if (hasOdd)
                return false;
            
            hasOdd = true;
        }
        
        return true;        
    }
}