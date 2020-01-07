public class Solution 
{
    public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level) 
    {
        var q = new Queue<(int id, int level)>();
        var visited = new HashSet<int>();
        var result = new Dictionary<string, int>();
        
        q.Enqueue((id, 0));
        visited.Add(id);
        
        while (q.Count > 0)
        {
            var friend = q.Dequeue();
            
            if (friend.level == level)
            {
                foreach (var video in watchedVideos[friend.id])
                {
                    if (!result.TryGetValue(video, out var cnt))
                        cnt = 0;

                    result[video] = cnt + 1;
                }
            }
            else
            {            
                foreach (var f in friends[friend.id])
                {
                    if (!visited.Contains(f))
                    {
                        visited.Add(f);
                        
                        q.Enqueue((f, friend.level + 1));
                    }
                }
            }
        }
        
        return result.OrderBy(r => r.Value).ThenBy(r => r.Key).Select(r => r.Key).ToList();
    }
}