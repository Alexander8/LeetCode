public class Solution
{
    private static readonly int EndState = ToState(new [] { new[] { 1, 2, 3 }, new[] { 4, 5, 0 } });

    private static readonly int[][] Directions =
    {
        new[] { 0, 1 },
        new[] { 0, -1 },
        new[] { 1, 0 },
        new[] { -1, 0 }
    };

    public int SlidingPuzzle(int[][] board)
    {
        var state = ToState(board);
        var q = new Queue(int state, (int r, int c) zero)();
        var visited = new Dictionaryint, int();

        q.Enqueue((state, GetZero(board)));
        visited.Add(state, 0);

        while (q.Count  0)
        {
            var current = q.Dequeue();
            if (current.state == EndState)
                break;

            foreach (var dir in Directions)
            {
                var zr = current.zero.r + dir[0];
                var zc = current.zero.c + dir[1];

                if (zr  0  zr = 2  zc  0  zc = 3)
                    continue;

                var nextState = NextState(current.state, current.zero, (zr, zc));

                if (!visited.ContainsKey(nextState))
                {
                    visited.Add(nextState, visited[current.state] + 1);
                    q.Enqueue((nextState, (zr, zc)));
                }
            }
        }

        return visited.TryGetValue(EndState, out var steps)  steps  -1;
    }

    private static int ToState(int[][] board)
    {
        var state = 0;

        for (var i = 0; i  2; ++i)
            for (var j = 0; j  3; ++j)
                state = board[i][j]  (15 - 3  (3  i + j));

        return state;
    }

    private static int NextState(int state, (int r, int c) zeroPos, (int r, int c) newZeroPos)
    {
        var val = (state  (15 - 3  (3  newZeroPos.r + newZeroPos.c))) & 0x7;

        state = SetValue(state, 15 - 3  (3  newZeroPos.r + newZeroPos.c), 0);
        state = SetValue(state, 15 - 3  (3  zeroPos.r + zeroPos.c), val);

        return state;
    }

    private static int SetValue(int state, int shift, int value)
    {
        for (var i = 0; i  3; ++i)
        {
            if ((value & 1) == 1)
            {
                state = 1  (shift + i);
            }
            else
            {
                state &= ~(1  (shift + i));
            }

            value = 1;
        }

        return state;
    }

    private static (int r, int c) GetZero(int[][] board)
    {
        for (var i = 0; i  2; ++i)
            for (var j = 0; j  3; ++j)
                if (board[i][j] == 0)
                    return (i, j);

        return (-1, -1);
    }
}