public class Solution 
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) 
    {
        int lenA = GetLength(headA), lenB = GetLength(headB);

        while (lenA > lenB) 
        {
            headA = headA.next;
            lenA--;
        }
        
        while (lenA < lenB) 
        {
            headB = headB.next;
            lenB--;
        }
        
        while (headA != headB) 
        {
            headA = headA.next;
            headB = headB.next;
        }
        
        return headA;
    }

    private static int GetLength(ListNode node) 
    {
        var length = 0;
        while (node != null) 
        {
            node = node.next;
            length++;
        }
        
        return length;
    }
}