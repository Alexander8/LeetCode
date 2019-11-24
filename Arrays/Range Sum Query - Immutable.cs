public class NumArray 
{
    private readonly int[] _dp;
    
    public NumArray(int[] nums) 
    {        
        if (nums.Length == 0) return;
        
        _dp = new int[nums.Length];
        
        _dp[0] = nums[0];
        
        for (var i = 1; i < nums.Length; ++i)
        {
            _dp[i] = nums[i] + _dp[i - 1];
        }
    }
    
    public int SumRange(int i, int j) 
    {
        return _dp[j] - (i >= 1 ? _dp[i - 1] : 0);
    }
}