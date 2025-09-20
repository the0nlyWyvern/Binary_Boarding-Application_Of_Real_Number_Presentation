namespace BinaryBoarding
{
	public class Program
	{
		static void Main(String[] args)
		{
			// Question 1

			string code = "0RLRBFBFFFF";
			BoardingPass seat = new BoardingPass(code);

			Console.WriteLine($"Seat ID for {code} = {seat.GetId()}");//5.25

			// ---
			// Question 2

			string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
			string filePath = Path.Combine(projectRoot, "2.txt");

			double greatestAbsId = double.MinValue;

			foreach (string line in File.ReadLines(filePath))
			{
				BoardingPass pass = new BoardingPass(line);
				greatestAbsId = Math.Max(greatestAbsId, Math.Abs(pass.GetId()));
			}

			Console.WriteLine($"Seat ID with the greatest absolute value: {greatestAbsId}");
		}
	}
}