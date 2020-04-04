/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution 
{
    public Node Connect(Node root) 
    {
        var map = new Dictionary<int, List<Node>>();
        
        Walk(root, 0, map);
        
        for (var i = 0; ; ++i)
        {
            if (!map.TryGetValue(i, out var lst))
                break;
            
            for (var j = 0; j < lst.Count - 1; ++j)
                lst[j].next = lst[j + 1];
        }
        
        return root;
    }
    
    private static void Walk(Node root, int depth, Dictionary<int, List<Node>> map)
    {
        if (root == null) return;
        
        Walk(root.left, depth + 1, map);
        
        if (!map.TryGetValue(depth, out var lst))
        {
            lst = new List<Node>();
            map.Add(depth, lst);
        }        
        
        lst.Add(root);
        
        Walk(root.right, depth + 1, map);
    }
}