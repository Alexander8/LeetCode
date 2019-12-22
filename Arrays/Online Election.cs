public class TopVotedCandidate 
{
    private readonly List<Vote> _votes = new List<Vote>();
    
    public TopVotedCandidate(int[] persons, int[] times) 
    {
        var leader = -1;
        var votesCnt = 0;
        var map = new Dictionary<int, int>();
        
        for (var i = 0; i < persons.Length; ++i)
        {
            if (!map.TryGetValue(persons[i], out var votesCntTmp))
            {
                votesCntTmp = 1;
                map.Add(persons[i], votesCntTmp);
            }
            else
            {
                ++votesCntTmp;
                map[persons[i]] = votesCntTmp;
            }
            
            if (votesCntTmp >= votesCnt)
            {
                if (persons[i] != leader)
                {
                    leader = persons[i];
                    _votes.Add(new Vote(times[i], leader));
                }
                
                votesCnt = Math.Max(votesCnt, votesCntTmp);
            }
        }               
    }
    
    public int Q(int t) 
    {
        var low = 1;
        var high = _votes.Count;
        
        while (low < high)
        {
            var middle = low + (high - low) / 2;
            if (_votes[middle].Time <= t)
                low = middle + 1;
            else
                high = middle;
        }
        
        return _votes[low - 1].Candidate;
    }
    
    private sealed class Vote
    {
        public readonly int Time;
        public readonly int Candidate;
        
        public Vote(int time, int candidate)
        {
            Time = time;
            Candidate = candidate;
        }
    }
}

/**
 * Your TopVotedCandidate object will be instantiated and called as such:
 * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
 * int param_1 = obj.Q(t);
 */