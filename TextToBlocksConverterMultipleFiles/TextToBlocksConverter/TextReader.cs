using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextToBlocksConverter
{
	class TextReader
	{
		public bool fileRead;
		StreamReader reader;

		public TextReader(string fileIn)
		{
			reader = new StreamReader(fileIn);
		}

		public bool IsWhiteSpace(char ch)
		{
			return (ch == '\n' || ch == '\t' || ch == ' ' || ch=='\r');
		}

		public int nextChar()
		{
			if (fileRead)
			{
				return -1;
			}
			else
			{
				int readOne = reader.Read();
				if (readOne == -1)
				{
					fileRead = true;
				}
				if (readOne == '\r')
				{
					while (readOne == '\r')
					{
						readOne = reader.Read();
					}
				}
				return readOne;
			}
		}

		public int PeekChar()
		{
			if (fileRead) { return -1; }
			else
			{
				int peakedChar = reader.Peek();
				if (peakedChar == -1) { fileRead = true; }
				return peakedChar;
				//return reader.Peek();
			}
		}

		public void SkipChar()
		{
			reader.Read();
		}
	}
}
