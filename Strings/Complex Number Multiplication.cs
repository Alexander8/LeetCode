public class Solution 
{
    public string ComplexNumberMultiply(string a, string b) 
    {
        var f = Parse(a);
        var s = Parse(b);
        var p = (a: f.a * s.a - f.b * s.b, b: f.a * s.b + s.a * f.b);
        
        return p.a + "+" + p.b + "i";
    }
    
    private static (int a, int b) Parse(string s)
    {
        int a = 0, b = 0;
        
        var parts = s.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
        
        if (parts.Length == 2)
            a = int.Parse(parts[0]);
        
        var parts2 = parts.Length == 2 
            ? parts[1].Split(new[] { 'i' }, StringSplitOptions.RemoveEmptyEntries)
            : parts[0].Split(new[] { 'i' }, StringSplitOptions.RemoveEmptyEntries);
        
        b = int.Parse(parts2[0]);
        
        return (a, b);
    }
}