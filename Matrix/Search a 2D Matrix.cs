public class Solution 
{
    public bool SearchMatrix(int[][] matrix, int target) 
    {
        if (matrix.Length == 0) return false;
        
        var r = matrix.Length;
        var c = matrix[0].Length;
        
        var low = 0;
        var high = r * c - 1;
        
        while (low <= high)
        {
            var middle = low + (high - low) / 2;
            var rr = middle / c;
            var cc = middle % c;
            
            if (matrix[rr][cc] == target) return true;
            
            if (matrix[rr][cc] < target)
                low = middle + 1;
            else
                high = middle - 1;
        }      
        
        return false;
    }
}