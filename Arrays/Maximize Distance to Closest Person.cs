public class Solution 
{
    public int MaxDistToClosest(int[] seats) 
    {
        var left = -1;
        var right = -1;
        var distance = 0;
        
        while (left < seats.Length - 1)
        {    
            if (left == -1)
            {
                left = GetNextOneIdx(seats, 0);
                distance = Math.Max(distance, left);
            }
            
            right = GetNextOneIdx(seats, left + 1);
            
            if (right < seats.Length)
                distance = Math.Max(distance, (right - left) / 2);
            else
                distance = Math.Max(distance, seats.Length - 1 - left);
            
            left = right;
        }
        
        return distance;
    }
    
    private static int GetNextOneIdx(int[] seats, int i)
    {
        while (i < seats.Length && seats[i] != 1)
            ++i;
        
        return i;
    }
}