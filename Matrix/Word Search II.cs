public class Solution 
{    
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var res = new HashSet<string>();
        var tries = GetTries(words);

        for (var i = 0; i < board.Length; ++i)
        {
            for (var j = 0; j < board[i].Length; ++j)
            {
                var list = new List<string>();
                if (!tries.TryGetValue(board[i][j], out var trie)) continue;

                var path = new HashSet<(int, int)>();
                path.Add((i, j));

                FindWords(board, (i, j), trie, path, string.Empty, list);
                res.UnionWith(list);
            }
        }

        return res.ToList();
    }

    private static void FindWords(
        char[][] board,
        (int i, int j) p,
        Trie trie,
        HashSet<(int, int)> path,
        string currentWord,
        List<string> words
    )
    {
        trie = currentWord == string.Empty ? trie : trie.Get(board[p.i][p.j]);
        if (trie == null)
            return;

        currentWord += board[p.i][p.j];

        if (trie.IsEndOfWord)
            words.Add(currentWord);

        foreach (var n in GetNeighbors(board, p))
        {
            if (path.Contains(n))
                continue;

            var pathCopy = new HashSet<(int, int)>(path);
            pathCopy.Add(n);

            FindWords(board, n, trie, pathCopy, currentWord, words);
        }
    }

    private static List<(int i, int j)> GetNeighbors(char[][] board, (int i, int j) p)
    {
        var res = new List<(int i, int j)>();

        if (p.i - 1 >= 0) res.Add((p.i - 1, p.j));
        if (p.i + 1 < board.Length) res.Add((p.i + 1, p.j));
        if (p.j - 1 >= 0) res.Add((p.i, p.j - 1));
        if (p.j + 1 < board[p.i].Length) res.Add((p.i, p.j + 1));

        return res;
    }

    private static Dictionary<char, Trie> GetTries(string[] words)
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

// #2
public class Solution 
{
    private static readonly int[][] _dirs = new int[4][]
    {
        new[] { 0, 1 },
        new[] { -1, 0 },
        new[] { 1, 0 },
        new[] { 0, -1 }
    };
    
    public IList<string> FindWords(char[][] board, string[] words) 
    {
        var foundWords = new HashSet<string>();
        var trie = new Trie();
        
        for (var i = 0; i < words.Length; ++i)
            trie.Add(words[i]);
        
        for (var i = 0; i < board.Length; ++i)
            for (var j = 0; j < board[i].Length; ++j)
                foundWords.UnionWith(FindWords(board, i, j, trie));
        
        return foundWords.ToList();
    }
    
   private static HashSet<string> FindWords(char[][] board, int r, int c, Trie trie)
    {
        var foundWords = new HashSet<string>();    
        var q = new Queue<(int r, int c, Trie trie, HashSet<(int, int)> path)>();

        q.Enqueue((r, c, trie, new HashSet<(int, int)> { (r, c) }));

        while (q.Count > 0)
        {
            var letter = q.Dequeue();
            var currentTrie = letter.trie.Get(board[letter.r][letter.c]);
            if (currentTrie == null)
                continue;

            if (currentTrie.Word != null)
                foundWords.Add(currentTrie.Word);

            for (var d = 0; d < _dirs.Length; ++d)
            {
                var rTmp = letter.r + _dirs[d][0];
                var cTmp = letter.c + _dirs[d][1];

                if (rTmp < 0 || rTmp >= board.Length || cTmp < 0 || cTmp >= board[rTmp].Length)
                    continue;

                if (currentTrie.Get(board[rTmp][cTmp]) != null && !letter.path.Contains((rTmp, cTmp)))
                {
                    var path = new HashSet<(int, int)>(letter.path);
                    path.Add((rTmp, cTmp));
                    q.Enqueue((rTmp, cTmp, currentTrie, path));
                }
            }
        }

        return foundWords;
    }
    
    private sealed class Trie
    {
        private readonly Trie[] _tries = new Trie[26];
        
        public string Word { get; private set; }
        
        public void Add(string w, int i = 0)
        {
            if (i == w.Length)
                Word = w;
            
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