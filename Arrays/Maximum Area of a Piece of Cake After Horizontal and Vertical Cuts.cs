public class Solution 
{
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) 
    {
        const int m = 1_000_000_000 + 7;
        
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);
        
        var maxhorizontalCut = GetMaxCut(horizontalCuts, h);
        var maxverticalCut = GetMaxCut(verticalCuts, w);
        
        decimal area = (decimal)maxhorizontalCut * (decimal)maxverticalCut;
        
        return (int)(area % m);
    }
    
    private static int GetMaxCut(int[] cuts, int size)
    {
        var maxCut = cuts[0];
        
        for (var i = 1; i < cuts.Length; ++i)
            maxCut = Math.Max(maxCut, cuts[i] - cuts[i - 1]);
        
        maxCut = Math.Max(maxCut, size - cuts[cuts.Length - 1]);
        
        return maxCut;
    }
}