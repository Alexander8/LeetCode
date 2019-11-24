public TreeNode InsertIntoMaxTree(TreeNode root, int val) 
{
    var lst = new List<int>();
    Flatten(root, lst);
    
    lst.Add(val);
    
    return BuildTree(lst);
}

private static void Flatten(TreeNode root, List<int> lst)
{
    if (root == null)
    {
        return;
    }
    
    Flatten(root.left, lst);
    
    lst.Add(root.val);
    
    Flatten(root.right, lst);
}

private static TreeNode BuildTree(List<int> lst)
{
    if (lst.Count == 0)
    {
        return null;
    }
    
    var (max, pos) = GetMax(lst);
    
    var root = new TreeNode(max);
    root.left = BuildTree(lst.Take(pos).ToList());
    root.right = BuildTree(lst.Skip(pos + 1).ToList());
    
    return root;
}

private static (int, int) GetMax(List<int> lst)
{
    var max = lst[0];
    var pos = 0;
    
    for (var i = 1; i < lst.Count; ++i)
    {
        if (lst[i] > max)
        {
            max = lst[i];
            pos = i;
        }
    }
    
    return (max, pos);
}