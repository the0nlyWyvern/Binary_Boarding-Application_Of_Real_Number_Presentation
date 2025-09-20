namespace BinaryBoarding
{
	public class BoardingPass
	{
		private string _code;

		private bool _IsFirstClass;
		private int _row;
		private int _col;
		private double _id;

		public BoardingPass(string code)
		{
			_code = code;

			FindClass();
			FindRow();
			FindColumn();
			FindId();
		}

		public double GetId()
		{
			return _id;
		}

		private void FindClass()
		{
			if (_code[0] == '1')
				_IsFirstClass = true; // first class
			else
				_IsFirstClass = false; // coach class
		}

		private void FindRow()
		{
			for (int i = _code.Length - 1; i >= 4; i--)
			{
				if (_code[i] == 'B')
					_row += (int)Math.Pow(2, 10 - i);
			}
		}

		private void FindColumn()
		{
			for (int i = 3; i >= 0; i--)
			{
				if (_code[i] == 'R')
					_col += (int)Math.Pow(2, 3 - i);
			}
		}
		private void FindId()
		{
			_id = ((double)_row / 256 + 1) * Math.Pow(2, _col - 3);

			if (_IsFirstClass)
				_id *= -1;
		}
	}
}
