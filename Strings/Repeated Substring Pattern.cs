public class Solution 
{
    public bool RepeatedSubstringPattern(string s) 
    {        
        for (var length = s.Length / 2; length >= 1; --length)
        {
            if (s.Length % length == 0)
            {
                var isEqual = true;

                for (var i = 0; i < s.Length / length - 1 && isEqual; ++i)
                {
                    for (var j = 0; j < length; ++j)
                    {
                        if (s[j] != s[j + (i + 1) * length])
                        {
                            isEqual = false;
                            break;
                        }
                    }
                }

                if (isEqual)
                    return true;
            }
        }

        return false;
    }
}