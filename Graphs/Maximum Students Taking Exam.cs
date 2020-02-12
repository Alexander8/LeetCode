public int MaxStudents(char[][] seats)
{
    int rows = seats.Length, cols = seats[0].Length;
    var memo = new Dictionary<long, int>();
    var seatsCopy = new char[rows, cols];

    for (var i = 0; i < rows; ++i)
        for (var j = 0; j < cols; ++j)
            seatsCopy[i, j] = seats[i][j];

    return DFS(seatsCopy, rows, cols, memo);
}

private static int DFS(char[,] seats, int rows, int cols, Dictionary<long, int> memo)
{
    var serialized = Serialize(seats, rows, cols);
    if (memo.TryGetValue(serialized, out var cached)) return cached;

    var res = 0;

    for (var i = 0; i < rows; ++i)
    {
        for (var j = 0; j < cols; ++j)
        {
            if (seats[i, j] != '.') continue;

            seats[i, j] = '#';
            res = Math.Max(res, DFS(Copy(seats, rows, cols), rows, cols, memo));

            if (j - 1 >= 0 && seats[i, j - 1] == '.') seats[i, j - 1] = '#';
            if (j + 1 < cols && seats[i, j + 1] == '.') seats[i, j + 1] = '#';
            if (i + 1 < rows)
            {
                if (j - 1 >= 0 && seats[i + 1, j - 1] == '.') seats[i + 1, j - 1] = '#';
                if (j + 1 < cols && seats[i + 1, j + 1] == '.') seats[i + 1, j + 1] = '#';
            }

            res = Math.Max(res, 1 + DFS(Copy(seats, rows, cols), rows, cols, memo));
        }
    }

    memo[serialized] = res;
    return res;
}

private static char[,] Copy(char[,] src, int rows, int cols)
{
    var copy = new char[rows, cols];
    Array.Copy(src, copy, rows * cols);
    return copy;
}

private static long Serialize(char[,] seats, int rows, int cols)
{
    long res = 0;

    for (var i = 0; i < rows; ++i)
        for (var j = 0; j < cols; ++j)
            if (seats[i, j] == '#')
                res |= 1L << (cols * i + j);

    return res;
}