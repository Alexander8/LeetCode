/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec 
{

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) 
    {
        if (root == null)
        {
            return null;
        }
        
        var list = new List<int?>();
        Flatten(root, list);
        
        var sb = new StringBuilder();  
        
        foreach (var item in list)
        {
            sb.Append(item.HasValue ? item.Value.ToString() : "null");
            sb.Append(",");
        }
        
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) 
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }
        
        var nums = data
            .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s == "null" ? (int?)null : int.Parse(s))
            .ToList();
        
        var idx = 0;
        var root = nums[0].HasValue ? Fill(nums, ref idx) : null;
        
        return root;
    }
    
    private static void Flatten(TreeNode root, List<int?> list)
    {
        list.Add(root.val);        
               
        if (root.left != null)
            Flatten(root.left, list);
        else
            list.Add(null);
             
        if (root.right != null)
            Flatten(root.right, list);
        else
            list.Add(null);
    }
    
    private static TreeNode Fill(List<int?> list, ref int i)
    {
        if (i == list.Count)
        {
            return null;
        }
        
        var root = new TreeNode(list[i].Value);
        ++i;
        
        if (i < list.Count && list[i].HasValue)
            root.left = Fill(list, ref i);
        else
            ++i;
        
        if (i < list.Count && list[i].HasValue)
            root.right = Fill(list, ref i);
        else
            ++i;
        
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));