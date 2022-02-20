using Huffmanovo_kódování;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Huffmanovo_kódování_testy
{
	[TestClass]
	public class MSTest
	{
		[TestMethod]
		public void NotRightLength()
		{
			//arrange
			string[] args = { "simple.in", "simple.in" };
			//act
			bool TestValidityOutput = ArgsValidization.ArgsValid(args);
			//assert
			Assert.AreEqual(false, TestValidityOutput);
		}
		[TestMethod]
		public void NotExistingFile()
		{
			//arrange
			string[] args = { "neexistuje.in" };
			//act
			bool TestValidityOutput = ArgsValidization.ArgsValid(args);
			//assert
			Assert.AreEqual(false, TestValidityOutput);
		}
		[TestMethod]
		public void RightLenghtAndExistingFile()
		{
			//arrange

			string[] args = { "Test data\\simple.in" };
			//act
			bool TestValidityOutput = ArgsValidization.ArgsValid(args);
			//assert
			Assert.AreEqual(true, TestValidityOutput);
		}
	}
}
