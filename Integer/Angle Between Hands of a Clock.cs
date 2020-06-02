public class Solution 
{
    public double AngleClock(int hour, int minutes) 
    {
        var minuteAngle = 6.0 * minutes;
        var hourAngle = hour == 12 ? 0 : 30.0 * hour;
        
        hourAngle += 30.0 * minuteAngle / 360.0;
        
        var angle = Math.Abs(hourAngle - minuteAngle);
        return angle <= 180 ? angle : 360 - angle;
    }
}