public class Solution 
{
    public int[] ClosestDivisors(int num) 
    {
        var d1 = GetDivisors(num + 1);
        var d2 = GetDivisors(num + 2);
        
        var diff1 = Math.Abs(d1.a - d1.b);
        var diff2 = Math.Abs(d2.a - d2.b);
        
        return diff1 <= diff2
            ? new[] { d1.a, d1.b }
            : new[] { d2.a, d2.b };
    }
    
    private static (int a, int b) GetDivisors(int num)
    {       
        for (var i = (int)Math.Sqrt(num); i >= 1; --i)
        {
            if (num % i == 0)
                return (i, num / i);
        }
            
        throw new Exception();
    }
}