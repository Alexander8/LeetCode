public class Solution 
{
    public string MinRemoveToMakeValid(string s) 
    {
        var sb = new StringBuilder(s);
        var stack = new Stack<int>();
        
        for (var i = 0; i < sb.Length;)
        {
            if (sb[i] == '(')
            {
                stack.Push(i);
                ++i;
            }
            else if (sb[i] == ')')
            {
                if (stack.Count == 0) 
                {
                    sb.Remove(i, 1);
                }
                else 
                {
                    stack.Pop();
                    ++i;
                }
            }
            else
            {
                ++i;
            }
        }
        
        while (stack.Count > 0)
        {
            var i = stack.Pop();
            sb.Remove(i, 1);
        }
        
        return sb.ToString();
    }
}