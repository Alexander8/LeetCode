public class Solution 
{
    public int[] DeckRevealedIncreasing(int[] deck) 
    {
        var res = new List<int>(deck.Length);
        
        Array.Sort(deck);
        
        for (var i = deck.Length - 1; i >= 0; --i)
        {
            var revealed = deck[i];
            
            if (res.Count > 1)
            {
                var tmp = res[res.Count - 1];
                res.RemoveAt(res.Count - 1);
                res.Insert(0, tmp);
            }            
                        
            res.Insert(0, revealed);
        }
        
        return res.ToArray();
    }
}