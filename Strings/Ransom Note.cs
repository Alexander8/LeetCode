public class Solution 
{
    public bool CanConstruct(string ransomNote, string magazine) 
    {        
        var map = new int[26];
        
        for (var i = 0; i < magazine.Length; ++i)
            map[magazine[i] - 'a'] += 1;
        
        for (var i = 0; i < ransomNote.Length; ++i)
        {
            map[ransomNote[i] - 'a'] -= 1;
            if (map[ransomNote[i] - 'a'] < 0)
                return false;
        }
        
        return true;
    }
}