public class Solution 
{
    public bool HasCycle(ListNode head) 
    {        
        var slow = head;
        var fast = head?.next?.next;
        
        while (fast != null)
        {
            if (slow == fast)
                return true;
            
            slow = slow.next;
            fast = fast.next?.next;
        }
               
       return false;
    }
}