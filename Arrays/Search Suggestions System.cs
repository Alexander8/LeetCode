public class Solution 
{
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) 
    {
        var strings = new List<IList<string>>();
        var trie = new Trie();
        
        foreach (var p in products)
            trie.Add(p);
          
        Fill(trie, searchWord, 0, strings);      

        return strings;
    }
    
    private static void Fill(Trie trie, string searchWord, int i, List<IList<string>> strings)
    {
        if (i == searchWord.Length) return;
        
        var added = false;
        
        if (trie != null)
        {    
            trie = trie.Get(searchWord[i]);
            if (trie != null)
            {
                strings.Add(trie.Words);
                added = true;
            }
        }
        
        if (!added)
            strings.Add(new List<string>());
        
        Fill(trie, searchWord, i + 1, strings);
    }
    
    private sealed class Trie
    {
        private readonly Trie[] _tries = new Trie[26];
        
        public readonly List<string> Words = new List<string>();
        
        public void Add(string w, int i = 0)
        {
            var idx = Words.BinarySearch(w);
            if (idx < 0) idx = ~idx;
            Words.Insert(idx, w);
            if (Words.Count > 3)
                Words.RemoveAt(Words.Count - 1);
            
            if (i < w.Length)
            {
                var trie = _tries[w[i] - 'a'];
                if (trie == null)
                {
                    trie = new Trie();
                    _tries[w[i] - 'a'] = trie;
                }
                
                trie.Add(w, i + 1);
            }
        }
        
        public Trie Get(char c)
        {
            return _tries[c - 'a'];
        }
    }
}