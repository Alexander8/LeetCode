public class Solution 
{
    public int MaxScore(int[] cardPoints, int k) 
    {
        var sum = cardPoints.Take(k).Sum();
        var res = sum;
        var j = cardPoints.Length - 1;
        
        for (var i = k - 1; i >= 0; --i)
        {
            sum -= cardPoints[i];
            sum += cardPoints[j];
            res = Math.Max(res, sum);         
            --j;          
        }
        
        return res;
    }
}