/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution 
{
    public ListNode DeleteDuplicates(ListNode head) 
    {        
        head = GetFirstUniqueNode(head);
        
        var prev = head;
        var next = prev?.next;
        
        while (next != null)
        {
            var nextTmp = GetFirstUniqueNode(next);
            if (nextTmp != next)  
            {
                next = nextTmp;
                prev.next = next;
            }
            
            prev = next;
            next = next?.next;
        }
        
        return head;
    }
    
    private static ListNode GetFirstUniqueNode(ListNode node)
    {
        while (node != null && node.val == node.next?.val)
        {
            var val = node.val;
            while (node != null && node.val == val)
                node = node.next;
        }
        
        return node;
    }
}