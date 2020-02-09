public class TweetCounts 
{
    private readonly Dictionary<string, SortedList<int, int>> _tweets;
    
    public TweetCounts() 
    {        
        _tweets = new Dictionary<string, SortedList<int, int>>();
    }
    
    public void RecordTweet(string tweetName, int time) 
    {
        if (!_tweets.TryGetValue(tweetName, out var map))
        {
            map = new SortedList<int, int>();
            _tweets.Add(tweetName, map);
        }
        
        map.TryGetValue(time, out var cnt);
        map[time] = cnt + 1;
    }
    
    public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime)
    {
        if (!_tweets.TryGetValue(tweetName, out var map)) return new List<int>();

        var tweets = map.SkipWhile(t => t.Key < startTime).TakeWhile(t => t.Key <= endTime).ToArray();

        var intervals = GetIntervals(freq, startTime, endTime);
        var res = new List<int>();

        foreach (var interval in intervals)
        {
            var cnt = tweets.Where(t => t.Key >= interval.Item1 && t.Key < interval.Item2).Sum(t => t.Value);
            res.Add(cnt);
        }

        return res;
    }

    private static List<(int, int)> GetIntervals(string freq, int startTime, int endTime)
    {
        var res = new List<(int, int)>();
        var delta = 0;

        if (freq == "minute")
            delta = 60;
        else if (freq == "hour")
            delta = 3600;
        else
            delta = 86400;

        var start = startTime;
        
        while (true)
        {
            res.Add((start, Math.Min(start + delta, endTime + 1)));

            if (start + delta >= endTime + 1) break;

            start += delta;
        }

        return res;
    }
}

/**
 * Your TweetCounts object will be instantiated and called as such:
 * TweetCounts obj = new TweetCounts();
 * obj.RecordTweet(tweetName,time);
 * IList<int> param_2 = obj.GetTweetCountsPerFrequency(freq,tweetName,startTime,endTime);
 */