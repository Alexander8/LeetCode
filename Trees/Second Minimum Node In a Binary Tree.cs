/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution 
{
    public int FindSecondMinimumValue(TreeNode root) 
    {        
        if (root == null) return -1;
        
        var min = root.val;
        var leftMin = -1;
        var rightMin = -1;
        
        GetMin(root.left, min, ref leftMin);
        GetMin(root.right, min, ref rightMin);
        
        if (leftMin != -1 && rightMin != -1)
            return Math.Min(leftMin, rightMin);
        
        if (leftMin != -1)
            return leftMin;
        
        if (rightMin != -1)
            return rightMin;
        
        return -1;
    }
    
    private static void GetMin(TreeNode root, int min, ref int secondMin)
    {
        if (root == null) return;     
        
        if (root.val != min)
            secondMin = secondMin != - 1 ? Math.Min(secondMin, root.val) : root.val;
            
        GetMin(root.left, min, ref secondMin);
        GetMin(root.right, min, ref secondMin);
    }
}
