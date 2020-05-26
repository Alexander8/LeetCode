public class Solution 
{
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) 
    {
        var map = new Dictionary<int, int>();
        
        for (var i = 0; i < reservedSeats.Length; ++i)
        {
            var row = map.GetValueOrDefault(reservedSeats[i][0], 7);

            if (reservedSeats[i][1] >= 2 && reservedSeats[i][1] <= 5)
                row &= 3;

            if (reservedSeats[i][1] >= 6 && reservedSeats[i][1] <= 9)
                row &= 5;

            if (reservedSeats[i][1] >= 4 && reservedSeats[i][1] <= 7)
                row &= 6;

            map[reservedSeats[i][0]] = row;
        }
        
        var cnt = 0;
        
        foreach (var item in map)
        {
            if (item.Value == 7)
                cnt += 2;
            else if (item.Value != 0)
                cnt += 1;
        }
        
        return (n - map.Count) * 2 + cnt;
    }
}