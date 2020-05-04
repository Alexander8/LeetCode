public class Solution 
{
    public IList<string> GenerateParenthesis(int n) 
    {
        var res = new List<string>();
        
        var q = new Queue<(int n, int opened, int closed, string s)>();
        q.Enqueue((n, 0, 0, string.Empty));
        
        while (q.Count > 0)
        {
            var x = q.Dequeue();
            if (x.n == 0 && x.opened == x.closed)
            {
                res.Add(x.s);
            }
            else
            {
                if (x.n > 0)
                    q.Enqueue((x.n - 1, x.opened + 1, x.closed, x.s + "("));
                
                if (x.opened > x.closed)
                    q.Enqueue((x.n, x.opened, x.closed + 1, x.s + ")"));
            }
        }
        
        return res;
    }
}