public class Solution 
{
    public int MaxJumps(int[] arr, int d) 
    {
        var visited = new Dictionary<int, int>();
        var canJump = new Dictionary<(int, int), bool>();
        var cnt = 0;

        for (var i = 0; i < arr.Length; ++i)
            cnt = Math.Max(cnt, 1 + MaxJumps(arr, d, i, visited, canJump));

        return cnt;
    }
    
    private static int MaxJumps(int[] arr, int d, int i, Dictionary<int, int> visited, Dictionary<(int, int), bool> canJump)
    {
        if (visited.TryGetValue(i, out var cached)) return cached;

        var cnt = 0;

        bool canJumpRight = true, canJumpLeft = true;

        for (var k = 1; k <= d; ++k)
        {
            if (!canJumpRight && !canJumpLeft) break;

            if (canJumpRight && i + k < arr.Length && CanJump(arr, i, i + k, canJump))
            {
                cnt = Math.Max(cnt, 1 + MaxJumps(arr, d, i + k, visited, canJump));
            }
            else
            {
                canJumpRight = false;
            }

            if (canJumpLeft && i - k >= 0 && CanJump(arr, i, i - k, canJump))
            {
                cnt = Math.Max(cnt, 1 + MaxJumps(arr, d, i - k, visited, canJump));
            }
            else
            {
                canJumpLeft = false;
            }
        }

        visited[i] = cnt;
        return cnt;
    }

    private static bool CanJump(int[] arr, int start, int finish, Dictionary<(int, int), bool> canJump)
    {
        var key = (start, finish);

        if (canJump.TryGetValue(key, out var cached)) return cached;

        if (start < finish)
        {
            for (var i = start + 1; i <= finish; ++i)
            {
                if (arr[start] <= arr[i])
                {
                    canJump[key] = false;
                    return false;
                }
            }
        }
        else
        {
            for (var i = start - 1; i >= finish; --i)
            {
                if (arr[start] <= arr[i])
                {
                    canJump[key] = false;
                    return false;
                }
            }
        }

        canJump[key] = true;
        return true;        
    }
}