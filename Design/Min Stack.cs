public class MinStack 
{
    private readonly Stack<(int x, int min)> _stack = new Stack<(int, int)>();
    
    public MinStack() 
    {        
    }
    
    public void Push(int x) 
    {
        _stack.Push(
            (x, _stack.Count > 0 ? Math.Min(GetMin(), x) : x)
        );
    }
    
    public void Pop() 
    {
        if (_stack.Count > 0)
            _stack.Pop();   
    }
    
    public int Top() 
    {
        return _stack.Peek().x;
    }
    
    public int GetMin() 
    {
        return _stack.Peek().min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */