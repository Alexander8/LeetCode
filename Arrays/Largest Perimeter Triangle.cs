public class Solution 
{
    public int LargestPerimeter(int[] A) 
    {
        Array.Sort(A);
        
        int a = A[A.Length - 1], b = A[A.Length - 2], c = A[A.Length - 3];
        int i = A.Length - 4;
        
        while (a >= b + c && i >= 0)
        {
            a = b;
            b = c;
            c = A[i];
            
            --i;
        }
        
        return a < b + c ? a + b + c : 0;
    }
}