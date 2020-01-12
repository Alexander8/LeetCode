public sealed class DisjointSetUnion
{
	private readonly int[] _parent;
	private readonly int[] _rank;

	public DisjointSetUnion(int size)
	{
		_parent = new int[size];
		_rank = new int[size];

		for (var i = 0; i < _parent.Length; ++i)
			_parent[i] = i;
	}

	public int Find(int x)
	{
		if (_parent[x] != x) _parent[x] = Find(_parent[x]);
		return _parent[x];
	}

	public bool Union(int x, int y)
	{
		var xr = Find(x);
		var yr = Find(y);

		if (xr == yr) return false;

		if (_rank[xr] < _rank[yr]) 
		{
			_parent[xr] = yr;
		} 
		else if (_rank[xr] > _rank[yr]) 
		{
			_parent[yr] = xr;
		} 
		else 
		{
			_parent[yr] = xr;
			_rank[xr]++;
		}

		return true;
	}
}