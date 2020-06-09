public class BrowserHistory 
{
    private readonly List<string> _urls = new List<string>(5000);
    private int _current;
    private int _count;

    public BrowserHistory(string homepage) 
    {
        _urls.Add(homepage);
        _current = 0;
        _count = 1;
    }

    public void Visit(string url) 
    {
        _urls.Insert(_current + 1, url);
        _current += 1;
        _count = _current + 1;
    }

    public string Back(int steps) 
    {
        steps = Math.Min(steps, _current);
        _current -= steps;
        return _urls[_current];
    }

    public string Forward(int steps) 
    {
        steps = Math.Min(steps, _count - _current - 1);
        _current += steps;
        return _urls[_current];
    }
}
