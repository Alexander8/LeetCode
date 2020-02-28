public class Solution 
{
    public IList<string> InvalidTransactions(string[] transactions) 
    {
        var res = new HashSet<(string name, int time, int amount, string city)>();
        var trans = transactions.Select(Parse).ToArray();     
        
        for (var i = 0; i < trans.Length; ++i)
        {         
            if (trans[i].amount > 1000)
                res.Add(trans[i]);
            
            for (var j = i + 1; j < trans.Length; ++j)
            {
                if (string.CompareOrdinal(trans[i].name, trans[j].name) == 0
                    && Math.Abs(trans[i].time - trans[j].time) <= 60 
                    && string.CompareOrdinal(trans[i].city, trans[j].city) != 0)
                {
                    res.Add(trans[i]);
                    res.Add(trans[j]);
                }
            }
        }
        
        return res.Select(x => $"{x.name},{x.time},{x.amount},{x.city}").ToList();
    }
    
    private static (string name, int time, int amount, string city) Parse(string t)
    {
        var parts = t.Split(new[] { ',' });
        return (parts[0], int.Parse(parts[1]), int.Parse(parts[2]), parts[3]);
    }
}