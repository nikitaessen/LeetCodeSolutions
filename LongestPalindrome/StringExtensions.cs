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

			var maxLength = 1;
			var startIndex = 0;
			var length = s.Length;

			for (var i = 1; i < length; i++)
			{
				var lowIndex = i - 1;
				var highIndex = i;

				while (lowIndex >= 0 && highIndex < length &&
						s.ElementAt(lowIndex) == s.ElementAt(highIndex))
				{
					if (highIndex - lowIndex + 1 > maxLength)
					{
						startIndex = lowIndex;
						maxLength = highIndex - lowIndex + 1;
					}

					highIndex++;
					lowIndex--;
				}

				lowIndex = i - 1;
				highIndex = i + 1;

				while (lowIndex >= 0 && highIndex < length &&
						s.ElementAt(lowIndex) == s.ElementAt(highIndex))
				{
					if (highIndex - lowIndex + 1 > maxLength)
					{
						startIndex = lowIndex;
						maxLength = highIndex - lowIndex + 1;
					}

					lowIndex--;
					highIndex++;
				}
			}

			return s.Substring(startIndex, maxLength);
		}
	}
}
