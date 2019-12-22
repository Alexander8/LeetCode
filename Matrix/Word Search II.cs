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