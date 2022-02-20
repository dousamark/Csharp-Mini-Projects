using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextToBlocksConverter
{
	class TextWriter
	{
		private string fileOut;

		public TextWriter(string fileOut)
		{
			this.fileOut = fileOut;
		}

		public void WriteLine(string line, bool notLast)
		{

			/*if (notLast) 
			{ */
			if (MultiFormater.args.highlightSpaces)
			{
				File.AppendAllText(fileOut, line.Replace(' ','.') + "<-" + Environment.NewLine);
			}
			else
			{
				File.AppendAllText(fileOut, line + Environment.NewLine);
			}
				
				//Console.WriteLine(line);
			/*}
			else
			{
				File.AppendAllText(fileOut, line);
				Console.Write(line);
			}*/
		}
	}
}
