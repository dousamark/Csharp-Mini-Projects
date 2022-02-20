using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextToBlocksConverter;

namespace TextToBlocksConverter_MSTest
{
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
}
