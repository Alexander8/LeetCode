public ListNode SortList(ListNode head)
{
    if (head == null)
    {
        return null;
    }

    var lst = new List(head);
    ListNode newHead = null;
    ListNode tmp = null;

    foreach (var item in lst.OrderBy(x => x.val))
    {
        if (newHead == null)
        {
            newHead = item;
            tmp = newHead;
        }
        else
        {
            tmp.next = item;
            tmp = item;
        }
        
        tmp.next = null;
    }

    return newHead;
}

private sealed class List : IEnumerable<ListNode>
{
    private readonly ListNode _head;

    public List(ListNode head)
    {
        _head = head;
    }

    public IEnumerator<ListNode> GetEnumerator()
    {
        return new ListEnumerator(_head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

private sealed class ListEnumerator : IEnumerator<ListNode>
{
    private readonly ListNode _head;
    private bool _started = false;
    private ListNode _current = null;

    public ListEnumerator(ListNode head)
    {
        _head = head;
    }

    public bool MoveNext()
    {
        if (!_started)
        {
            _current = _head;
            _started = true;
        }
        else
        {
            _current = _current.next;
        }

        return _current != null;
    }

    public void Reset()
    {
        _current = null;
        _started = false;
    }

    object IEnumerator.Current => Current;

    public ListNode Current => _current;

    public void Dispose()
    {
    }
}