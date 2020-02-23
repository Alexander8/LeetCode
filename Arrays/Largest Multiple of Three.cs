public class Solution 
{
    public string LargestMultipleOfThree(int[] digits) 
    {
        var combined = new List<int>();
        var nums2 = new List<int>();
        var nums1 = new List<int>();
        var zeros = 0;
        
        foreach (var num in digits)
        {
            if (num == 0)
                ++zeros;
            else if (num % 3 == 0)
                combined.Add(num);
            else if (num % 3 == 2)
                nums2.Add(num);
            else
                nums1.Add(num);            
        }
        
        var comparer = new Comparer();
        nums2.Sort(comparer);
        nums1.Sort(comparer);
        
        int i2 = 0, i1 = 0;
        
        while (true)
        {
            var hasRow2 = i2 + 2 < nums2.Count && (nums2[i2] + nums2[i2 + 1] + nums2[i2 + 2]) % 3 == 0;
            var hasRow1 = i1 + 2 < nums1.Count && (nums1[i1] + nums1[i1 + 1] + nums1[i1 + 2]) % 3 == 0;
            
            if (hasRow2 && i1 >= nums1.Count - 1)
            {
                combined.Add(nums2[i2]);
                combined.Add(nums2[i2 + 1]);
                combined.Add(nums2[i2 + 2]);
                i2 += 3;
                continue;
            }
            
            if (hasRow1 && i2 >= nums2.Count - 1)
            {
                combined.Add(nums1[i1]);
                combined.Add(nums1[i1 + 1]);
                combined.Add(nums1[i1 + 2]);
                i1 += 3;
                continue;
            }           
                      
            if (i1 < nums1.Count && i2 < nums2.Count)
            {
                combined.Add(nums2[i2++]);
                combined.Add(nums1[i1++]);
            }
            else
                break;
        }
        
        combined.Sort(comparer);
        
        var sb = new StringBuilder(); 
        foreach (var num in combined)
            sb.Append(num);
        
        if (sb.Length == 0 && zeros > 0)
            sb.Append("0");
        else if (sb.Length > 0)
            for (var i = 0; i < zeros; ++i)
                sb.Append("0");
        
        return sb.ToString();
    }
    
    private sealed class Comparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            return b - a;
        }
    }
}