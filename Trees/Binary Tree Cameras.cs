public class Solution 
{
    private HashSet<TreeNode> _cams;
    private HashSet<TreeNode> _covered;
    private Dictionary<TreeNode, TreeNode> _path;
    
    public int MinCameraCover(TreeNode root)
    {
        _cams = new HashSet<TreeNode>();
        _covered = new HashSet<TreeNode>();
        _path = new Dictionary<TreeNode, TreeNode>();

        CalcCameraCover(root);
        return _cams.Count;
    }

    private void CalcCameraCover(TreeNode root)
    {
        if (root.left != null)
        {
            _path[root.left] = root;
            CalcCameraCover(root.left);
        }

        if (root.right != null)
        {
            _path[root.right] = root;
            CalcCameraCover(root.right);
        }

        if (_covered.Contains(root)) return;

        var parentWithoutCam = _path.TryGetValue(root, out var parent) && !_cams.Contains(parent);

        if (parentWithoutCam)
        {
            _cams.Add(parent);
            if (parent.left != null) _covered.Add(parent.left);
            if (parent.right != null) _covered.Add(parent.right);
            _covered.Add(parent);
            if (_path.ContainsKey(parent)) _covered.Add(_path[parent]);
        }
        else
        {
            _cams.Add(root);
            if (root.left != null) _covered.Add(root.left);
            if (root.right != null) _covered.Add(root.right);
            _covered.Add(root);
            if (_path.ContainsKey(root)) _covered.Add(_path[root]);
        }
    }
}