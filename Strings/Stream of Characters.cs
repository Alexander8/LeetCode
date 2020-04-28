public class StreamChecker
{
    private readonly TrieContainer _trieContainer = new TrieContainer();
    private readonly List<char> _letters = new List<char>();

    public StreamChecker(string[] words)
    {
        foreach (var w in words)
        {
            Trie trie = null;
            for (var i = w.Length - 1; i >= 0; --i)
            {
                if (trie == null)
                    trie = _trieContainer.Add(w[i], i == 0);
                else
                    trie = trie.Add(w[i], i == 0);
            }
        }
    }

    public bool Query(char letter)
    {
        _letters.Insert(0, letter);

        Trie trie = null;
        for (var i = 0; i < _letters.Count; ++i)
        {
            if (trie == null)
                trie = _trieContainer.Get(_letters[i]);
            else
                trie = trie.Get(_letters[i]);

            if (trie == null) return false;

            if (trie.IsEndOfWord) return true;
        }

        return false;
    }

    private sealed class TrieContainer
    {
        private readonly Trie[] _tries = new Trie[26];

        public Trie Add(char c, bool isEndOfWord)
        {
            if (_tries[c - 'a'] == null)
            {
                _tries[c - 'a'] = new Trie(isEndOfWord);
                return _tries[c - 'a'];
            }
            else
            {
                var trie = _tries[c - 'a'];
                trie.IsEndOfWord |= isEndOfWord;
                return trie;
            }
        }

        public Trie Get(char c)
        {
            return _tries[c - 'a'] == null ? null : _tries[c - 'a'];
        }
    }

    private sealed class Trie
    {
        private readonly Trie[] _tries = new Trie[26];

        public Trie(bool isEndOfWord)
        {
            IsEndOfWord = isEndOfWord;
        }

        public bool IsEndOfWord { get; set; }

        public Trie Add(char c, bool isEndOfWord)
        {
            if (_tries[c - 'a'] == null)
            {
                _tries[c - 'a'] = new Trie(isEndOfWord);
                return _tries[c - 'a'];
            }
            else
            {
                var trie = _tries[c - 'a'];
                trie.IsEndOfWord |= isEndOfWord;
                return trie;
            }
        }

        public Trie Get(char c)
        {
            return _tries[c - 'a'] == null ? null : _tries[c - 'a'];
        }
    }
}