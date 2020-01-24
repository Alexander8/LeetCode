public class Solution 
{
    public string AddBinary(string a, string b) 
    {
        var sb = new StringBuilder();
        
        var i = a.Length - 1;
        var j = b.Length - 1;
        var carry = 0;
              
        while (i >= 0 || j >= 0)
        {
            var res = carry;
            
            if (i >= 0) res += a[i--] - '0';
            if (j >= 0) res += b[j--] - '0';        
            
            sb.Insert(0, res % 2);
            
            carry = res / 2;
        }
        
        if (carry > 0)
            sb.Insert(0, carry);
        
        return sb.ToString();
    }
}