

namespace CreateRecords
{
	class Records
	{
		public Record HighTemperature;
		public Record LowTemperature;

		public Record HighDewPoint;
		public Record LowDewPoint;

		public Record HighApparant;
		public Record LowApparant;

		public Record HighFeelsLike;
		public Record LowFeelsLike;

		public Record LowWindChill;

		public Record HighHeatIndex;

		public Record HighHumidex;

		public Record HighMinTemp;
		public Record LowMaxTemp;

		public Record HighHumidity;
		public Record LowHumidity;

		public Record HighDailyRange;
		public Record LowDailyRange;

		public Record HighRainRate;
		public Record HighHourlyRain;
		public Record HighDailyRain;
        public Record High24hRain;
        public Record HighMonthlyRain;

		public Record LongestDry;
		public Record LongestWet;

		public Record HighWindGust;
		public Record HighWindAvg;
		public Record HighWindRun;

		public Record HighPressure;
		public Record LowPressure;

		public Records()
		{
			HighTemperature = new Record(-9999.0, Program.cumulus.Units.TempDPlaces);
			LowTemperature = new Record(9999.0, Program.cumulus.Units.TempDPlaces);

			HighDewPoint = new Record(-9999.0, Program.cumulus.Units.TempDPlaces);
			LowDewPoint = new Record(9999.0, Program.cumulus.Units.TempDPlaces);

			HighApparant = new Record(-9999.0, Program.cumulus.Units.TempDPlaces);
			LowApparant = new Record(9999.0, Program.cumulus.Units.TempDPlaces);

			HighFeelsLike = new Record(-9999.0, Program.cumulus.Units.TempDPlaces);
			LowFeelsLike = new Record(9999.0, Program.cumulus.Units.TempDPlaces);

			LowWindChill = new Record(9999.0, Program.cumulus.Units.TempDPlaces);

			HighHeatIndex = new Record(-9999.0, Program.cumulus.Units.TempDPlaces);

			HighHumidex = new Record(-9999.0, Program.cumulus.Units.TempDPlaces);

			HighMinTemp = new Record(-9999.0, Program.cumulus.Units.TempDPlaces);
			LowMaxTemp = new Record(9999.0, Program.cumulus.Units.TempDPlaces);

			HighHumidity = new Record(-9999);
			LowHumidity = new Record(9999);

			HighDailyRange = new Record(-9999.0, Program.cumulus.Units.TempDPlaces);
			LowDailyRange = new Record(9999.0, Program.cumulus.Units.TempDPlaces);

			HighRainRate = new Record(-9999.0, Program.cumulus.Units.RainDPlaces);
			HighHourlyRain = new Record(-9999.0, Program.cumulus.Units.RainDPlaces);
			HighDailyRain = new Record(-9999.0, Program.cumulus.Units.RainDPlaces);
			High24hRain = new Record(-9999.0, Program.cumulus.Units.RainDPlaces);
			HighMonthlyRain = new Record(-9999.0, Program.cumulus.Units.RainDPlaces);

			LongestDry = new Record(0);
			LongestWet = new Record(0);

			HighWindGust = new Record(-9999.0, Program.cumulus.Units.WindDPlaces);
			HighWindAvg = new Record(-9999.0, Program.cumulus.Units.WindAvgDPlaces);
			HighWindRun = new Record(-9999.0, Program.cumulus.Units.WindRunDPlaces);

			HighPressure = new Record(-9999.0, Program.cumulus.Units.PressDPlaces);
			LowPressure = new Record(9999.0, Program.cumulus.Units.PressDPlaces);
		}
	}
}
