public class Solution 
{
    private int[] _arr;
    private HashSet<int> _set;
    
    public bool CanReach(int[] arr, int start) 
    {
        _arr = arr;
        _set = new HashSet<int>();
        
        return CanReach(start);
    }
    
    private bool CanReach(int i)
    {
        if (i < 0 || i >= _arr.Length) 
            return false;
        
        if (_arr[i] == 0)
            return true;

        if (_set.Contains(i))
            return false;

        _set.Add(i);
        
        var res1 = CanReach(i + _arr[i]); if(res1) return true;
        var res2 = CanReach(i - _arr[i]); if(res2) return true;       
        
        return false;
    }
}