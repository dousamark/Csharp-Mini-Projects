using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace Huffmanovo_kódování
{
	public static class ArgsValidization
	{
		public static bool ArgsValid(string[] args)
		{
			if (args.Length != 1)
			{
				Console.WriteLine("Argument Error");
				return false;
			}
			try
			{
				using FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.Read);
			}
			catch
			{
				Console.WriteLine("File Error");
				return false;
			}
			return true;
		}
	}
}
