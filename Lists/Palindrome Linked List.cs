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
    public bool IsPalindrome(ListNode head) 
    {
        var tmp = head;
        var len = 0;
        
        while (tmp != null)
        {
            ++len;
            tmp = tmp.next;
        }
        
        if (len <= 1) return true;
        
        var i = 0;
        var secondHalfHeadIdx = len % 2 == 0 ? len / 2 : len / 2 + 1;
        ListNode secondHalf = head;
        while (i != secondHalfHeadIdx)
        {
            secondHalf = secondHalf.next;
            ++i;
        }
        
        secondHalf = Reverse(secondHalf);
        
        while (secondHalf != null)
        {
            if (head.val != secondHalf.val) return false;
            
            head = head.next;
            secondHalf = secondHalf.next;
        }
        
        return true;
    }
    
    private static ListNode Reverse(ListNode head)
    {
        var prev = head;
        var next = head.next;
        head.next = null;
        
        while (next != null)
        {
            var tmp = next.next;
            next.next = prev;
            prev = next;
            next = tmp;
        }
        
        return prev;
    }
}