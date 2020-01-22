public sealed class TrieContainer
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

public sealed class Trie
{
	private readonly Dictionary<char, Trie> _tries = new Dictionary<char, Trie>();

	public Trie(string s)
	{
		Letter = s[0];
		Add(s);
	}

	public char Letter { get; }

	public bool IsEndOfWord { get; private set; }

	public void Add(string s)
	{
		IsEndOfWord |= s.Length == 1;

		if (s.Length > 1)
		{
			if (!_tries.TryGetValue(s[1], out var trie))
			{
				trie = new Trie(s.Substring(1));
				_tries.Add(s[1], trie);
			}
			else
			{
				trie.Add(s.Substring(1));
			}
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