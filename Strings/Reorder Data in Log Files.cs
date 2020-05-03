public class Solution 
{
    public string[] ReorderLogFiles(string[] logs) 
    {
        var letterLogs = new List<string>(logs.Length);
        var digitLogs = new List<string>();
        var comparer = new Comparer();
        
        foreach (var log in logs)
        {
            var firstSpace = log.IndexOf(' ');
            var secondSpace = log.IndexOf(' ', firstSpace + 1);
            var word = secondSpace != -1 
                ? log.Substring(firstSpace + 1, secondSpace - firstSpace - 1)
                : log.Substring(firstSpace + 1);

            var isDigit = word.All(c => c >= '0' && c <= '9');
            if (isDigit)
            {
                digitLogs.Add(log);
            }
            else
            {
                var idx = letterLogs.BinarySearch(log, comparer);
                if (idx < 0) idx = ~idx;
                letterLogs.Insert(idx, log);
            }
        }
        
        letterLogs.AddRange(digitLogs);
        
        return letterLogs.ToArray();
    }
    
    private sealed class Comparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            var idx = a.IndexOf(' ');
            var aId = a.Substring(0, idx);            
            var aWithoutId = a.Substring(idx + 1);   
            
            idx = b.IndexOf(' ');
            var bId = b.Substring(0, idx);            
            var bWithoutId = b.Substring(idx + 1);  
            
            var res = string.CompareOrdinal(aWithoutId, bWithoutId);
            if (res != 0) return res;
            
            return string.CompareOrdinal(aId, bId);
        }
    }
}