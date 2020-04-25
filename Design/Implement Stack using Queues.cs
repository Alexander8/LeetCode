public class MyStack 
{
    private readonly Queue<int> _q1 = new Queue<int>();
    private readonly Queue<int> _q2 = new Queue<int>();
    
    private Queue<int> _first;
    private Queue<int> _second;
    
    public MyStack() 
    {        
        _first = _q1;
        _second = _q2;
    }
    
    /** Push element x onto stack. */
    public void Push(int x) 
    {
        _second.Enqueue(x);
        
        while (_first.Count > 0)
        {
            x = _first.Dequeue();
            _second.Enqueue(x);
        }
        
        var tmp = _first;
        _first = _second;
        _second = tmp;
    }
    
    /** Removes the element on top of the stack and returns that element. */
    public int Pop() 
    {
        return _first.Dequeue();
    }
    
    /** Get the top element. */
    public int Top() 
    {
        return _first.Peek();
    }
    
    /** Returns whether the stack is empty. */
    public bool Empty() 
    {
        return _first.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */