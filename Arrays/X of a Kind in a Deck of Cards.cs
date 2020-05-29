public class Solution 
{
    public bool HasGroupsSizeX(int[] deck) 
    {
        var map = new Dictionary<int, int>();
        
        foreach (var card in deck)
        {
            var cnt = map.GetValueOrDefault(card, 0);
            map[card] = cnt + 1;
        }
        
        var gcd = -1;
        
        foreach (var count in map.Values)
            gcd = gcd == -1 ? count : GCD(gcd, count);
        
        return gcd >= 2;
    }
    
     public static int GCD(int x, int y) 
     {
        return x == 0 ? y : GCD(y % x, x);
    }
}