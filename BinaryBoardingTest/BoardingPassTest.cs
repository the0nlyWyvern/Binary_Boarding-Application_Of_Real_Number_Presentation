using BinaryBoarding;

namespace BinaryBoardingTest
{
	[TestFixture]
	public class BoardingPassTest
	{
		[Test]
		public void FindPairTest_1RLRFBFBBFF()
		{
			// Arrange
			string code = "1RLRFBFBBFF";
			double expectedId = -4.6875;

			// Act
			BoardingPass pass = new BoardingPass(code);
			double actualId = pass.GetId();

			// Assert
			Assert.That(actualId, Is.EqualTo(expectedId));
		}

		[Test]
		public void FindPairTest_0RRRBFFFBBF()
		{
			// Arrange
			string code = "0RRRBFFFBBF";
			double expectedId = 20.375;

			// Act
			BoardingPass pass = new BoardingPass(code);
			double actualId = pass.GetId();

			// Assert
			Assert.That(actualId, Is.EqualTo(expectedId));
		}

		[Test]
		public void FindPairTest_1RRRFFFBBBF()
		{
			// Arrange
			string code = "1RRRFFFBBBF";
			double expectedId = -16.875;

			// Act
			BoardingPass pass = new BoardingPass(code);
			double actualId = pass.GetId();

			// Assert
			Assert.That(actualId, Is.EqualTo(expectedId));
		}

		[Test]
		public void FindPairTest_0RLLBBFFBBF()
		{
			// Arrange
			string code = "0RLLBBFFBBF";
			double expectedId = 2.796875;

			// Act
			BoardingPass pass = new BoardingPass(code);
			double actualId = pass.GetId();

			// Assert
			Assert.That(actualId, Is.EqualTo(expectedId));
		}
	}
}
