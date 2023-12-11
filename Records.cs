

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
			HighTemperature = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.TempDPlaces);
			LowTemperature = new Record(Cumulus.DefaultLoVal, Program.cumulus.Units.TempDPlaces);

			HighDewPoint = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.TempDPlaces);
			LowDewPoint = new Record(Cumulus.DefaultLoVal, Program.cumulus.Units.TempDPlaces);

			HighApparant = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.TempDPlaces);
			LowApparant = new Record(Cumulus.DefaultLoVal, Program.cumulus.Units.TempDPlaces);

			HighFeelsLike = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.TempDPlaces);
			LowFeelsLike = new Record(Cumulus.DefaultLoVal, Program.cumulus.Units.TempDPlaces);

			LowWindChill = new Record(Cumulus.DefaultLoVal, Program.cumulus.Units.TempDPlaces);

			HighHeatIndex = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.TempDPlaces);

			HighHumidex = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.TempDPlaces);

			HighMinTemp = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.TempDPlaces);
			LowMaxTemp = new Record(Cumulus.DefaultLoVal, Program.cumulus.Units.TempDPlaces);

			HighHumidity = new Record((int) Cumulus.DefaultHiVal);
			LowHumidity = new Record((int)Cumulus.DefaultLoVal);

			HighDailyRange = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.TempDPlaces);
			LowDailyRange = new Record(Cumulus.DefaultLoVal, Program.cumulus.Units.TempDPlaces);

			HighRainRate = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.RainDPlaces);
			HighHourlyRain = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.RainDPlaces);
			HighDailyRain = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.RainDPlaces);
			High24hRain = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.RainDPlaces);
			HighMonthlyRain = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.RainDPlaces);

			LongestDry = new Record(0);
			LongestWet = new Record(0);

			HighWindGust = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.WindDPlaces);
			HighWindAvg = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.WindAvgDPlaces);
			HighWindRun = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.WindRunDPlaces);

			HighPressure = new Record(Cumulus.DefaultHiVal, Program.cumulus.Units.PressDPlaces);
			LowPressure = new Record(Cumulus.DefaultLoVal, Program.cumulus.Units.PressDPlaces);
		}
	}
}
