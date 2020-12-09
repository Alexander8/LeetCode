public class BSTIterator 
{
    private readonly List<int> _values = new List<int>();
    private int _idx = 0;
    
    public BSTIterator(TreeNode root) 
    {
        FillValues(root);
    }
    
    /** @return the next smallest number */
    public int Next() 
    {
        return _values[_idx++];
    }
    
    /** @return whether we have a next smallest number */
    public bool HasNext() 
    {
        return _idx < _values.Count;
    }
    
    private void FillValues(TreeNode root) 
    {
        if (root == null) return;
        
        FillValues(root.left);
        
        _values.Add(root.val);
        
        FillValues(root.right);
    }
}

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
public class BSTIterator 
{ 
    private readonly IEnumerator<TreeNode> _nodes;
    private TreeNode _current = null;

    public BSTIterator(TreeNode root) 
    {
        _nodes = GetEnumerable(root).GetEnumerator();
    }
    
    public int Next() 
    {
        if (_current != null) 
        {
            var tmp = _current;
            _current = null;
            return tmp.val;
        }
        
        _nodes.MoveNext();
        return _nodes.Current.val;
    }
    
    public bool HasNext() 
    {
        if (_current != null) 
        {
            return true;
        }
        
        if (_nodes.MoveNext())
        {
            _current = _nodes.Current;
            return true;
        }
        
        return false;
    }
    
    private IEnumerable<TreeNode> GetEnumerable(TreeNode root) 
    {
        if (root.left != null) 
        {
            foreach (var node in GetEnumerable(root.left))
            {
                yield return node;
            }
        }
        
        yield return root;
        
        if (root.right != null) 
        {
            foreach (var node in GetEnumerable(root.right))
            {
                yield return node;
            }
        }
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
