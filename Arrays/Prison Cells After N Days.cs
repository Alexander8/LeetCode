public class Solution 
{
    public int[] PrisonAfterNDays(int[] cells, int N) 
    {
        var map = new Dictionary<int, int>();
        
        var state = 0;
        for (var i = 0; i < 8; ++i)
            if (cells[i] == 1)
                state |= 1 << i;
        
        
        while (true)
        {
            if (map.TryGetValue(state, out var days))
                N %= days - N;
            
            if (N == 0)
                break;
            
            map[state] = N;
            
            --N;
            
            state = GetNextState(state);
        }
        
        var ans = new int[8];
        
        for (var i = 0; i < 8; ++i)
            if (((state >> i) & 1) == 1) 
                ans[i] = 1;
        
        return ans;
    }
    
    private static int GetNextState(int state)
    {
        var next = 0;
        
        for (var i = 1; i <= 6; ++i) 
            if (((state >> (i-1)) & 1) == ((state >> (i+1)) & 1))
                next |= 1 << i;
        
        return next;
    }
}