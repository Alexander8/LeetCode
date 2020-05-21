public class Skiplist 
{
    private const double Probability = 0.25;
    private readonly List<Level> _levels = new List<Level>();
    private readonly Random _rand = new Random();

    public Skiplist() 
    {   
        for (var i = 0; i < 8; ++i)
            _levels.Add(new Level());
    }

    public bool Search(int target) 
    {
        LinkedListNode<Node> startNode = null;

        for (var level = 0; level < _levels.Count; ++level)
        {
            var list = _levels[level].List;
            if (list.Count == 0) continue;

            var node = startNode ?? list.First;

            while (node != null)
            {
                var num = node.Value.Num;
                if (num == target)
                    return true;

                if (num < target)
                {
                    startNode = node.Value.Below;
                    node = node.Next;
                }
                else
                {
                    if (level < _levels.Count - 1)
                        break;

                    return false;
                }
            }
        }

        return false;
    }

    public void Add(int num) 
    {
        var below = Add(_levels.Count - 1, num, null);
        var level = _levels.Count - 2;
        while (level >= 0 && _rand.NextDouble() < Probability)
        {
            below = Add(level, num, below);
            --level;
        }
    }

    private LinkedListNode<Node> Add(int level, int num, LinkedListNode<Node> below)
    {     
        var list = _levels[level].List;
        var node = list.First;
        var newNode = new Node(num, level, below);

        while (node != null && node.Value.Num <= num)
            node = node.Next;

        if (node == null)
        {
            list.AddLast(newNode);
            return list.Last;
        }

        list.AddBefore(node, newNode);
        return node.Previous;
    }

    public bool Erase(int target)
    {
        LinkedListNode<Node> startNode = null;

        var map = new LinkedListNode<Node>[_levels.Count];
        var found = false;

        for (var level = 0; level < _levels.Count; ++level)
        {
            var list = _levels[level].List;
            if (list.Count == 0) continue;

            var node = startNode ?? list.First;
            while (node != null)
            {
                var num = node.Value.Num;
                if (num == target)
                {
                    map[level] = node;
                    startNode = node.Value.Below;
                    found = true;
                    break;
                }

                if (num < target)
                {
                    startNode = node.Value.Below;
                    node = node.Next;
                }
                else
                {
                    if (level < _levels.Count - 1)
                        break;

                    return false;
                }
            }
        }

        if (!found) return false;

        for (var level = _levels.Count - 1; level >= 0; --level)
        {
            if (map[level] == null) break;

            _levels[level].List.Remove(map[level]);
        }

        return true;
    }

    private sealed class Level
    {
        public LinkedList<Node> List { get; } = new LinkedList<Node>();
    }

    private sealed class Node
    {
        public int Num { get; }

        public int Level { get; }

        public LinkedListNode<Node> Below { get; }

        public Node(int num, int level, LinkedListNode<Node> below)
        {
            Num = num;
            Level = level;
            Below = below;
        }
    }
}
