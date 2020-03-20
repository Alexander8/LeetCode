public class Solution 
{
    public string OriginalDigits(string s) 
    {
        var res = new List<char>();
        
        var letters = new int[26];
        
        foreach (var c in s)
            letters[c - 'a'] += 1;
        
        foreach (var digit in new[] 
            { 
                ("zero", '0'), ("two", '2'), ("six", '6'), ("four", '4'), ("eight", '8'),
                ("three", '3'),  ("one", '1'), ("five", '5'),
                ("seven", '7'), ("nine", '9')
            }
        )
        {
            while (HasDigit(digit.Item1, letters))
                res.Add(digit.Item2);
        }
        
        res.Sort();
        
        return string.Join(string.Empty, res);
    }
    
    private static bool HasDigit(string digit, int[] letters)
    {
        var hasDigit = true;

        foreach (var c in digit)
        {
            if (letters[c - 'a'] - 1 < 0)
            {
                hasDigit = false;
                break;
            }
        }
        
        if (hasDigit)
            foreach (var c in digit)
                letters[c - 'a'] -= 1;
        
        return hasDigit;
    }
}