public class Solution 
{
    public IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies) 
    {
        var res = new List<int>();
        var sets = favoriteCompanies.Select(x => x.ToHashSet()).ToArray();
        var map = new Dictionary<HashSet<string>, int>();
        
        for (var i = 0; i < sets.Length; ++i)
            map[sets[i]] = i;
        
        sets = sets.OrderBy(x => x.Count).ToArray();
        
        for (var i = 0; i < sets.Length; ++i)
        {
            var isSubset = false;
            
            for (var j = i + 1; j < sets.Length && !isSubset; ++j)
            {
                isSubset = sets[i].IsSubsetOf(sets[j]);                   
            }
            
            if (!isSubset)
                res.Add(map[sets[i]]);
        }
        
        return res.OrderBy(x => x).ToList();
    }
}