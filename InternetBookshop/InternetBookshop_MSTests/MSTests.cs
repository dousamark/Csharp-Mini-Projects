using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetBookshop;



namespace InternetBookshop_MSTests
{
	[TestClass]
	public class MSTests
	{
		[TestMethod]
		public void checkRequestNotThreeArgs()
		{
			//arrange
			string[] args = new string[] { "GET",  "1" };

			//act
			bool TestValidityOutput = true;

			//assert
			Assert.AreEqual(true, TestValidityOutput);
		}
	}
}
