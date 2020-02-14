public class WordFilter 
{
    private readonly Dictionary<string, int> _map = new Dictionary<string, int>();
    private readonly string _maxWeightStr;
    private readonly TrieContainer _prefixes = new TrieContainer();
    private readonly TrieContainer _suffixes = new TrieContainer();

    public WordFilter(string[] words) 
    {
        for (var i = 0; i < words.Length; ++i)
        {
            if (_map.TryGetValue(words[i], out var weight))
                _map[words[i]] = Math.Max(weight, i);
            else
                _map[words[i]] = i;

            _prefixes.Add(words[i]);
            _suffixes.Add(Reverse(words[i]));
        }

        _maxWeightStr = words[words.Length - 1];
    }

    public int F(string prefix, string suffix) 
    {
        if (string.IsNullOrEmpty(prefix) && string.IsNullOrEmpty(suffix))
            return _map[_maxWeightStr];

        var pSet = new HashSet<string>();
        var sSet = new HashSet<string>();

        if (!string.IsNullOrEmpty(prefix))
        {
            var trie = _prefixes.Get(prefix);
            if (trie != null)
            {
                foreach (var s in trie.Suffixes)
                    pSet.Add(prefix + s);

                if (pSet.Count == 0 && trie.IsEndOfWord)
                    pSet.Add(prefix);
            }
        }

        if (!string.IsNullOrEmpty(suffix))
        {
            var reversed = Reverse(suffix);
            var trie = _suffixes.Get(reversed);
            if (trie != null)
            {
                foreach (var s in trie.Suffixes)
                    sSet.Add(Reverse(s) + suffix);

                if (sSet.Count == 0 && trie.IsEndOfWord)
                    sSet.Add(suffix);
            }
        }

        if (!string.IsNullOrEmpty(prefix) && string.IsNullOrEmpty(suffix))
            return GetMax(pSet);

        if (string.IsNullOrEmpty(prefix) && !string.IsNullOrEmpty(suffix))
            return GetMax(sSet);

        pSet.IntersectWith(sSet); 
        return GetMax(pSet);       
    }

    private int GetMax(HashSet<string> set)
    {
        if (set.Count == 0) return -1;

        return set.Select(x => _map[x]).Max();
    }

    private static string Reverse(string s)
    {
        var arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    private sealed class TrieContainer
    {
        private readonly Dictionary<char, Trie> _tries = new Dictionary<char, Trie>();

        public void Add(string s)
        {
            if (!_tries.TryGetValue(s[0], out var trie))
            {
                trie = new Trie(s);
                _tries.Add(s[0], trie);
            }
            else
            {
                trie.Add(s);
            }
        }

        public Trie Get(string s)
        {
            return _tries.TryGetValue(s[0], out var trie) ? trie.Get(s) : null;
        }
    }

    private sealed class Trie
    {
        private readonly Dictionary<char, Trie> _tries = new Dictionary<char, Trie>();
        private readonly HashSet<string> _suffixes = new HashSet<string>();

        public Trie(string s)
        {
            Letter = s[0];
            Add(s);
        }

        public char Letter { get; }

        public bool IsEndOfWord { get; private set; }

        public HashSet<string> Suffixes => _suffixes;

        public void Add(string s)
        {
            IsEndOfWord |= s.Length == 1;

            if (s.Length > 1)
            {
                var substr = s.Substring(1);

                if (!_tries.TryGetValue(s[1], out var trie))
                {
                    trie = new Trie(substr);
                    _tries.Add(s[1], trie);
                }
                else
                {
                    trie.Add(substr);
                }

                _suffixes.Add(substr);
            }
        }

        public Trie Get(string s)
        {
            if (s[0] != Letter) return null;

            if (s.Length == 1) return this;

            if (!_tries.TryGetValue(s[1], out var trie))
                return null;

            return trie.Get(s.Substring(1));
        }

        public Trie SkipHeadAndGet(string s)
        {
            if (!_tries.TryGetValue(s[0], out var trie))
                return null;

            return s.Length > 1
                ? trie.Get(s.Substring(1))
                : trie;
        }
    }
}

/**
* Your WordFilter object will be instantiated and called as such:
* WordFilter obj = new WordFilter(words);
* int param_1 = obj.F(prefix,suffix);
*/