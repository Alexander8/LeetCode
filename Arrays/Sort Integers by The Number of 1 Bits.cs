public class Solution 
{
    public int[] SortByBits(int[] arr) 
    {
        Array.Sort(arr, new Comparer());
        return arr;
    }
    
    private sealed class Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            var xBits = GetOneBits(x);
            var yBits = GetOneBits(y);
            
            return xBits == yBits ? x - y : xBits - yBits;
        }
        
        private static int GetOneBits(int x)
        {
            int cnt = 0;
            
            while (x != 0)
            {
                if ((x & 1) == 1)
                    ++cnt;
                
                x >>= 1;
            }
            
            return cnt;
        }
    }
}