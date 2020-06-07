public class Solution 
{
    public int[] GetStrongest(int[] arr, int k) 
    {
        Array.Sort(arr);
        
        var median = arr[(arr.Length - 1 ) / 2];
        
        return arr
            .OrderByDescending(x => x, new Comparer(median))
            .Take(k)
            .ToArray();        
    }
    
    private sealed class Comparer : IComparer<int>
    {
        private readonly int _median;
        
        public Comparer(int median)
        {
            _median = median;
        }
        
        public int Compare(int a, int b)
        {
            var res = Math.Abs(a - _median) - Math.Abs(b - _median);
            if (res != 0)
                return res;
            
            return a - b;
        }
    }
}