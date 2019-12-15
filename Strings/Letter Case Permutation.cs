public IList<string> LetterCasePermutation(string S) 
{
    return LetterCasePermutation(S, 0);
}

private static List<string> LetterCasePermutation(string s, int i)
{
    var res = new List<string>();
    
    if (i == s.Length - 1) 
    {
        if (s[i] >= '0' && s[i] <= '9')
           res.Add(s[i].ToString());
        else
        {
            if (char.IsLower(s[i]))
            {               
                res.Add(s[i].ToString());
                res.Add(s[i].ToString().ToUpper());
            }
            else
            {
                res.Add(s[i].ToString());
                res.Add(s[i].ToString().ToLower());
            }
        }
        
        return res;
    }
    
    if (s[i] >= '0' && s[i] <= '9')
    {
        var num = s[i];
 
        foreach (var item in LetterCasePermutation(s, i + 1))
            res.Add(num + item);
    }
    else
    {
        var isLower = char.IsLower(s[i]);
        var lower = isLower ? s[i].ToString() : s[i].ToString().ToLower();
        var upper = isLower ? s[i].ToString().ToUpper() : s[i].ToString();
        
        foreach (var item in LetterCasePermutation(s, i + 1))
        {
            res.Add(lower + item);
            res.Add(upper + item);
        }
    }
    
    return res;
}