public class Solution 
{
    public bool SearchMatrix(int[,] matrix, int target) 
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int i = 0, j = cols - 1;
        
        while (i < rows && j >= 0)
        {
            if (matrix[i, j] == target)
                return true;
            
            if (matrix[i, j] < target)
                ++i;
            else
                --j;
        }
        return false;
    }
}