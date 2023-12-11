using System;

namespace CreateRecords
{
	class Record
	{
		public dynamic Value { get; set; }
		public DateTime Time { get; set; }
		public int Decimals { get; set; }

		public Record(int val)
		{
			Value = val;
			Time = DateTime.MinValue;
		}

		public Record(double val, int dp)
		{
			Value = val;
			Time = DateTime.MinValue;
			Decimals = dp;
		}

		public bool CheckHighRecord(int val, DateTime time)
		{
			if (val > Value)
			{
				Value = val;
				Time = time;
				return true;
			}
			return false;
		}
		public bool CheckHighRecord(double val, DateTime time)
		{
			if (Math.Round(val, Decimals) > Math.Round(Value, Decimals))
			{
				Value = val;
				Time = time;
				return true;
			}
			return false;
		}

		public bool CheckLowRecord(int val, DateTime time)
		{
			if (val < Value)
			{
				Value = val;
				Time = time;
				return true;
			}
			return false;
		}
		public bool CheckLowRecord(double val, DateTime time)
		{
			if (Math.Round(val, Decimals) < Math.Round(Value, Decimals))
			{
				Value = val;
				Time = time;
				return true;
			}
			return false;
		}
	}
}
