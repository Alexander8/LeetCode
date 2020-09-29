public class Solution 
{
    public IList<string> FindItinerary(IList<IList<string>> tickets) 
    {
        if (tickets.Count == 1)
            return tickets[0];
        
        var map = new Dictionary<string, List<string>>();
        var available = new Dictionary<string, int>();
        
        foreach (var t in tickets)
        {
            if (!map.TryGetValue(t[0], out var list))
            {
                list = new List<string>();
                map.Add(t[0], list);
            }     
            
            var idx = list.BinarySearch(t[1]);
            if (idx < 0) idx = ~idx;
            
            list.Insert(idx, t[1]);
            
            var tmp = t[0] + t[1];
            var cnt = available.GetValueOrDefault(tmp, 0);
            available[tmp] = cnt + 1;
        }
        
        var path = new List<string>();
        if (Travel("JFK", map, path, available, tickets.Count))
            return path;
        
        return new List<string>();
    }
    
    private static bool Travel(
        string from, 
        Dictionary<string, List<string>> map, 
        List<string> path, 
        Dictionary<string, int> available, 
        int ticketsCount)
    {        
        path.Add(from);
        
        if (path.Count == ticketsCount + 1)
            return true;
        
        if (map.TryGetValue(from, out var list))
        {
            foreach (var to in list)
            {
                var ticket = from + to;
                if (available.TryGetValue(ticket, out var cnt) && cnt > 0)
                {            
                    available[ticket] = cnt - 1;
                    
                    if (Travel(to, map, path, available, ticketsCount))
                        return true;                

                    available[ticket] = cnt;
                }
            }
        }
        
        path.RemoveAt(path.Count - 1);
        return false;
    }
}