using CumulusMX;
using System;
using System.IO;

namespace CreateRecords
{
	class AllTime
	{
		public Records Recs = new Records();
		private static string filename = "data" + Path.DirectorySeparatorChar + "alltime.ini";

		public  AllTime()
		{
			ReadIniFile();
		}

		public void ReadIniFile()
		{
			if (File.Exists(filename))
			{
				var defTime = DateTime.MinValue;

				IniFile ini = new IniFile(filename);

				Recs.HighTemperature.Value = ini.GetValue("Temperature", "hightempvalue", -9999.0);
				Recs.HighTemperature.Time = ini.GetValue("Temperature", "hightemptime", defTime);

				Recs.LowTemperature.Value = ini.GetValue("Temperature", "lowtempvalue", 9999.0);
				Recs.LowTemperature.Time = ini.GetValue("Temperature", "lowtemptime", defTime);

				Recs.LowWindChill.Value = ini.GetValue("Temperature", "lowchillvalue", 9999.0);
				Recs.LowWindChill.Time = ini.GetValue("Temperature", "lowchilltime", defTime);

				Recs.HighMinTemp.Value = ini.GetValue("Temperature", "highmintempvalue", -9999.0);
				Recs.HighMinTemp.Time = ini.GetValue("Temperature", "highmintemptime", defTime);

				Recs.LowMaxTemp.Value = ini.GetValue("Temperature", "lowmaxtempvalue", 9999.0);
				Recs.LowMaxTemp.Time = ini.GetValue("Temperature", "lowmaxtemptime", defTime);

				Recs.HighApparant.Value = ini.GetValue("Temperature", "highapptempvalue", -9999.0);
				Recs.HighApparant.Time = ini.GetValue("Temperature", "highapptemptime", defTime);

				Recs.LowApparant.Value = ini.GetValue("Temperature", "lowapptempvalue", 9999.0);
				Recs.LowApparant.Time = ini.GetValue("Temperature", "lowapptemptime", defTime);

				Recs.HighFeelsLike.Value = ini.GetValue("Temperature", "highfeelslikevalue", -9999.0);
				Recs.HighFeelsLike.Time = ini.GetValue("Temperature", "highfeelsliketime", defTime);

				Recs.LowFeelsLike.Value = ini.GetValue("Temperature", "lowfeelslikevalue", 9999.0);
				Recs.LowFeelsLike.Time = ini.GetValue("Temperature", "lowfeelsliketime", defTime);

				Recs.HighHumidex.Value = ini.GetValue("Temperature", "highhumidexvalue", -9999.0);
				Recs.HighHumidex.Time = ini.GetValue("Temperature", "highhumidextime", defTime);

				Recs.HighHeatIndex.Value = ini.GetValue("Temperature", "highheatindexvalue", -9999.0);
				Recs.HighHeatIndex.Time = ini.GetValue("Temperature", "highheatindextime", defTime);

				Recs.HighDewPoint.Value = ini.GetValue("Temperature", "highdewpointvalue", -9999.0);
				Recs.HighDewPoint.Time = ini.GetValue("Temperature", "highdewpointtime", defTime);

				Recs.LowDewPoint.Value = ini.GetValue("Temperature", "lowdewpointvalue", 9999.0);
				Recs.LowDewPoint.Time = ini.GetValue("Temperature", "lowdewpointtime", defTime);

				Recs.HighDailyRange.Value = ini.GetValue("Temperature", "hightemprangevalue", 0.0);
				Recs.HighDailyRange.Time = ini.GetValue("Temperature", "hightemprangetime", defTime);

				Recs.LowDailyRange.Value = ini.GetValue("Temperature", "lowtemprangevalue", 9999.0);
				Recs.LowDailyRange.Time = ini.GetValue("Temperature", "lowtemprangetime", defTime);

				Recs.HighWindAvg.Value = ini.GetValue("Wind", "highwindvalue", 0.0);
				Recs.HighWindAvg.Time = ini.GetValue("Wind", "highwindtime", defTime);

				Recs.HighWindGust.Value = ini.GetValue("Wind", "highgustvalue", 0.0);
				Recs.HighWindGust.Time = ini.GetValue("Wind", "highgusttime", defTime);

				Recs.HighWindRun.Value = ini.GetValue("Wind", "highdailywindrunvalue", 0.0);
				Recs.HighWindRun.Time = ini.GetValue("Wind", "highdailywindruntime", defTime);

				Recs.HighRainRate.Value = ini.GetValue("Rain", "highrainratevalue", 0.0);
				Recs.HighRainRate.Time = ini.GetValue("Rain", "highrainratetime", defTime);

				Recs.HighDailyRain.Value = ini.GetValue("Rain", "highdailyrainvalue", 0.0);
				Recs.HighDailyRain.Time = ini.GetValue("Rain", "highdailyraintime", defTime);

                Recs.High24hRain.Value = ini.GetValue("Rain", "high24hourrainvalue", 0.0);
                Recs.High24hRain.Time = ini.GetValue("Rain", "high24hourraintime", defTime);

                Recs.HighHourlyRain.Value = ini.GetValue("Rain", "highhourlyrainvalue", 0.0);
				Recs.HighHourlyRain.Time = ini.GetValue("Rain", "highhourlyraintime", defTime);

				Recs.HighMonthlyRain.Value = ini.GetValue("Rain", "highmonthlyrainvalue", 0.0);
				Recs.HighMonthlyRain.Time = ini.GetValue("Rain", "highmonthlyraintime", defTime);

				Recs.LongestDry.Value = ini.GetValue("Rain", "longestdryperiodvalue", 0);
				Recs.LongestDry.Time = ini.GetValue("Rain", "longestdryperiodtime", defTime);

				Recs.LongestWet.Value = ini.GetValue("Rain", "longestwetperiodvalue", 0);
				Recs.LongestWet.Time = ini.GetValue("Rain", "longestwetperiodtime", defTime);

				Recs.HighPressure.Value = ini.GetValue("Pressure", "highpressurevalue", 0.0);
				Recs.HighPressure.Time = ini.GetValue("Pressure", "highpressuretime", defTime);

				Recs.LowPressure.Value = ini.GetValue("Pressure", "lowpressurevalue", 9999.0);
				Recs.LowPressure.Time = ini.GetValue("Pressure", "lowpressuretime", defTime);

				Recs.HighHumidity.Value = ini.GetValue("Humidity", "highhumidityvalue", 0);
				Recs.HighHumidity.Time = ini.GetValue("Humidity", "highhumiditytime", defTime);

				Recs.LowHumidity.Value = ini.GetValue("Humidity", "lowhumidityvalue", 999);
				Recs.LowHumidity.Time = ini.GetValue("Humidity", "lowhumiditytime", defTime);

				Program.LogMessage("Completed alltime.ini file read");
			}
			else
			{
				Program.LogMessage("No alltime.ini file found");
			}
		}

		public void WriteIniFile()
		{
			// backup original file
			if (File.Exists(filename))
			{
				File.Move(filename, filename + ".sav");
			}

			try
			{
				IniFile ini = new IniFile(filename);

				ini.SetValue("Temperature", "hightempvalue", Recs.HighTemperature.Value);
				ini.SetValue("Temperature", "hightemptime", Recs.HighTemperature.Time);
				ini.SetValue("Temperature", "lowtempvalue", Recs.LowTemperature.Value);
				ini.SetValue("Temperature", "lowtemptime", Recs.LowTemperature.Time);
				ini.SetValue("Temperature", "lowchillvalue", Recs.LowWindChill.Value);
				ini.SetValue("Temperature", "lowchilltime", Recs.LowWindChill.Time);
				ini.SetValue("Temperature", "highmintempvalue", Recs.HighMinTemp.Value);
				ini.SetValue("Temperature", "highmintemptime", Recs.HighMinTemp.Time);
				ini.SetValue("Temperature", "lowmaxtempvalue", Recs.LowMaxTemp.Value);
				ini.SetValue("Temperature", "lowmaxtemptime", Recs.LowMaxTemp.Time);
				ini.SetValue("Temperature", "highapptempvalue", Recs.HighApparant.Value);
				ini.SetValue("Temperature", "highapptemptime", Recs.HighApparant.Time);
				ini.SetValue("Temperature", "lowapptempvalue", Recs.LowApparant.Value);
				ini.SetValue("Temperature", "lowapptemptime", Recs.LowApparant.Time);
				ini.SetValue("Temperature", "highfeelslikevalue", Recs.HighFeelsLike.Value);
				ini.SetValue("Temperature", "highfeelsliketime", Recs.HighFeelsLike.Time);
				ini.SetValue("Temperature", "lowfeelslikevalue", Recs.LowFeelsLike.Value);
				ini.SetValue("Temperature", "lowfeelsliketime", Recs.LowFeelsLike.Time);
				ini.SetValue("Temperature", "highhumidexvalue", Recs.HighHumidex.Value);
				ini.SetValue("Temperature", "highhumidextime", Recs.HighHumidex.Time);
				ini.SetValue("Temperature", "highheatindexvalue", Recs.HighHeatIndex.Value);
				ini.SetValue("Temperature", "highheatindextime", Recs.HighHeatIndex.Time);
				ini.SetValue("Temperature", "highdewpointvalue", Recs.HighDewPoint.Value);
				ini.SetValue("Temperature", "highdewpointtime", Recs.HighDewPoint.Time);
				ini.SetValue("Temperature", "lowdewpointvalue", Recs.LowDewPoint.Value);
				ini.SetValue("Temperature", "lowdewpointtime", Recs.LowDewPoint.Time);
				ini.SetValue("Temperature", "hightemprangevalue", Recs.HighDailyRange.Value);
				ini.SetValue("Temperature", "hightemprangetime", Recs.HighDailyRange.Time);
				ini.SetValue("Temperature", "lowtemprangevalue", Recs.LowDailyRange.Value);
				ini.SetValue("Temperature", "lowtemprangetime", Recs.LowDailyRange.Time);
				ini.SetValue("Wind", "highwindvalue", Recs.HighWindAvg.Value);
				ini.SetValue("Wind", "highwindtime", Recs.HighWindAvg.Time);
				ini.SetValue("Wind", "highgustvalue", Recs.HighWindGust.Value);
				ini.SetValue("Wind", "highgusttime", Recs.HighWindGust.Time);
				ini.SetValue("Wind", "highdailywindrunvalue", Recs.HighWindRun.Value);
				ini.SetValue("Wind", "highdailywindruntime", Recs.HighWindRun.Time);
				ini.SetValue("Rain", "highrainratevalue", Recs.HighRainRate.Value);
				ini.SetValue("Rain", "highrainratetime", Recs.HighRainRate.Time);
				ini.SetValue("Rain", "highdailyrainvalue", Recs.HighDailyRain.Value);
				ini.SetValue("Rain", "highdailyraintime", Recs.HighDailyRain.Time);
				ini.SetValue("Rain", "highhourlyrainvalue", Recs.HighHourlyRain.Value);
				ini.SetValue("Rain", "highhourlyraintime", Recs.HighHourlyRain.Time);
				ini.SetValue("Rain", "highmonthlyrainvalue", Recs.HighMonthlyRain.Value);
				ini.SetValue("Rain", "highmonthlyraintime", Recs.HighMonthlyRain.Time);
				ini.SetValue("Rain", "longestdryperiodvalue", Recs.LongestDry.Value);
				ini.SetValue("Rain", "longestdryperiodtime", Recs.LongestDry.Time);
				ini.SetValue("Rain", "longestwetperiodvalue", Recs.LongestWet.Value);
				ini.SetValue("Rain", "longestwetperiodtime", Recs.LongestWet.Time);
                ini.SetValue("Rain", "high24hourrainvalue", Recs.High24hRain.Value);
                ini.SetValue("Rain", "high24hourraintime", Recs.High24hRain.Time);
                ini.SetValue("Pressure", "highpressurevalue", Recs.HighPressure.Value);
				ini.SetValue("Pressure", "highpressuretime", Recs.HighPressure.Time);
				ini.SetValue("Pressure", "lowpressurevalue", Recs.LowPressure.Value);
				ini.SetValue("Pressure", "lowpressuretime", Recs.LowPressure.Time);
				ini.SetValue("Humidity", "highhumidityvalue", Recs.HighHumidity.Value);
				ini.SetValue("Humidity", "highhumiditytime", Recs.HighHumidity.Time);
				ini.SetValue("Humidity", "lowhumidityvalue", Recs.LowHumidity.Value);
				ini.SetValue("Humidity", "lowhumiditytime", Recs.LowHumidity.Time);

				ini.Flush();
			}
			catch (Exception ex)
			{
				Program.LogMessage("Error writing alltime.ini file: " + ex.Message);
			}
		}
	}
}
