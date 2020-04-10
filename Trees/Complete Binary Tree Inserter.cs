/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class CBTInserter 
{
    private readonly TreeNode _root;
    private int _cnt;

    public CBTInserter(TreeNode root)
    {
        _root = root;
        _cnt = GetCount(_root);
    }

    public int Insert(int v)
    {
        ++_cnt;
        return Insert(_root, v, 0, (int)Math.Log(_cnt, 2)).Value;
    }

    public TreeNode Get_root()
    {
        return _root;
    }

    private static int GetCount(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + GetCount(root.left) + GetCount(root.right);
    }

    private int? Insert(TreeNode root, int v, int currDepth, int targetDepth)
    {
        if (root == null) return null;

        if (currDepth < targetDepth - 1)
        {
            var parent = Insert(root.left, v, currDepth + 1, targetDepth);
            if (parent.HasValue)
                return parent;

            parent = Insert(root.right, v, currDepth + 1, targetDepth);
            if (parent.HasValue)
                return parent;
        }
        else
        {
            if (root.left == null)
            {
                root.left = new TreeNode(v);
                return root.val;
            }

            if (root.right == null)
            {
                root.right = new TreeNode(v);
                return root.val;
            }
        }

        return null;
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(v);
 * TreeNode param_2 = obj.Get_root();
 */