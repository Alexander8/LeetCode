public bool DivisorGame(int N) 
{
    var dp = new bool[Math.Max(3, N) + 1];
    
    dp[1] = false;
    dp[2] = true;
    dp[3] = false;
    
    for (var i = 4; i <= N; ++i)
    {
        for (var j = 1; j <= Math.Ceiling(Math.Sqrt(i)); ++j)
        {
            if (i % j != 0)
            {
                continue;
            }
            
            var bob = dp[i - j];
            if (!bob)
            {
                dp[i] = true;
                break;
            }              
        }
    }
    
    return dp[N];
}