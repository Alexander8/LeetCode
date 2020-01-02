public class Solution 
{
    public bool CanThreePartsEqualSum(int[] A) 
    {
        var sum = A.Sum();
        var partSum = sum / 3;
        
        if (partSum * 3 != sum) return false;
        
        var part1Sum = 0;
        var part2Sum = 0;
        var part3Sum = 0;
        var i = 0;
        
        for (; i < A.Length && part1Sum != partSum; ++i)
            part1Sum += A[i];     
        
        for (; i < A.Length && part2Sum != partSum; ++i)
            part2Sum += A[i];    
        
        for (; i < A.Length && part3Sum != partSum; ++i)
            part3Sum += A[i];
        
        return part1Sum == part2Sum && part2Sum == part3Sum && part3Sum == partSum;
    }
}