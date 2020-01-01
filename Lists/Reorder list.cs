public class Solution 
{
    public void ReorderList(ListNode head)
    {
        if (head == null) return;

        var map = new Dictionary<int, ListNode>();
        var i = -1;

        while (head != null)
        {
            ++i;
            map[i] = head;
            head = head.next;
        }

        for (var j = 0; j <= i / 2; ++j)
        {
            map[j].next = map[i - j];

            map[i - j].next = j != i/2 ? map[j + 1] : null;
        }
    }
}