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
    private readonly Random _rand = new Random();
    private readonly ListNode _head;
    private readonly int _len;
    
    public Solution(ListNode head) 
    {
        _head = head;        
    }
    
    /** Returns a random node's value. */
    public int GetRandom() 
    {        
        var res = -1;
        var tmp = _head;
        
        for (var i = 0; tmp != null; ++i)
        {
            if (_rand.Next(i + 1) == i) 
                res = tmp.val;
            
            tmp = tmp.next;
        }
        
        return res;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */