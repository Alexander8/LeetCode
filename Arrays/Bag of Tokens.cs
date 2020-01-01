public class Solution 
{
    public int BagOfTokensScore(int[] tokens, int P)
    {        
        var sum = tokens.Sum();
        
        if (sum <= P) return tokens.Length;
        
        Array.Sort(tokens);
        
        var points = 0;
        var first = 0;
        var last = tokens.Length - 1;
        
        while (true)
        {
            while (tokens[first] <= P)
            {            
                sum -= tokens[first];
                P -= tokens[first];
                ++first;
                ++points;
            }
            
            if (first != last && points > 0 && sum - tokens[last] > 0)
            {
                sum -= tokens[last];
                P += tokens[last];
                --last;
                --points;
            }
            else
                break;
        }
        
        return points;
    }
}