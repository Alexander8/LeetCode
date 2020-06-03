public class Solution
{
    public int[][] DiagonalSort(int[][] mat) 
    {        
        for (var i = 0 ; i < mat.Length; ++i)
        {
            var nums = new List<int>();
            var idx = 0;
            var r = i;
            var c = 0;

            while (r < mat.Length && c < mat[r].Length)
            {
                nums.Add(mat[r][c]);
                ++r;
                ++c;
            }
            
            nums.Sort();
            
            r = i;
            c = 0;            
            
            while (r < mat.Length && c < mat[r].Length)
            {
                mat[r][c] = nums[idx++];
                ++r;
                ++c;
            }            
        }
                
        for (var i = 1; i < mat[0].Length; ++i)
        {
            var nums = new List<int>();
            var idx = 0;
            var r = 0;
            var c = i;

            while (r < mat.Length && c < mat[r].Length)
            {
                nums.Add(mat[r][c]);
                ++r;
                ++c;
            }
            
            nums.Sort();
            
            r = 0;
            c = i;
            
            while (r < mat.Length && c < mat[r].Length)
            {
                mat[r][c] = nums[idx++];
                ++r;
                ++c;
            }
        }
                
        return mat;     
    }
}