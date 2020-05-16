public class Solution 
{
    public bool IsValid(string s) 
    {
        var stack = new Stack<char>((s.Length + 1) / 2);
        
        foreach (var c in s)
        {
            switch (c)
            {
                case ')':
                    if (stack.Count == 0 || stack.Pop() != '(') 
                        return false;
                    continue;
                case ']':
                    if (stack.Count == 0 || stack.Pop() != '[') 
                        return false;
                    continue;
                case '}':
                    if (stack.Count == 0 || stack.Pop() != '{') 
                        return false;
                    continue;
            }
            
            stack.Push(c);
        }
        
        return stack.Count == 0;
    }
}