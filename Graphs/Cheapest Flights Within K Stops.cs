Priority Queue:

public class Solution 
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
    {
        var flightsMap = new Dictionary<int, List<(int dst, int price)>>();

        foreach (var f in flights)
        {
            if (!flightsMap.TryGetValue(f[0], out var neighbors))
            {
                neighbors = new List<(int dst, int price)>();
                flightsMap.Add(f[0], neighbors);
            }

            neighbors.Add((f[1], f[2]));
        }

        var minPrice = int.MaxValue;
        var q = new Heap<(int price, int src, int k)>(new Comparer());
        var visited = new Dictionary<int, Dictionary<int, int>>();

        q.Add((0, src, -1));
        visited.Add(src, new Dictionary<int, int> { { -1, 0 }});

        while (q.Count > 0)
        {
            var p = q.Pop();

            if (p.src == dst && p.k <= K)
            {
                minPrice = Math.Min(minPrice, p.price);
                continue;
            }

            if (p.k >= K) continue;

            if (flightsMap.TryGetValue(p.src, out var neighbors))
            {
                foreach (var neighbor in neighbors)
                {
                    var next = (price: p.price + neighbor.price, dst: neighbor.dst, k: p.k + 1);

                    if (!visited.TryGetValue(next.dst, out var map))
                    {
                        map = new Dictionary<int, int> { { next.k, next.price } };
                        visited.Add(next.dst, map);
                        q.Add(next);
                        continue;
                    }

                    if (map.Any(x => x.Value <= next.price && x.Key <= next.k)) continue;

                    if (!map.TryGetValue(next.k, out var price))
                    {
                        visited[next.dst].Add(next.k, next.price);
                        q.Add(next);
                        continue;
                    }

                    if (price > next.price)
                    {
                        visited[next.dst][next.k] = price;
                        q.Add(next);
                    }
                }
            }
        }

        return minPrice == int.MaxValue ? -1 : minPrice;
    }

    private sealed class Comparer : IComparer<(int price, int src, int k)>
    {
        public int Compare((int price, int src, int k) x, (int price, int src, int k) y)
        {
            if (x.price == y.price) return x.k - y.k;
            return x.price - y.price;
        }
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

        public int Count => _size;

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

Simple BFS:

public class Solution 
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
    {
        var flightsMap = new Dictionary<int, List<(int dst, int price)>>();

        foreach (var f in flights)
        {
            if (!flightsMap.TryGetValue(f[0], out var neighbors))
            {
                neighbors = new List<(int dst, int price)>();
                flightsMap.Add(f[0], neighbors);
            }

            neighbors.Add((f[1], f[2]));
        }

        var minPrice = int.MaxValue;
        var q = new Queue<(int src, int k, int price)>();
        var visited = new Dictionary<int, Dictionary<int, int>>();

        q.Enqueue((src, -1, 0));
        visited.Add(src, new Dictionary<int, int> { { -1, 0 }});

        while (q.Count > 0)
        {
            var p = q.Dequeue();

            if (p.src == dst && p.k <= K)
            {
                minPrice = Math.Min(minPrice, p.price);
                continue;
            }

            if (p.k >= K) continue;

            if (flightsMap.TryGetValue(p.src, out var neighbors))
            {
                foreach (var neighbor in neighbors)
                {
                    var next = (dst: neighbor.dst, k: p.k + 1, price: p.price + neighbor.price);

                    if (!visited.TryGetValue(next.dst, out var map))
                    {
                        map = new Dictionary<int, int> { { next.k, next.price } };
                        visited.Add(next.dst, map);
                        q.Enqueue(next);
                        continue;
                    }

                    if (map.Any(x => x.Value <= next.price && x.Key <= next.k)) continue;

                    if (!map.TryGetValue(next.k, out var price))
                    {
                        visited[next.dst].Add(next.k, next.price);
                        q.Enqueue(next);
                        continue;
                    }

                    if (price > next.price)
                    {
                        visited[next.dst][next.k] = price;
                        q.Enqueue(next);
                    }
                }
            }
        }

        return minPrice == int.MaxValue ? -1 : minPrice;
    }
}