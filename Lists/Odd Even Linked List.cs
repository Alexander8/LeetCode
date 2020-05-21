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
    public ListNode OddEvenList(ListNode head) 
    {
        ListNode odd = null, oddTmp = null;
        ListNode even = null, evenTmp = null;
        
        while (head != null)
        {
            if (odd == null) { odd = head; oddTmp = odd; }
            else { oddTmp.next = head; oddTmp = oddTmp.next; }
            
            if (even == null) { even = head.next; evenTmp = even; }
            else if (evenTmp != null) { evenTmp.next = head.next; evenTmp = evenTmp.next; }
            
            head = head.next;
            head = head?.next;
        }
        
        if (oddTmp != null)
            oddTmp.next = even;
        
        return odd;
    }
}