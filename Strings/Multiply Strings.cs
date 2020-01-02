public class Solution 
{
    public string Multiply(string num1, string num2) 
    {
        if (num1 == "0" || num2 == "0") return "0";
        
        var mults = new List<string>(num2.Length);

        for (var i = 0; i < num2.Length; ++i)
        {
            var carry = 0;
            var sb = new StringBuilder();

            for (var j = 0; j < num1.Length; ++j)
            {
                var a = num1[num1.Length - j - 1] - '0';
                var b = num2[num2.Length - i - 1] - '0';

                var total = a * b + carry;

                sb.Insert(0, total % 10);
                carry = total / 10;
            }

            if (carry != 0)
                sb.Insert(0, carry);

            mults.Add(sb.ToString());
        }

        if (mults.Count == 1) return mults[0];

        var res = Sum(mults[0], mults[1], 1);

        for (var i = 2; i < mults.Count; ++i)
            res = Sum(res, mults[i], i);

        return res;
    }

    private static string Sum(string s1, string s2, int shift)
    {
        if (shift == 0 && s1.Length > s2.Length)
        {
            var tmp = s1;
            s1 = s2;
            s2 = tmp;
        }

        var sb = new StringBuilder();
        var carry = 0;

        sb.Insert(0, s1.Substring(s1.Length - shift));

        for (var i = shift; i < s1.Length; ++i)
        {
            var a = s1[s1.Length - 1 - i] - '0';
            var b = s2[s2.Length - i + shift - 1] - '0';

            var res = a + b + carry;

            sb.Insert(0, res % 10);
            carry = res / 10;
        }

        var remaining = s2.Length - s1.Length + shift;

        s2 = s2.Substring(0, remaining);

        if (carry == 0)
        {
            sb.Insert(0, s2);
        }
        else
        {
            if (!string.IsNullOrEmpty(s2))
            {
                sb.Insert(0, Sum(s2, carry.ToString(), 0));
            }
            else
            {
                sb.Insert(0, carry);
            }
        }

        return sb.ToString();
    }
}