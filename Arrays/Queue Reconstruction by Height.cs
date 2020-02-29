public class Solution 
{
    public int[][] ReconstructQueue(int[][] people) 
    {
        var res = new List<int[]>();
        var sorted = people.OrderByDescending(p => p[0]).ThenBy(p => p[1]).ToArray();
        
        for (var i = 0; i < sorted.Length; ++i)
            res.Insert(sorted[i][1], sorted[i]);
        
        return res.ToArray();
    }
}