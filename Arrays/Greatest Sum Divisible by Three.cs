public int MaxSumDivThree(int[] nums)
{
	int mod0 = 0, mod1 = 0, mod2 = 0;

	foreach (var num in nums)
	{
		int o0 = mod0, o1 = mod1, o2 = mod2;

		Put(o0 + num, ref mod0, ref mod1, ref mod2);
		Put(o1 + num, ref mod0, ref mod1, ref mod2);
		Put(o2 + num, ref mod0, ref mod1, ref mod2);
	}

	return mod0;
}

private static void Put(int num, ref int mod0, ref int mod1, ref int mod2)
{
	if (num%3==0)
	{
		mod0 = Math.Max(num, mod0);
	}
	else if (num%3==1)
	{
		mod1 = Math.Max(num, mod1);
	}
	else
	{
		mod2 = Math.Max(num, mod2);
	}
}