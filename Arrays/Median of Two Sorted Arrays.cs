public class Solution 
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        var first = nums1.Length <= nums2.Length ? nums1 : nums2;
        var second = nums1.Length <= nums2.Length ? nums2 : nums1;

        var lo = 0;
        var hi = first.Length;
        var partitionSize = (first.Length + second.Length + 1) / 2;

        while (lo <= hi)
        {
            var m1 = lo + (hi - lo) / 2;

            var m2 = partitionSize - m1;

            var firstLeft = m1 == 0 ? int.MinValue : first[m1 - 1];
            var firstRight = m1 == first.Length ? int.MaxValue : first[m1];
            var secondLeft = m2 == 0 ? int.MinValue : second[m2 - 1];
            var secondRight = m2 == second.Length ? int.MaxValue : second[m2];

            if (firstLeft <= secondRight && secondLeft <= firstRight)
            {  
                if ((first.Length + second.Length) % 2 == 0)
                {
                    return (Math.Max(firstLeft, secondLeft) + Math.Min(firstRight, secondRight)) / 2.0;
                }
                else
                {
                    return Math.Max(firstLeft, secondLeft);
                }
            }

            if (secondLeft > firstRight)
                lo = m1 + 1;
            else
                hi = m1 - 1;
        }

        return -1;
    }
}