using System;
using System.Collections.Generic;
using System.Text;

namespace TextToBlocksConverter
{
	class Formater
	{
		Args args;
		TextReader TextReader;
		string wordToBeAdded;

		public Formater(string[] arguments, int index)
		{
			args = new Args(arguments);
			TextReader = new TextReader(args.filesIn[index]);
		}

		public void FormateText()
		{
			while (!TextReader.fileRead)
			{
				ReadOneLine();
			}
			if (wordToBeAdded != null)
			{
				MultiFormater.wordsToBeAdded.Add(wordToBeAdded);
				wordToBeAdded = null;
			}
		}

		public void ReadOneLine()
		{
			
			bool lineFull = false;
			List<string> words = new List<string> (MultiFormater.wordsToBeAdded);
			MultiFormater.wordsToBeAdded.Clear();
			int charsInLine = GetNumberOfChars(words);

			// If there was a word from previous line we need to add it first
			if (wordToBeAdded != null)
			{
				words.Add(wordToBeAdded);
				charsInLine += wordToBeAdded.Length;

				//if its longer than the whole lineSize add it right away
				if (wordToBeAdded.Length > args.lineSize)
				{
					MultiFormater.TextWriter.WriteLine(wordToBeAdded, true);
					lineFull = true;
				}
				wordToBeAdded = null;
			}

			while (!lineFull)
			{
				if (SkipBlanks())
				{
					// New paragraph detected
					MultiFormater.TextWriter.WriteLine(PutOneSpaceBetweenWords(words), true);
					if (!TextReader.fileRead)
					{
						MultiFormater.TextWriter.WriteLine("", true);
					}
					wordToBeAdded = null;
					lineFull = true;
				}
				else
				{
					string nextWord = ReadOneWord();

					if (TextReader.fileRead && nextWord == "")
					{
						MultiFormater.wordsToBeAdded.AddRange(words);
						break;
					}
					//adds a character for a space
					if (words.Count != 0)
					{
						charsInLine++;
					}

					charsInLine += nextWord.Length;
					if (words.Count == 0 && nextWord.Length > args.lineSize)
					{
						// One long word on the line
						MultiFormater.TextWriter.WriteLine(nextWord, true);
						lineFull = true;
					}
					else if (charsInLine > args.lineSize)
					{
						// The nextWord doesnt fit on this line
						MultiFormater.TextWriter.WriteLine(FillInSpaces(words, MultiFormater.args.lineSize), true);
						wordToBeAdded = nextWord;
						lineFull = true;
					}
					else
					{
						words.Add(nextWord);
						//nextWord = null;
					}
				}
			}
		}

		public static int GetNumberOfChars(List<string> words)
		{
			if(words.Count==0) { return 0; }
			int chars = -1;
			foreach(string word in words)
			{
				chars += word.Length + 1;
			}
			return chars;
		}

		public static string PutOneSpaceBetweenWords(List<string> words)
		{
			StringBuilder line = new StringBuilder();
			if (words.Count > 0)
				line.Append(words[0]);

			for (int i = 1; i < words.Count; i++)
			{
				line.Append(' ' + words[i]);
			}
			return line.ToString();
		}


		public static string FillInSpaces(List<string> words, int lineSize)
		{
			if (words.Count == 1)
			{
				return words[0].ToString();
			}

			int nOfSpaces = words.Count - 1;
			int charCount = 0;
			foreach (var word in words)
			{
				charCount += word.Length;
			}
			string[] extendedSpaces = new string[nOfSpaces];
			int newSpaceSize = (int)((lineSize - charCount) / nOfSpaces);
			int remainingSpaces = (lineSize - charCount) % nOfSpaces;
			for (int i = 0; i < extendedSpaces.Length; i++)
			{
				extendedSpaces[i] = nSpaceString(newSpaceSize);
				if (i < remainingSpaces)
				{
					extendedSpaces[i] += ' ';
				}
			}
			string outString = "";
			for (int i = 0; i < nOfSpaces; i++)
			{
				outString += words[i] + extendedSpaces[i];
			}
			outString += words[nOfSpaces];
			return outString;
		}
		private static string nSpaceString(int newSpaceSize)
		{
			string outString = "";
			for (int i = 0; i < newSpaceSize; i++)
			{
				outString += ' ';
			}
			return outString;
		}
		public string ReadOneWord()
		{
			StringBuilder word = new StringBuilder();
			bool fileHasBeenRead = TextReader.PeekChar() == -1;
			bool nextCharIsBlank = TextReader.IsWhiteSpace((char)TextReader.PeekChar());
			while (!fileHasBeenRead && !nextCharIsBlank)
			{
				word.Append((char)TextReader.nextChar());
				fileHasBeenRead = TextReader.PeekChar() == -1;
				nextCharIsBlank = TextReader.IsWhiteSpace((char)TextReader.PeekChar());
				//TextReader.SkipChar();
			}
			return word.ToString();
		}

		//returns boolean if two linebreaks have been found
		public bool SkipBlanks()
		{
			bool foundOneLineBreak = false;
			bool foundTwoLineBreaks = false;
			while (TextReader.IsWhiteSpace((char)TextReader.PeekChar()))
			{
				if ((char)TextReader.PeekChar() == '\n')
				{
					if (foundOneLineBreak)
					{
						foundTwoLineBreaks = true;
					}
					foundOneLineBreak = true;
				}
				TextReader.SkipChar();
			}
			return foundTwoLineBreaks;
		}
	}
}
