using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextToBlocksConverter;

namespace TextToBlocksConverter_MSTest
{
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
}
