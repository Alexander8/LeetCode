public class Solution 
{
    private static readonly SortedList<int, List<TreeNode>> _nodes = new SortedList<int, List<TreeNode>>();
    private static readonly Dictionary<TreeNode, TreeNode> _path = new Dictionary<TreeNode, TreeNode>();
    
    public TreeNode LcaDeepestLeaves(TreeNode root) 
    {
        if (root == null) return null;
        
        _nodes.Clear();
        _path.Clear();
        
        LcaDeepestLeaves(root, 0);
        
        var maxDepth = _nodes.Keys[_nodes.Count - 1];
        
        var nodes = _nodes[maxDepth];
        if (nodes.Count == 1) return nodes[0];
        
        var path = BuildPathAsList(nodes[0]);
        
        for (var i = 1; i < nodes.Count; ++i)
        {
            var pathTmp = BuildPath(nodes[i]);
            
            while (path.Count > 0 && !pathTmp.Contains(path[0]))
                path.RemoveAt(0);
        }
        
        return path[0];
    }
    
    private static void LcaDeepestLeaves(TreeNode root, int depth) 
    {
        if (!_nodes.TryGetValue(depth, out var nodes))
        {
            nodes = new List<TreeNode>();
            _nodes.Add(depth, nodes);
        }
        
        nodes.Add(root);
        
        if (root.left != null)
        {
            _path[root.left] = root;
            LcaDeepestLeaves(root.left, depth + 1);
        }
        
        if (root.right != null)
        {
            _path[root.right] = root;
            LcaDeepestLeaves(root.right, depth + 1);
        }
    }
    
    private static List<TreeNode> BuildPathAsList(TreeNode node)
    {
        var res = new List<TreeNode>();              
        
        while (_path.TryGetValue(node, out node))
            res.Add(node);
        
        return res;
    }
    
    private static HashSet<TreeNode> BuildPath(TreeNode node)
    {
        var res = new HashSet<TreeNode>();              
        
        while (_path.TryGetValue(node, out node))
            res.Add(node);
        
        return res;
    }
}