public class Solution 
{
    public int MajorityElement(int[] nums) 
    {
        var confidence = 0;
        var res = -1;
        
        foreach (var num in nums)
        {
            if (confidence == 0)
            {
                res = num;
                ++confidence;
            }
            else
            {
                if (res == num) ++confidence;
                else --confidence;
            }
        }
        
        return res;
    }
}