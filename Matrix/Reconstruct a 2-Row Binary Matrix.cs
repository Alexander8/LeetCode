public class Solution 
{
    public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum) 
    {
        var upperRow = new List<int>(colsum.Length);
        var lowerRow = new List<int>(colsum.Length);
        
        for (var i = 0; i < colsum.Length; ++i)
        {
            if (colsum[i] == 2)
            {
                upperRow.Add(1);
                lowerRow.Add(1);
                
                --upper;
                --lower;
            }
            else if (colsum[i] == 0)
            {
                upperRow.Add(0);
                lowerRow.Add(0);
            }
            else
            {
                if (upper >= lower)
                {
                    upperRow.Add(1);
                    lowerRow.Add(0);
                    --upper;
                }
                else
                {
                    upperRow.Add(0);
                    lowerRow.Add(1);
                    --lower;
                }
            }
        }
        
        if (upper != 0 || lower != 0)
            return new List<IList<int>>();
        
        return new List<IList<int>> 
        {
            upperRow,
            lowerRow
        };
    }
}