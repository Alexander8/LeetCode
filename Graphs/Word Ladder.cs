public class Solution 
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) 
    {
        var length = int.MaxValue;
        var visited = new HashSet<string>();
        var q = new Queue<(string word, int length)>();
        var memo = new Dictionary<string, List<string>>();
        
        visited.Add(beginWord);
        q.Enqueue((beginWord, 1));
        
        if (!wordList.Contains(beginWord))
            wordList.Add(beginWord);
        
        for (var i = 0; i < wordList.Count; ++i)
        {
             for (var j = i + 1; j < wordList.Count; ++j)
             {
                if (IsSingleDiff(wordList[i], wordList[j]))
                {
                    if (!memo.TryGetValue(wordList[i], out var lst1))
                    {
                        lst1 = new List<string>();    
                        memo.Add(wordList[i], lst1);
                    }
                    
                    lst1.Add(wordList[j]);
                    
                    if (!memo.TryGetValue(wordList[j], out var lst2))
                    {
                        lst2 = new List<string>();    
                        memo.Add(wordList[j], lst2);
                    }
                    
                    lst2.Add(wordList[i]);
                }
             }
        }

        while (q.Count > 0)
        {
            var path = q.Dequeue();
            if (string.CompareOrdinal(endWord, path.word) == 0)
            {
                length = Math.Min(length, path.length);
                continue;
            }

            var newPathLength = path.length + 1;
            
            if (memo.TryGetValue(path.word, out var neighbors))
                foreach (var neighbor in neighbors)
                    if (visited.Add(neighbor))
                        q.Enqueue((neighbor, newPathLength));
        }

        return length == int.MaxValue ? 0 : length;
    }

    private static bool IsSingleDiff(string w1, string w2)
    {
        var cnt = 0;

        for (var i = 0; i < w1.Length; ++i)
        {
            if (w1[i] != w2[i])
            {
                ++cnt;

                if (cnt > 1)
                    break;
            }           
        }

        return cnt == 1;
    }
}