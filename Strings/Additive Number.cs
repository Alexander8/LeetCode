public class Solution 
{
    public bool IsAdditiveNumber(string num) 
    {
        var n = num.Length % 2 == 0 ? num.Length / 2 - 1 : num.Length / 2;

        for (var i = 1; i <= n; ++i)
        {
            for (var j = 1; j <= (num.Length - i) / 2; ++j)
            {
                var a = num.Substring(0, i);
                var b = num.Substring(i, j);
                var c = num.Substring(i + j);

                if (IsAdditiveNumber(a, b, c))
                    return true;
            }            
        }

        return false;
    }

    private static bool IsAdditiveNumber(string a, string b, string s)
    {        
        if (string.IsNullOrEmpty(s)) return true;
        
        if (a.Length > 1 && a.StartsWith("0") || b.Length > 1 && b.StartsWith("0") || s.Length > 1 && s.StartsWith("0"))
            return false;

        var aa = decimal.Parse(a);
        var bb = decimal.Parse(b);
        var sum = (aa + bb).ToString();

        if (!s.StartsWith(sum)) return false;

        return IsAdditiveNumber(b, sum, s.Substring(sum.Length));
    }
}