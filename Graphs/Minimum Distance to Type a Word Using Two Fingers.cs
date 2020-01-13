public class Solution 
{
    private static readonly Dictionary<char, (int x, int y)> Letters = new Dictionary<char, (int x, int y)>
    {
        { 'A', (0, 0) }, { 'B', (0, 1) }, { 'C', (0, 2) }, { 'D', (0, 3) }, { 'E', (0, 4) }, { 'F', (0, 5) },
        { 'G', (1, 0) }, { 'H', (1, 1) }, { 'I', (1, 2) }, { 'J', (1, 3) }, { 'K', (1, 4) }, { 'L', (1, 5) },
        { 'M', (2, 0) }, { 'N', (2, 1) }, { 'O', (2, 2) }, { 'P', (2, 3) }, { 'Q', (2, 4) }, { 'R', (2, 5) },
        { 'S', (3, 0) }, { 'T', (3, 1) }, { 'U', (3, 2) }, { 'V', (3, 3) }, { 'W', (3, 4) }, { 'X', (3, 5) },
        { 'Y', (4, 0) }, { 'Z', (4, 1) }
    };

    public int MinimumDistance(string word)
    {
        var minDistance = int.MaxValue;
        var q = new SortedDictionary<int, List<State>>();
        var visited = new HashSet<State>();

        var initialState = new State(0, -1, 0);

        q.Add(0, new List<State> { initialState });
        visited.Add(initialState);

        while (q.Count > 0)
        {
            var states = q[q.Keys.First()];
            var currentState = states[0];

            if (states.Count == 1) q.Remove(q.Keys.First());
            else states.RemoveAt(0);

            var currentPos = Math.Max(currentState.FirstPos, currentState.SecondPos);
            if (currentPos == word.Length - 1) continue;

            var nextPos = currentPos + 1;

            foreach (var possibleNextState in GetNextStates(currentState, nextPos, word))
            {
                if (visited.TryGetValue(possibleNextState, out var currentNextState) && 
                    currentNextState.Distance <= possibleNextState.Distance)
                    continue;

                if (!q.ContainsKey(possibleNextState.Distance))
                    q[possibleNextState.Distance] = new List<State>();

                q[possibleNextState.Distance].Add(possibleNextState);

                visited.Add(possibleNextState);

                if (nextPos == word.Length - 1)
                    minDistance = Math.Min(minDistance, possibleNextState.Distance);
            }
        }

        return minDistance;
    }

    private static List<State> GetNextStates(State currentState, int nextPos, string word)
    {
        var nextStates = new List<State>();

        nextStates.Add(new State(nextPos, currentState.SecondPos, 
                                 currentState.Distance + GetDistance(currentState.FirstPos, nextPos, word)));
        nextStates.Add(new State(currentState.FirstPos, nextPos, 
                                 currentState.Distance + GetDistance(currentState.SecondPos, nextPos, word)));

        return nextStates;
    }

    private static int GetDistance(int currentPos, int nextPos, string word)
    {
        if (currentPos == -1) return 0;

        var currentLetter = Letters[word[currentPos]];
        var nextLetter = Letters[word[nextPos]];
        var distance = Math.Abs(currentLetter.x - nextLetter.x) + Math.Abs(currentLetter.y - nextLetter.y);

        return distance;
    }

    private sealed class State : IEquatable<State>
    {
        public readonly int FirstPos;
        public readonly int SecondPos;
        public readonly int Distance;

        public State(int firstPos, int secondPos, int distance)
        {
            FirstPos = firstPos;
            SecondPos = secondPos;
            Distance = distance;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is State other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstPos, SecondPos);
        }

        public bool Equals(State other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FirstPos == other.FirstPos && SecondPos == other.SecondPos;
        }
    }
}