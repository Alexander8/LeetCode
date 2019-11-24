public string SolveEquation(string equation)
{
	if (string.IsNullOrEmpty(equation)) return "No solution";

	var parts = equation.Split(new[] {'='});

	var (leftX, left) = Parse(parts[0]);
	var (rightX, right) = Parse(parts[1]);

	var leftTotal = leftX - rightX;
	var rightTotal = right - left;

	if (leftTotal == rightTotal && leftTotal == 0) return "Infinite solutions";

	if (leftTotal == 0 && rightTotal != 0) return "No solution";

	return "x=" + rightTotal / leftTotal;
}

private static (int coeffX, int coeff) Parse(string s)
{
	int coeffX = 0, coeff = 0, i = 0;

	while (i < s.Length)
	{
		if (s[i] == '+' || s[i] == '-')
		{
			++i;
			continue;
		}

		var start = i;
		var c = string.Empty;

		if (s[i] >= '0' && s[i] <= '9')
		{
			while (i < s.Length && s[i] >= '0' && s[i] <= '9')
			{
				c += s[i];
				++i;
			}
		}

		var minus = start - 1 >= 0 && s[start - 1] == '-';

		if (i == s.Length || s[i] != 'x')
		{
			var iC = int.Parse(c);
			if (minus) coeff -= iC;
			else coeff += iC;
		}
		else
		{
			var iC = c != string.Empty ? int.Parse(c) : 1;
			if (minus) coeffX -= iC;
			else coeffX += iC;
			++i;
		}
	}

	return (coeffX, coeff);
}