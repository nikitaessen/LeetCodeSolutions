using System.Linq;

namespace ReverseInteger
{
	public class IntegerExtensions
	{
		private const char NEGATIVE_SIGN = '-';

		public int Reverse(int x)
		{
			var arr = x.ToString().ToCharArray();

			var invertedArr = arr.Reverse().ToArray();

			var str = new string(invertedArr);

			if (str.Last() == NEGATIVE_SIGN)
			{
				str = str.Remove(str.Length - 1);
				str = $"{NEGATIVE_SIGN}{str}";
			}

			return int.TryParse(str, out var result) ? result : 0;
		}
	}
}
