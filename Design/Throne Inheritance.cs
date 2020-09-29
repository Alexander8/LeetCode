public class ThroneInheritance
{
    private readonly string _kingName;
    private readonly Dictionary<string, List<string>> _parentToChild = new Dictionary<string, List<string>>();
    private readonly HashSet<string> _dead = new HashSet<string>();

    public ThroneInheritance(string kingName)
    {
        _kingName = kingName;
    }

    public void Birth(string parentName, string childName)
    {
        if (!_parentToChild.TryGetValue(parentName, out var children))
        {
            children = new List<string>();
            _parentToChild.Add(parentName, children);
        }

        children.Add(childName);
    }

    public void Death(string name)
    {
        _dead.Add(name);
    }

    public IList<string> GetInheritanceOrder()
    {
        var result = new List<string>();
        FillInheritanceOrder(_kingName, result);
        return result;
    }

    private void FillInheritanceOrder(string name, List<string> result)
    {
        if (!_dead.Contains(name))
        {
            result.Add(name);
        }

        if (_parentToChild.TryGetValue(name, out var children))
        {
            foreach (var child in children)
            {
                FillInheritanceOrder(child, result);
            }
        }
    }
}