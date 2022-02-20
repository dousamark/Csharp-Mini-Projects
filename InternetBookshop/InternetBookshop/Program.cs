using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("InternetBookshop_MSTests")]

namespace InternetBookshop
{
	class Program
	{
		static void Main(string[] args)
		{
			ModelStore modelStore = ModelStore.LoadFrom(new Reader());
			if (modelStore == null)
			{
				Console.WriteLine("Data error.");
			}
			else
			{
				Processor.ProcessRequests(modelStore, new Reader());
			}
		}
	}
}
