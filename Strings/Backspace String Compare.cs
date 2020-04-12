public class Solution 
{
    public bool BackspaceCompare(string S, string T) 
    {
        var i = S.Length - 1;
        var j = T.Length - 1;
        
        while (i >= 0 && j >= 0)
        {                    
            i = Backspace(S, i);
            j = Backspace(T, j);
            
            if (i < 0 && j < 0) return true;
            if (i < 0 || j < 0) return false;
            
            if (S[i] != T[j]) return false;
            
            --i;
            --j;
        }
        
        i = Backspace(S, i);
        j = Backspace(T, j);
        
        return i < 0 && j < 0;
    }
    
    private static int Backspace(string s, int i)
    {
        var delete = 0;
        
        while (i >= 0 && s[i] == '#')
        {           
            while (i >= 0 && s[i] == '#')
            {
                --i;
                ++delete;
            }

            while (i >= 0 && s[i] != '#' && delete > 0)
            {
                --i;
                --delete;
            }
        }  
        
        return i;
    }
}