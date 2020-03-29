public class UndergroundSystem 
{
    private readonly Dictionary<(string, string), (double sum, int count)> _map = new Dictionary<(string, string), (double sum, int count)>();
    private readonly Dictionary<int, (string station, int time)> _trips = new Dictionary<int, (string station, int time)>();    
    
    
    public UndergroundSystem() 
    {        
    }
    
    public void CheckIn(int id, string stationName, int t) 
    {
        _trips[id] = (stationName, t);
    }
    
    public void CheckOut(int id, string stationName, int t) 
    {
        var data = _trips[id];
        
        if (_map.TryGetValue((data.station, stationName), out var avgData))
        {
            _map[(data.station, stationName)] = (avgData.sum + (t - data.time), avgData.count + 1);
        }
        else
        {
            _map[(data.station, stationName)] = (t - data.time, 1);
        }
    }
    
    public double GetAverageTime(string startStation, string endStation) 
    {
        var data = _map[(startStation, endStation)];
        return data.sum / data.count;
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */