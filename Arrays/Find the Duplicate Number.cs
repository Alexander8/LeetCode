public class Solution 
{
    public int FindDuplicate(int[] nums) 
    {
        var tortoise = nums[0];
        var hare = nums[nums[0]];
        
        while (tortoise != hare)
        {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]];
        }
        
        tortoise = 0;
        
         while (tortoise != hare)
         {
            tortoise = nums[tortoise];
            hare = nums[hare];
         }
        
        return tortoise;
    }
}