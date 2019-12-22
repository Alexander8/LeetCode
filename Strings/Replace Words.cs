public class Solution 
{
    public string ReplaceWords(IList<string> dict, string sentence) 
    {
        var tries = GetTries(dict);
        
        var list = new List<string>();
        
        var words = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var word in words)
        {
            if (!tries.TryGetValue(word[0], out var trie))
            {
                list.Add(word);
                continue;
            }
            
            if (trie.IsEndOfWord)
            {
                list.Add(word[0].ToString());
                continue;
            }
            
            GetRoot(trie, word, 1, word[0].ToString(), out var root);
            if (root != null) list.Add(root);
            else list.Add(word);
        }
        
        return string.Join(' ', list);
    }
    
    private static void GetRoot(Trie trie, string word, int i, string currentWord, out string root)
    {
        if (i == word.Length) { root = null; return; }
        
        trie = trie.Get(word[i]);
        if (trie == null) { root = null; return; }

        currentWord += word[i];

        if (trie.IsEndOfWord)
        { 
            root = currentWord;
            return; 
        }

        GetRoot(trie, word, i + 1, currentWord, out root);
    }
    
    private static Dictionary<char, Trie> GetTries(IList<string> words)
    {
        var tries = new Dictionary<char, Trie>();

        foreach (var word in words)
        {
            if (!tries.TryGetValue(word[0], out var trie))
            {
                trie = new Trie(word[0]);
                tries.Add(word[0], trie);
            }

            trie.Add(word);
        }

        return tries;
    }

    private sealed class Trie
    {
        private readonly Dictionary<char, Trie> _tries = new Dictionary<char, Trie>();

        public Trie(char letter)
        {
            Letter = letter;
        }

        public char Letter { get; }

        public bool IsEndOfWord { get; private set; }

        public void Add(string word, int i = 0)
        {
            if (!IsEndOfWord)
                IsEndOfWord = i == word.Length - 1;

            if (i + 1 < word.Length)
            {
                if (!_tries.TryGetValue(word[i + 1], out var trie))
                {
                    trie = new Trie(word[i + 1]);
                    _tries.Add(word[i + 1], trie);
                }

                trie.Add(word, i + 1);
            }
        }

        public Trie Get(char letter)
        {
            if (!_tries.TryGetValue(letter, out var trie)) return null;
            return trie;
        }
    }
}