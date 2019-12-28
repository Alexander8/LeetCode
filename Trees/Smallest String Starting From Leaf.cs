public class Solution 
{
    private string _str = string.Empty;
    
    public string SmallestFromLeaf(TreeNode root) 
    {
        if (root == null) return _str;
        
        FindStrings(root, new List<char>());
        
        return _str;
    }
    
    private void FindStrings(TreeNode root, List<char> letters)
    {
        letters.Add((char)('a' + root.val));
        
        if (root.left == null && root.right == null)
        {
            letters.Reverse();
            var str = new string(letters.ToArray());
            
            if (_str == string.Empty) _str = str;
            else if (string.CompareOrdinal(str, _str) < 0) _str = str;
        }
        
        if (root.left != null)
            FindStrings(root.left, new List<char>(letters));
        
        if (root.right != null)
            FindStrings(root.right, new List<char>(letters));
    }
}