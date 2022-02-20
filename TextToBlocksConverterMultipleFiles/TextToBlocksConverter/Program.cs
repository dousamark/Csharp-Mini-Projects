using System;
using System.IO;

[assembly:System.Runtime.CompilerServices.InternalsVisibleTo("TextToBlocksConverter_MSTest")]

namespace TextToBlocksConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			if (Args.TestValidity(args))
			{
				MultiFormater multiFormater = new MultiFormater(args);
				multiFormater.FormateMultipleFiles(args);
			}
		}
	}
	/*
	   [TestClass]
		public class ArgsChecks
		{
			[TestMethod]
			public void WithoutHighlighted_test()
			{
				//arrange
				string[] args = new string[] { "plain.txt", "form.txt", "12" };

				//act
				bool TestValidityOutput = Args.TestValidity(args);

				//assert
				Assert.AreEqual(true, TestValidityOutput);
			}
			[TestMethod]
			public void WithoutHLightLastArgNotInt_test()
			{
				// arrange
				string[] args = new string[4] { "plain.txt", "plain.txt", "format.txt", "mm" };

				// act
				bool TestValidityOutput = Args.TestValidity(args);

				// assert
				Assert.AreEqual(false, TestValidityOutput);
			}
			[TestMethod]
			public void WithoutHLightWrongNumberOfParameters_test()
			{
				// arrange
				string[] args = new string[2] { "format.txt", "mm" };

				// act
				bool TestValidityOutput = Args.TestValidity(args);

				// assert
				Assert.AreEqual(false, TestValidityOutput);
			}
			[TestMethod]
			public void WithHLightCorrect_test()
			{
				// arrange
				string[] args = new string[4] { "--highlight-spaces", "plain.txt", "format.txt", "12" };

				//act
				bool TestValidityOutput = Args.TestValidity(args);

				//assert
				Assert.AreEqual(true, TestValidityOutput);
			}
			[TestMethod]
			public void WithHLightWrongNumberOfParameters_test()
			{
				// arrange
				string[] args = new string[3] { "--highlight-spaces", "format.txt", "12" };

				// act
				bool TestValidityOutput = Args.TestValidity(args);

				// assert
				Assert.AreEqual(false, TestValidityOutput);
			}
			[TestMethod]
			public void WithHLightLastNotInt_test()
			{
				// arrange
				string[] args = new string[4] { "--highlight-spaces", "plain.txt", "format.txt", "mm" };

				// act
				bool TestValidityOutput = Args.TestValidity(args);

				// assert
				Assert.AreEqual(false, TestValidityOutput);
			}
		}


		[TestClass]
	public class ReaderTests
	{
		[TestMethod]
		public void IsWhiteSpaceCorrect_test()
		{
			//arrange
			TextReader reader = new TextReader("a.txt");

			//act
			bool whiteSpacetest = reader.IsWhiteSpace('\r') && reader.IsWhiteSpace(' ') && reader.IsWhiteSpace('\t') && reader.IsWhiteSpace('\n');
			
			//assert
			Assert.AreEqual(true, whiteSpacetest);
		}
		[TestMethod]
		public void IsWhiteSpaceNotCorrect_test()
		{
			//arrange
			TextReader reader = new TextReader("a.txt");
			
			//act
			bool whiteSpacetest = reader.IsWhiteSpace('a') || reader.IsWhiteSpace('8');
			
			//assert
			Assert.AreEqual(false, whiteSpacetest);
		}
	}



	[TestClass]
	public class FormaterTests
	{
		[TestMethod]
		public void NumberOfCharactersOneWordCorrect_test()
		{
			//arrange
			List<string> words = new List<string> { "word" };

			//act
			bool Output = words[0].Length == Formater.GetNumberOfChars(words);

			//assert
			Assert.AreEqual(true, Output);
		}
		[TestMethod]
		public void NumberOfCharactersMultipleWordsCorrect_test()
		{
			//arrange
			List<string> words = new List<string> { "word", "wordy", "wordity" };

			//act
			bool Output = words[0].Length + words[1].Length + words[2].Length + 2 == Formater.GetNumberOfChars(words);

			//assert
			Assert.AreEqual(true, Output);
		}
		[TestMethod]
		public void SpaceBetweenWordsCorrect_test()
		{
			//arrange
			List<string> words = new List<string> { "word", "wordy", "wordity" };

			//act
			bool Output = "word wordy wordity" == Formater.PutOneSpaceBetweenWords(words);

			//assert
			Assert.AreEqual(true, Output);
		}
		[TestMethod]
		public void FillSpacesBetweenWordsCorrect_test()
		{
			//arrange
			List<string> words = new List<string> { "word", "wordy", "wordity" };
			int lineSize = 21;

			//act
			bool Output = "word   wordy  wordity" == Formater.FillInSpaces(words,lineSize);

			//assert
			Assert.AreEqual(true, Output);
		}
	}
	 */
}
