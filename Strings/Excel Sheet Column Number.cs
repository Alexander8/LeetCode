public class Solution 
{
    public int TitleToNumber(string s) 
    {
        var num = 0;

        for (var i = 0; i < s.Length; ++i)
        {
            var x = s[s.Length - 1 - i] - 'A' + 1;
            num += x * (int)Math.Pow(26, i);
        }
        
        return num;
    }
}