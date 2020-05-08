public class Solution 
{
    public bool CheckStraightLine(int[][] coordinates) 
    {
        for (var i = 2; i < coordinates.Length; ++i)
            if (!IsOnLine(coordinates[0], coordinates[1], coordinates[i]))
                return false;
        
        return true;
    }
    
    private static bool IsOnLine(int[] p1, int[] p2, int[] p3)
    {
        if (p1[0] == p2[0]) return p2[0] == p3[0];      
        if (p1[1] == p2[1]) return p2[1] == p3[1];
        
        var k = (double)(p1[1] - p2[1]) / (p1[0] - p2[0]);
        var b = p1[1] - k * p1[0];
        
        return Math.Abs(k * p3[0] + b - p3[1]) < double.Epsilon;
    }
}