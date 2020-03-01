/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
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
    public bool IsSubPath(ListNode head, TreeNode root) 
    {
        return IsSubPath(root, head, head);
    }
    
    private static bool IsSubPath(TreeNode root, ListNode head, ListNode originalHead)
    {
        if (head == null) return true;
        if (root == null) return false;
        
        if (root.val == head.val)
        {
            if (IsSubPath(root.left, head.next, originalHead))
                return true;
            
            if (IsSubPath(root.right, head.next, originalHead))
                return true;
        }
        
        if (head == originalHead)
        {
            if (IsSubPath(root.left, head, originalHead))
                    return true;

            if (IsSubPath(root.right, head, originalHead))
                    return true;
        }
        
        return false;
    }
}