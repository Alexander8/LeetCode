public class Solution 
{
    public int NthSuperUglyNumber(int n, int[] primes) 
    {
        if (n == 1) return 1;

        var s = new HashSet<decimal> { 1 };
        var h = new Heap<decimal>(Comparer<decimal>.Default);
        h.Add(1);

        for (var i = 0; i < n - 1; ++i)
        {
            var min = h.Pop();

            foreach (var p in primes)
            {
                var num = min * p;

                if (!s.Contains(num))
                    h.Add(num);

                s.Add(num);
            }
        }

        return (int)h.Pop();
    }
    
    public sealed class Heap<TItem>
    {
        private readonly IComparer<TItem> _comparer;
        private TItem[] _arr;
        private int _size;

        public Heap(IComparer<TItem> comparer, int capacity = 2048)
        {
            _comparer = comparer;
            _arr = new TItem[capacity];
            _size = 0;
        }

        public void Add(TItem item)
        {
            if (_size == _arr.Length)
            {
                Resize();
            }

            ++_size;
            var i = _size - 1;
            _arr[i] = item;

            while (i != 0 && _comparer.Compare(_arr[Parent(i)], _arr[i]) > 0)
            {
                Swap(i, Parent(i));
                i = Parent(i); 
            } 
        }

        public TItem Peek() => _arr[0];

        public TItem Pop()
        {
            if (_size == 1)
            {
                --_size;
                return _arr[0];
            }

            var root = _arr[0]; 
            _arr[0] = _arr[_size - 1]; 
            --_size;
            Heapify(0); 

            return root; 
        }

        private void Resize()
        {
            var arr = new TItem[_arr.Length * 2];
            Array.Copy(_arr, arr, _arr.Length);
            _arr = arr;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private void Swap(int i , int j)
        {
            var tmp = _arr[i];
            _arr[i] = _arr[j];
            _arr[j] = tmp;
        }

        private void Heapify(int i) 
        { 
            var l = Left(i); 
            var r = Right(i); 
            var smallest = i; 

            if (l < _size && _comparer.Compare(_arr[l], _arr[i]) < 0)
                smallest = l; 

            if (r < _size && _comparer.Compare(_arr[r], _arr[smallest]) < 0)
                smallest = r; 

            if (smallest != i) 
            { 
                Swap(i, smallest); 
                Heapify(smallest); 
            } 
        } 

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private static int Parent(int i) => (i - 1) / 2;

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private static int Left(int i) => 2 * i + 1;

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private static int Right(int i) => 2 * i + 2;
    }
}

// Option 2
public class Solution 
{
	public int NthSuperUglyNumber(int n, int[] primes) 
	{
		var ugly = new int[n];
		var idx = new int[primes.Length];
	
		ugly[0] = 1;
	
		for (var i = 1; i < n; ++i) 
		{
			ugly[i] = int.MaxValue;

			for (var j = 0; j < primes.Length; ++j)
			{
				var prevNum = ugly[idx[j]];
				var candidate = primes[j] * prevNum;
				ugly[i] = Math.Min(ugly[i], candidate);
			}

			for (var j = 0; j < primes.Length; ++j) 
			{
				if (primes[j] * ugly[idx[j]] == ugly[i]) 
					idx[j]++;
			}
		}

		return ugly[n - 1];
	}
}