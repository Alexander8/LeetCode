public int NthUglyNumber(int n) 
{        
    var lst = new List<int> { 1 };
    
    var lst2 = new List<int>(); var next2 = 0;
    var lst3 = new List<int>(); var next3 = 0;
    var lst5 = new List<int>(); var next5 = 0;

    for (var i = lst.Count - 1; i < n - 1; ++i)
    {
        var prev = lst[i];
        
        lst2.Add(prev * 2);
        lst3.Add(prev * 3);
        lst5.Add(prev * 5);
        
        var min = Math.Min(lst2[next2], Math.Min(lst3[next3], lst5[next5]));
        if (min == lst2[next2]) ++next2;
        if (min == lst3[next3]) ++next3;
        if (min == lst5[next5]) ++next5;
        
        lst.Add(min);
    }
    
    return lst[n - 1];
}