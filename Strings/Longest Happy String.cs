public class Solution 
{
    public string LongestDiverseString(int a, int b, int c) 
    {
        var h = new Heap<Node>(new Comparer());
        
        if (a > 0)
            h.Add(new Node { Letter = 'a', Cnt = a });
        
        if (b > 0)
            h.Add(new Node { Letter = 'b', Cnt = b });
        
        if (c > 0)
            h.Add(new Node { Letter = 'c', Cnt = c });
        
        var sb = new StringBuilder();
        
        while (h.Count > 0)
        {
            var firstNode = h.Pop();
            
            if (sb.Length == 0 || sb[sb.Length - 1] != firstNode.Letter)
            {
                var maxToAdd = Math.Min(firstNode.Cnt, 2);
                for (var i = 0; i < maxToAdd; ++i)
                {
                    sb.Append(firstNode.Letter);
                    --firstNode.Cnt;
                }
                
                if (firstNode.Cnt > 0)
                    h.Add(firstNode);
            }
            else
            {
                if (h.Count == 0)
                    break;
                
                var secondNode = h.Pop();
                sb.Append(secondNode.Letter);
                --secondNode.Cnt;
                
                if (secondNode.Cnt > 0) h.Add(secondNode);
                
                h.Add(firstNode);
            }
        }
        
        return sb.ToString();
    }
    
    public sealed class Node
    {
        public int Cnt;
        public char Letter;
    }
    
    public sealed class Comparer : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            return y.Cnt - x.Cnt;
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