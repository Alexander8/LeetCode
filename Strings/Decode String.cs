string / Decode string

public string DecodeString(string s)
{
    var i = 0;
    return DecodeString(s, ref i, 0);
}

private static string DecodeString(string s, ref int i, int depth)
{
    var sb = new StringBuilder();

    while (i < s.Length)
    {
        if (s[i] == ']')
        {
            if (depth == 0)
            {
                ++i;
                continue;
            }

            return sb.ToString();
        }

        if (s[i] < '0' || s[i] > '9')
        {
            sb.Append(s[i]);
            ++i;
            continue;
        }

        int num = 0;

        while (s[i] >= '0' && s[i] <= '9')
        {
            num *= 10;
            num += s[i] - '0';
            ++i;
        }

        ++i;

        var tmp = DecodeString(s, ref i, depth + 1);
        for (var k = 0; k < num; ++k)
            sb.Append(tmp);

        ++i;
    }

    return sb.ToString();
}