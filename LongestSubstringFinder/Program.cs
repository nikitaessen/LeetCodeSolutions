namespace LongestSubstringFinder
{
	class Program
	{
		static void Main(string[] args)
		{
			var sol = new Solution();

			var result = sol.LengthOfLongestSubstring("ubsvutpwmu");
		}
	}

	public class Solution
	{
		public int LengthOfLongestSubstring(string s)
		{
			var longest = string.Empty;
			var buff = string.Empty;

			for (var i = 0; i < s.Length; i++)
			{
				if (buff.Contains(s[i].ToString()))
				{
					if (buff.Length > longest.Length)
					{
						longest = string.Copy(buff);
					}

					var j = buff.Length - 1;

					for(;;)
					{
						if (buff[j] == s[i])
						{
							buff = buff.Remove(0, j + 1);
							buff = $"{buff}{s[i]}";
							break;
						}

						j--;
					}
				}
				else
				{
					buff += s[i];
				}
			}

			if (buff.Length > longest.Length)
			{
				longest = string.Copy(buff);
			}

			return longest.Length;
		}
	}
}
