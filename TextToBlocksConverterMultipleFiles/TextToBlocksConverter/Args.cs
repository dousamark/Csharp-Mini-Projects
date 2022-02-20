using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextToBlocksConverter
{
	public class Args
	{
		public string[] filesIn;
		public string fileOut;
		public int lineSize;
		public bool highlightSpaces;

		public Args(string[] args)
		{
			if (TestHighlightSpaces(args[0])) 
			{
				this.highlightSpaces = true;
				this.filesIn = ReturnSubarray(args, 1, args.Length - 3);
			}
			else 
			{ 
				this.highlightSpaces = false;
				this.filesIn = ReturnSubarray(args, 0, args.Length - 2);
			}
			
			this.fileOut = args[args.Length-2];

			//is already int otherwise wouldnt pass TestValidity
			this.lineSize = int.Parse(args[args.Length - 1]);
		}
		
		public static bool TestValidity(string[] files)
		{
			bool lineSizeValid = TestLineSizeValidity(files[files.Length-1]);
			bool highlightSpaces = TestHighlightSpaces(files[0]);

			int minimumArgs = 3;
			if (highlightSpaces) { minimumArgs++; }

			if (!lineSizeValid || minimumArgs > files.Length)
			{
				Console.WriteLine("Argument Error");
				return false;
			}

			//neresi otevirani write out souboru

			/*for (int i = 0; i < NumberOfFiles; i++)
			{
				try
				{
					using (FileStream stmcheck = File.OpenRead(files[i]))
					{
					}
				}
				catch
				{
					isPossible = false;
				}
			}
			if (!isPossible)
			{
				Console.WriteLine("File Error");
			}*/
			return true;
		}

		private string[] ReturnSubarray(string[] args, int index, int length)
		{
			string[] result = new string[length];
			Array.Copy(args, index, result, 0, length);
			return result;
		}
		private static bool TestHighlightSpaces(string v)
		{
			return (v == "--highlight-spaces");
		}

		private static bool TestLineSizeValidity(string num)
		{
			bool argumentValid = true;
			try
			{
				int blockSize = int.Parse(num);
				if (blockSize <= 0)
				{
					argumentValid = false;
				}
			}
			catch
			{
				argumentValid = false;
			}
			return argumentValid;
		}
	}
}
