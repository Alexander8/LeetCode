/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution 
{
    public ListNode RemoveZeroSumSublists(ListNode head) 
    {
        var list = new List<int>();
        
        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }
        
        var start = 0;
        
        while (start < list.Count)
        {
            var sum = 0;
            var end = -1;
            
            for (var i = start; i < list.Count; ++i)
            {
                sum += list[i];
                if (sum == 0) { end = i; break; }
            }
            
            if (end != -1)
            {
                list.RemoveRange(start, end - start + 1);
            }
            else
            {
                ++start;
            }
        }
        
        ListNode newHead = null, prev = null;
        
        foreach (var item in list)
        {
            if (newHead == null) 
            { 
                newHead = new ListNode(item);
                prev = newHead;
            }
            else
            {
                prev.next = new ListNode(item);
                prev = prev.next;
            }
        }
        
        return newHead;
    }
}