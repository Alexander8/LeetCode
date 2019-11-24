public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) 
{
	IList<IList<string>> res = new List<IList<string>>();
	
	FillDict(products, searchWord, 1, res);      
	
	return res;
}

private static void FillDict(string[] products, string searchWord, int prefixLength, IList<IList<string>> strings)
{
	if (prefixLength > searchWord.Length) return;
	
	var prefix = searchWord.Substring(0, prefixLength);
	products = products.Where(s => s.StartsWith(prefix)).OrderBy(s => s).ToArray();
	
	strings.Add(products.Take(3).ToList());
	
	FillDict(products, searchWord, prefixLength + 1, strings);
}