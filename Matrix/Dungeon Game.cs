public class Solution
{
    public int CalculateMinimumHP(int[][] dungeon)
    {
        var q = new Heap<(int min, int current, int r, int c)>(
            (x, y) =>
            {
                if (x.min != y.min)
                    return x.min - y.min;

                return y.current - x.current;
            });

        var visited = new Dictionary<(int r, int c), (int min, int current)>();
        var min = int.MaxValue;

        if (dungeon[0][0] < 0)
            q.Add((-1 * dungeon[0][0] + 1, 1, 0, 0));
        else
            q.Add((1, dungeon[0][0] + 1, 0, 0));

        visited.Add((q.Peek().r, q.Peek().c), (q.Peek().min, q.Peek().current));

        while (q.Count > 0)
        {
            var cell = q.Pop();

            if (cell.r == dungeon.Length - 1 && cell.c == dungeon[cell.r].Length - 1)
                min = Math.Min(min, cell.min);

            foreach (var dir in Dirs)
            {
                var newR = cell.r + dir[0];
                var newC = cell.c + dir[1];

                if (newR == dungeon.Length || newC == dungeon[newR].Length)
                    continue;

                var newMin = cell.current + dungeon[newR][newC] <= 0
                    ? cell.min + -1 * (cell.current + dungeon[newR][newC]) + 1
                    : cell.min;

                var newCurrent = cell.current + dungeon[newR][newC] <= 0
                    ? 1
                    : cell.current + dungeon[newR][newC];

                if (!visited.TryGetValue((newR, newC), out var cached) ||
                    cached.min > newMin ||
                    cached.current < newCurrent)
                {
                    q.Add((newMin, newCurrent, newR, newC));
                    visited[(newR, newC)] = (newMin, newCurrent);
                }
            }
        }

        return min;
    }

    private static readonly int[][] Dirs =
    {
        new[] {1, 0},
        new[] {0, 1}
    };

    private sealed class Heap<TItem>
    {
        private readonly Func<TItem, TItem, int> _comparer;
        private TItem[] _arr;
        private int _size;

        public Heap(Func<TItem, TItem, int> comparer, int capacity = 2048)
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

            while (i != 0 && _comparer(_arr[Parent(i)], _arr[i]) > 0)
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
        private void Swap(int i, int j)
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

            if (l < _size && _comparer(_arr[l], _arr[i]) < 0)
                smallest = l;

            if (r < _size && _comparer(_arr[r], _arr[smallest]) < 0)
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