/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution 
{
    public IList<IList<int>> LevelOrder(Node root) 
    {
        var map = new Dictionary<int, IList<int>>();
        Traverse(root, 0, map);
        return map.OrderBy(x => x.Key).Select(x => x.Value).ToList();
    }
    
    private static void Traverse(Node root, int depth, Dictionary<int, IList<int>> map)
    {
        if (root == null) return;
        
        if (!map.TryGetValue(depth, out var lst))
        {
            lst = new List<int>();
            map.Add(depth, lst);
        }
        
        lst.Add(root.val);
        
        if (root.children != null)
            foreach (var child in root.children)
                Traverse(child, depth + 1, map);
    }
}