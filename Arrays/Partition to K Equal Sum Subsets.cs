public class Solution 
{
    public bool CanPartitionKSubsets(int[] nums, int k) 
    {
        var sum = nums.Sum();
        if (sum % k != 0) return false;
        
        var partitions = new int[k];
        var partitionSum = sum / k;
        
        Array.Fill(partitions, partitionSum);
        
        nums = nums.OrderByDescending(x => x).ToArray(); 

        return CanPartitionKSubsets(nums, 0, partitions);
    }
    
    private static bool CanPartitionKSubsets(int[] nums, int i, int[] partitions)
    {
        if (i == nums.Length)
            return partitions.All(x => x == 0);
        
        for (var j = 0; j < partitions.Length; ++j)
        {
            if (partitions[j] - nums[i] >= 0)
            {
                partitions[j] -= nums[i];

                var canPartition = CanPartitionKSubsets(nums, i + 1, partitions);
                if (canPartition) return true;

                partitions[j] += nums[i];
            }                
        }   

        return false;
    }
}