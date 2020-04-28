public class MedianFinder 
{
    private readonly List<int> _list = new List<int>(4096);
   
    public MedianFinder() 
    {        
    }
    
    public void AddNum(int num) 
    {
        var idx = _list.BinarySearch(num);
        if (idx < 0) 
            idx = ~idx;
        
        _list.Insert(idx, num);
    }
    
    public double FindMedian() 
    {
        if (_list.Count % 2 == 1)
            return _list[_list.Count / 2];
        
        return (double)(_list[_list.Count / 2 - 1] + _list[_list.Count / 2]) / 2;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */