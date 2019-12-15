public int MaxScoreWords(string[] words, char[] letters, int[] score)
{
    var groupedLetters = letters.GroupBy(l => l).ToDictionary(gr => gr.Key, gr => gr.Count());
    var max = 0;

    for (var i = 0; i < words.Length; ++i)
    {
        var dict = new Dictionary<char, int>(groupedLetters);
        max = Math.Max(max, MaxScoreWords(words, i, dict, score, 0));
    }

    return max;
}

private static int MaxScoreWords(string[] words, int i, Dictionary<char, int> letters, int[] scores, int maxSoFar)
{
    if (letters.Count == 0)
        return maxSoFar;

    if (i == words.Length)
        return maxSoFar;

    if (!WordCanBeUsed(words[i], letters))
        return maxSoFar;

    foreach (var c in words[i])
    {
        letters[c] -= 1;
        if (letters[c] == 0)
            letters.Remove(c);

        maxSoFar += scores[c - 'a'];
    }

    var max = maxSoFar;
    for (var j = i + 1; j < words.Length; ++j)
        max = Math.Max(max, MaxScoreWords(words, j, new Dictionary<char, int>(letters), scores, maxSoFar));

    return max;
}

private static bool WordCanBeUsed(string word, Dictionary<char, int> letters)
{
    foreach (var gr in word.GroupBy(l => l))
    {
        if (!letters.TryGetValue(gr.Key, out var cnt))
            return false;

        if (gr.Count() > cnt)
            return false;
    }

    return true;
}