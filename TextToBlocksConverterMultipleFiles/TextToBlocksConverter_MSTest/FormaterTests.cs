using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TextToBlocksConverter;

namespace TextToBlocksConverter_MSTest
{
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
}
