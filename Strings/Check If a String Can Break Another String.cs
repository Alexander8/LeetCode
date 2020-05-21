public class Solution 
{
    public bool CheckIfCanBreak(string s1, string s2) 
    {
        var arr1 = s1.ToCharArray();
        var arr2 = s2.ToCharArray();
        
        Array.Sort(arr1);
        Array.Sort(arr2);
        
        var res = true;
        
        for (var i = 0; i < arr1.Length && res; ++i)
        {
            if (arr1[i] > arr2[i])
                res = false;
        }
        
        if (res)
            return res;
        
        res = true;
        
        for (var i = 0; i < arr1.Length && res; ++i)
        {
            if (arr1[i] < arr2[i])
                res = false;
        }
        
        return res;
    }
}