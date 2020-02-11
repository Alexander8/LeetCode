public class Solution 
{
    public int MinimumLengthEncoding(string[] words) 
    {        
        var len = 0;
        var sortedWords = words.OrderByDescending(w => w.Length).ToList();
        
        for (var i = 0; i < sortedWords.Count; ++i)
        {
            len += sortedWords[i].Length + 1;
            
            for (var j = i + 1; j < sortedWords.Count;)
            {
                if (sortedWords[i].EndsWith(sortedWords[j], StringComparison.Ordinal))
                    sortedWords.RemoveAt(j);
                else
                    ++j;
            }
        }
        
        return len;
    }
}