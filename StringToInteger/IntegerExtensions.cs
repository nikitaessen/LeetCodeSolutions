using System;
using System.Collections.Generic;
using System.Linq;

namespace StringToInteger
{
	public class IntegerExtensions
	{
		private const char WHITE_SPACE = ' ';
		private const char PLUS = '+';
		private const char MINUS = '-';


		public int MyAtoi(string str)
		{
			var sign = 0;
			var arr = str.ToCharArray();
			var digits = new List<char>();

			for (var i = 0; i < arr.Length; i++)
			{
				if (arr[i] == WHITE_SPACE)
				{
					if (digits.Any())
					{
						break;
					}

					if (sign != 0)
					{
						return 0;
					}

					continue;
				}

				if (!char.IsDigit(arr[i]))
				{
					if (digits.Any())
					{
						break;
					}

					if (sign != 0)
					{
						return 0;
					}

					if (arr[i] == PLUS)
					{
						sign = 1;
						continue;
					}

					if (arr[i] == MINUS)
					{
						sign = -1;
						continue;
					}

					return 0;
				}

				digits.Add(arr[i]);
			}

			var result = 0;
			if (sign == 0)
			{
				sign = 1;
			}

			try
			{
				checked
				{
					for (int i = digits.Count - 1, j = 0; i >= 0; i--)
					{
						var digit = digits[i] - '0';

						if (digit == 0)
						{
							j++;
							continue;
						}

						result += digit * (int)Math.Pow(10, j) * sign;
						j++;
					}
				}
			}
			catch (OverflowException)
			{
				if (sign == 1)
				{
					return int.MaxValue;
				}

				return int.MinValue;
			}

			return result;
		}
	}
}
