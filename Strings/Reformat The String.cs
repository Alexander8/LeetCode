public class Solution 
{
    public string Reformat(string s) 
    {
        var letters = s.Where(x => x >= 'a' && x <= 'z').ToArray();
        var digits = s.Where(x => x >= '0' && x <= '9').ToArray();
        
        if (Math.Abs(letters.Length - digits.Length) > 1) return string.Empty;
        
        var sb = new StringBuilder();
        var max = letters.Length >= digits.Length ? letters : digits;
        var min = letters.Length >= digits.Length ? digits : letters;
        
        for (var i = 0; i < min.Length; ++i)
        {
            sb.Append(max[i]);
            sb.Append(min[i]);
        }
        
        if (max.Length != min.Length)
            sb.Append(max[max.Length - 1]);
        
        return sb.ToString();
    }
}