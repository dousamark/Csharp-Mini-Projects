using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextToBlocksConverter
{
	class MultiFormater
	{
		public string[] filesIn;
		public static TextWriter TextWriter;
		public static List<string> wordsToBeAdded;
		public static Args args;

		public MultiFormater(string[] arguments)
		{
			args = new Args(arguments);
			TextWriter = new TextWriter(args.fileOut);
			filesIn = args.filesIn;
			wordsToBeAdded = new List<string>();
		}

		internal void FormateMultipleFiles(string[] arguments)
		{
			for (int i = 0; i < filesIn.Length; i++)
			{
				bool fileIsOpenable = true;
				try
				{
					StreamReader reader = new StreamReader(filesIn[i]);
				}
				catch
				{
					fileIsOpenable = false;
				}
				if (fileIsOpenable)
				{
					Formater formater = new Formater(arguments, i);
					formater.FormateText();
				}
			}
			if (wordsToBeAdded.Count != 0)
			{
				TextWriter.WriteLine(Formater.PutOneSpaceBetweenWords(wordsToBeAdded), true);
			}
		}
	}
}
