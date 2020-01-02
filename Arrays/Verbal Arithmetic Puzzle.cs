public class Solution 
{
    private int _r;
    private int _c;
    private Dictionary<(int x, int y), char> _coords;
    private Dictionary<char, int> _assignedDigits;
    private HashSet<int> _usedDigits;

    public bool IsSolvable(string[] words, string result)
    {
        _r = words.Length + 1;
        _c = result.Length;
        _coords = new Dictionary<(int x, int y), char>();
        _assignedDigits = new Dictionary<char, int>();
        _usedDigits = new HashSet<int>();

        for (var i = 0; i < words.Length; ++i)
        {
            var shift = _c - words[i].Length;
            AddWord(words[i], shift, i);
        }

        AddWord(result, 0, words.Length);

        return IsSolvable(0, _c - 1, 0, 0);
    }

    private void AddWord(string word, int shift, int i)
    {
        for (var j = 0; j < word.Length; ++j)
            _coords[(i, shift + j)] = word[j];
    }

    private bool IsSolvable(int i, int j, int carry, int sum)
    {
        if (j < 0) 
            return carry == 0;

        // Addends.
        if (i < _r - 1)
        {
            if (!_coords.ContainsKey((i, j)) || _assignedDigits.ContainsKey(_coords[(i, j)]))
            {
                var addend = _coords.ContainsKey((i, j)) ? _assignedDigits[_coords[(i, j)]] : 0;
                return IsSolvable(i + 1, j, carry, sum + addend * (int)Math.Pow(10, _c - j - 1));
            }

            var startDigit = _coords.ContainsKey((i, j - 1)) ? 0 : 1;

            for (var d = startDigit; d <= 9; ++d)
            {
                if (_usedDigits.Contains(d)) continue;

                _usedDigits.Add(d);
                _assignedDigits[_coords[(i, j)]] = d;

                if (IsSolvable(i + 1, j, carry, sum + d * (int)Math.Pow(10, _c - j - 1))) 
                    return true;

                _usedDigits.Remove(d);
                _assignedDigits.Remove(_coords[(i, j)]);
            }

            return false;
        }

        var sumDigit = GetDigit(sum, _c - j - 1);

        // Sum.
        if (_assignedDigits.ContainsKey(_coords[(i, j)]))
        {
            if (_assignedDigits[_coords[(i, j)]] == sumDigit)
            {
                if (IsSolvable(0, j - 1, GetDigit(sum, _c - j), sum))
                    return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (_usedDigits.Contains(sumDigit))
            {
                return false;
            }
            else
            {
                _usedDigits.Add(sumDigit);
                _assignedDigits[_coords[(i, j)]] = sumDigit;

                if (IsSolvable(0, j - 1, GetDigit(sum, _c - j), sum)) 
                    return true;

                _usedDigits.Remove(sumDigit);
                _assignedDigits.Remove(_coords[(i, j)]);
            }
        }

        return false;
    }

    private static int GetDigit(int n, int idx)
    {
        var i = -1;
        var digit = 0;

        while (i != idx)
        {
            digit = n % 10;
            n /= 10;
            ++i;
        }

        return digit;
    }
}