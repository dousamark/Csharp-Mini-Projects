using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InternetBookshop
{
	class Reader : TextReader
	{
		public override string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}
