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
    public IList<string> BinaryTreePaths(TreeNode root) 
    {
        var res = new List<string>();
        BinaryTreePaths(root, string.Empty, res);
        return res;
    }
    
    private static void BinaryTreePaths(TreeNode root, string path, List<string> paths)
    {
        if (root == null) return;
        
        path += path == string.Empty ? root.val.ToString() : "->" + root.val;
        
        if (root.left == null && root.right == null)
            paths.Add(path);
        
        BinaryTreePaths(root.left, path, paths);
        BinaryTreePaths(root.right, path, paths);
    }
}