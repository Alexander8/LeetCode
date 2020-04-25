public class Solution 
{   
    public string AlphabetBoardPath(string target) 
    {
        var sb = new StringBuilder();
        var r = 0;
        var c = 0;
        
        for (var i = 0; i < target.Length; ++i)
        {
            var idx = target[i] - 'a';
            var rTmp = idx / 5;
            var cTmp = idx % 5;
            
            var dR = Math.Abs(r - rTmp);
            var dC = Math.Abs(c - cTmp);
            
            if (r != rTmp)
            {                
                if (r > rTmp)
                    sb.Append('U', dR);
                else
                {
                    if (rTmp == 5)
                        sb.Append('D', c == 0 ? dR : dR - 1);
                    else
                        sb.Append('D', dR);
                }
            }
            
            if (c != cTmp)
            {                  
                if (c > cTmp)
                    sb.Append('L', dC);
                else
                    sb.Append('R', dC);
            }  
            
            if (c != 0 && rTmp == 5)
                sb.Append('D');
                
            r = rTmp;
            c = cTmp;
            sb.Append('!');
        }
        
        return sb.ToString();
    }
}