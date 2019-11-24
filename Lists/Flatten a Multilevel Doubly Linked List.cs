public Node Flatten(Node head)
{
    return Flatten(head, null);
}

public Node Flatten(Node head, Node parentNext)
{
    var tmp = head;

    while (tmp != null)
    {
        if (tmp.child != null)
        {
            var next = tmp.next;
            var child = Flatten(tmp.child, tmp.next);

            tmp.child = null;
            tmp.next = child;
            child.prev = tmp;
            
            tmp = next;
            continue;
        }

        if (tmp.next == null)
        {
            tmp.next = parentNext;
            if (parentNext != null)
            {
                parentNext.prev = tmp;
            }
            
            break;
        }

        tmp = tmp.next;
    }

    return head;
}