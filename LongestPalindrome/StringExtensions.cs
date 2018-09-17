using System.Linq;

namespace LongestPalindrome
{
	public class StringExtensions
	{
		public string LongestPalindrome(string s)
		{
			if (string.IsNullOrWhiteSpace(s))
			{
				return string.Empty;
			}

			var n = s.Length;

			var table = new bool[n, n];

			var maxLength = 1;

			for (var i = 0; i < n; i++)
			{
				table[i, i] = true;
			}

			var startIndex = 0;
			for (var i = 0; i < n - 1; ++i)
			{
				if (s.ElementAt(i) == s.ElementAt(i + 1))
				{
					table[i, i + 1] = true;
					startIndex = i;
					maxLength = 2;
				}
			}

			for (var k = 3; k <= n; ++k)
			{
				for (var i = 0; i < n-k+1; ++i)
				{
					var j = i + k - 1;

					if (table[i + 1, j - 1] && s.ElementAt(i) == s.ElementAt(j))
					{
						table[i, j] = true;

						if (k > maxLength)
						{
							startIndex = i;
							maxLength = k;
						}
					}
				}
			}

			return s.Substring(startIndex, maxLength);
		}
	}
}
