public class Solution 
{
    public int[] RearrangeBarcodes(int[] barcodes) 
    {
        var res = new List<int>(barcodes.Length);
        var map = new Dictionary<int, int>();
        
        foreach (var b in barcodes)
        {
            var cnt = map.GetValueOrDefault(b, 0);
            map[b] = cnt + 1;
        }
        
        var heap = new Heap(map.Count);
        foreach (var item in map)
            heap.Push((item.Key, item.Value));
        
        while (heap.Count > 0)
        {
            var firstItem = heap.Pop();
            if (res.Count > 0 && res[res.Count - 1] == firstItem.barcode)
            {
                var secondItem = heap.Pop();
                res.Add(secondItem.barcode);
                
                if (secondItem.cnt > 1)
                    heap.Push((secondItem.barcode, secondItem.cnt - 1));
                
                heap.Push(firstItem);
            }
            else
            {
                res.Add(firstItem.barcode);
            
                if (firstItem.cnt > 1)
                    heap.Push((firstItem.barcode, firstItem.cnt - 1));
            }
        }
        
        return res.ToArray();
    }
    
    private sealed class Heap
    {
        private readonly (int barcode, int cnt)[] _arr;
        private int _count;
        
        public Heap(int capacity)
        {
            _arr = new (int barcode, int cnt)[capacity];
            _count = 0;
        }
        
        public int Count => _count;
        
        public void Push((int barcode, int cnt) item)
        {       
            var i = _count;
            _arr[_count] = item;
            ++_count;
            
            while (i > 0 && _arr[i].cnt > _arr[Parent(i)].cnt)
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }
        
        public (int barcode, int cnt) Pop()
        {
            var res = _arr[0];
            
            --_count;
            _arr[0] = _arr[_count]; 
            
            Heapify(0);            
            
            return res;
        }
        
        private void Swap(int i, int j)
        {
            var tmp = _arr[i];
            _arr[i] = _arr[j];
            _arr[j] = tmp;
        }
        
        private void Heapify(int i)
        {
            var biggestIdx = i;
            var leftIdx = Left(i);
            var rightIdx = Right(i);
            
            if (leftIdx < _count && _arr[leftIdx].cnt > _arr[biggestIdx].cnt)
                biggestIdx = leftIdx;
            
            if (rightIdx < _count && _arr[rightIdx].cnt > _arr[biggestIdx].cnt)
                biggestIdx = rightIdx;
            
            if (biggestIdx != i)
            {
                Swap(i, biggestIdx);
                Heapify(biggestIdx);
            }
        }
        
        private static int Parent(int i) => (i - 1) / 2;
        
        private static int Left(int i) => 2 * i + 1;
        
        private static int Right(int i) => 2 * i + 2;
    }
}