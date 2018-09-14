namespace StringToInteger
{
	class Program
	{
		static void Main(string[] args)
		{
			var ext = new IntegerExtensions();

			ext.MyAtoi("-   234");
		}
	}
}
