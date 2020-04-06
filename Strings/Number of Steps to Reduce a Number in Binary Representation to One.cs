public class Solution 
{
    public int NumSteps(string s) 
    {
        var steps = 0;
        var sb = new StringBuilder(s);
        
        while (true)
        {
            if (sb.Length == 1 && sb[0] == '1')
                break;

            if (sb[sb.Length - 1] == '1')
            {
                var added = false;
                for (var i = sb.Length - 1; i >= 0; --i)
                {
                    if (sb[i] == '0')
                    {
                        sb[i] = '1';
                        added = true;
                        break;
                    }
                    else
                    {
                        sb[i] = '0';
                    }
                }

                if (!added)
                    sb.Insert(0, '1');

                ++steps;
            }
            else
            {
                while (sb[sb.Length - 1] == '0')
                {
                    ++steps;
                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }
        
        return steps;
    }
}