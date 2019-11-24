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
