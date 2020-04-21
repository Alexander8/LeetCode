/**
 * // This is BinaryMatrix's API interface.
 * // You should not implement it, or speculate about its implementation
 * class BinaryMatrix {
 *     public int Get(int x, int y) {}
 *     public IList<int> Dimensions() {}
 * }
 */

class Solution 
{
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix) 
    {
        var dims = binaryMatrix.Dimensions();
        var rows = dims[0];
        var cols = dims[1];
        var idx = int.MaxValue;
        
        for (var row = 0; row < rows; ++row)
        {
            var idxRow = FindIdx(binaryMatrix, row, cols);
            if (idxRow != -1)
                idx = Math.Min(idx, idxRow);
        }
        
        return idx == int.MaxValue ? -1 : idx;
    }
    
    private static int FindIdx(BinaryMatrix binaryMatrix, int row, int cols)
    {
        var lo = 0;
        var hi = cols - 1;
        
        while (lo <= hi)
        {
            var m = lo + (hi - lo) / 2;
            var val = binaryMatrix.Get(row, m);      
            
            if (val == 0)
                lo = m + 1;
            else
                hi = m - 1;
        }
        
        return lo < cols ? lo : -1;
    }
}

// #2
class Solution 
{
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix) 
    {
        var dims = binaryMatrix.Dimensions();
        var rows = dims[0];
        var cols = dims[1];
        var idx = -1;
        
        var startCol = cols - 1;
        
        for (var row = 0; row < rows; ++row)
        {
            for (var col = startCol; col >= 0; --col)
            {
                var val = binaryMatrix.Get(row, col);
                if (val == 1)
                {
                    idx = col;
                    --startCol;    
                }
                else
                    break;
            }    
            
            if (startCol < 0) break;
        }
        
        return idx;
    }
}