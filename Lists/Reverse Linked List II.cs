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
    public ListNode ReverseBetween(ListNode head, int m, int n)
    {
        var tmp = head;
        ListNode before = null;
        var i = 1;

        while (tmp != null)
        {
            if (i < m)
            {
                ++i;
                before = tmp;
                tmp = tmp.next;
                continue;
            }

            if (i >= n) break;

            var next = tmp.next;

            if (before == null)
            {
                tmp.next = next.next;
                next.next = head;
                head = next;
            }
            else
            {
                tmp.next = next.next;
                next.next = before.next;
                before.next = next;
            }

            ++i;
        }

        return head;
    }
}