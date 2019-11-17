public class FindElements 
{
    private TreeNode _root;
    private HashSet<int> _set = new HashSet<int>();
    
    public FindElements(TreeNode root) 
    {        
        if (root == null)
        {
            return;
        }
        
        _root = root;
        _root.val = 0;
        _set.Add(0);
        
        FindElementsInternal(root.left, 0, true);
        FindElementsInternal(root.right, 0, false);
    }
    
    private void FindElementsInternal(TreeNode root, int prev, bool left) 
    {   
        if (root == null)
        {
            return;
        }
        
        root.val = 2 * prev + (left ? 1 : 2);
        _set.Add(root.val);
        
        FindElementsInternal(root.left, root.val, true);
        FindElementsInternal(root.right, root.val, false);
    }
    
    public bool Find(int target) 
    {
        return _set.Contains(target);
    }
}