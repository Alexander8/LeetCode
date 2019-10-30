public ListNode MergeKLists(ListNode[] listArr)
{
    ListNode head = null;
    ListNode tmp = null;

    if (listArr.Length == 0)
    {
        return head;
    }

    var lists = new List<ListNode>(listArr.Where(x => x != null));

    while(lists.Count > 0)
    {
        int min = lists[0].val;
        var listIdx = 0;

        for (var i = 1; i < lists.Count; ++i)
        {
            if (lists[i].val < min)
            {
                min = lists[i].val;
                listIdx = i;
            }
        }

        var list = lists[listIdx];
        list = list.next;
        lists[listIdx] = list;
        if (list == null)
        {
            lists.RemoveAt(listIdx);
        }

        if (head == null)
        {
            head = new ListNode(min);
            tmp = head;
        }
        else
        {
            tmp.next = new ListNode(min);
            tmp = tmp.next;
        }
    }

    return head;
}