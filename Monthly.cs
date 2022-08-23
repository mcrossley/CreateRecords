using CumulusMX;
using System;
using System.Collections.Generic;
using System.IO;

namespace CreateRecords
{
	class Monthly
	{
		public List<Records> Recs = new List<Records>(13);
		private static string filename = "data" + Path.DirectorySeparatorChar + "monthlyalltime.ini";

		public Monthly()
		{
			for (var i = 0; i < 13; i++)
				Recs.Add(new Records());

			ReadIniFile();
		}


		public void ReadIniFile()
		{
			if (File.Exists(filename))
			{
				var defTime = DateTime.MinValue;

				IniFile ini = new IniFile(filename);
				for (int month = 1; month <= 12; month++)
				{
					string monthstr = month.ToString("D2");

					Recs[month].HighTemperature.Value = ini.GetValue("Temperature" + monthstr, "hightempvalue", -9999.0);
					Recs[month].HighTemperature.Time = ini.GetValue("Temperature" + monthstr, "hightemptime", defTime);

					Recs[month].LowTemperature.Value = ini.GetValue("Temperature" + monthstr, "lowtempvalue", 9999.0);
					Recs[month].LowTemperature.Time = ini.GetValue("Temperature" + monthstr, "lowtemptime", defTime);

					Recs[month].LowWindChill.Value = ini.GetValue("Temperature" + monthstr, "lowchillvalue", 9999.0);
					Recs[month].LowWindChill.Time = ini.GetValue("Temperature" + monthstr, "lowchilltime", defTime);

					Recs[month].HighMinTemp.Value = ini.GetValue("Temperature" + monthstr, "highmintempvalue", -9999.0);
					Recs[month].HighMinTemp.Time = ini.GetValue("Temperature" + monthstr, "highmintemptime", defTime);

					Recs[month].LowMaxTemp.Value = ini.GetValue("Temperature" + monthstr, "lowmaxtempvalue", 9999.0);
					Recs[month].LowMaxTemp.Time = ini.GetValue("Temperature" + monthstr, "lowmaxtemptime", defTime);

					Recs[month].HighApparant.Value = ini.GetValue("Temperature" + monthstr, "highapptempvalue", -9999.0);
					Recs[month].HighApparant.Time = ini.GetValue("Temperature" + monthstr, "highapptemptime", defTime);

					Recs[month].LowApparant.Value = ini.GetValue("Temperature" + monthstr, "lowapptempvalue", 9999.0);
					Recs[month].LowApparant.Time = ini.GetValue("Temperature" + monthstr, "lowapptemptime", defTime);

					Recs[month].HighFeelsLike.Value = ini.GetValue("Temperature" + monthstr, "highfeelslikevalue", -9999.0);
					Recs[month].HighFeelsLike.Time = ini.GetValue("Temperature" + monthstr, "highfeelsliketime", defTime);

					Recs[month].LowFeelsLike.Value = ini.GetValue("Temperature" + monthstr, "lowfeelslikevalue", 9999.0);
					Recs[month].LowFeelsLike.Time = ini.GetValue("Temperature" + monthstr, "lowfeelsliketime", defTime);

					Recs[month].HighHumidex.Value = ini.GetValue("Temperature" + monthstr, "highhumidexvalue", -9999.0);
					Recs[month].HighHumidex.Time = ini.GetValue("Temperature" + monthstr, "highhumidextime", defTime);

					Recs[month].HighHeatIndex.Value = ini.GetValue("Temperature" + monthstr, "highheatindexvalue", -9999.0);
					Recs[month].HighHeatIndex.Time = ini.GetValue("Temperature" + monthstr, "highheatindextime", defTime);

					Recs[month].HighDewPoint.Value = ini.GetValue("Temperature" + monthstr, "highdewpointvalue", -9999.0);
					Recs[month].HighDewPoint.Time = ini.GetValue("Temperature" + monthstr, "highdewpointtime", defTime);

					Recs[month].LowDewPoint.Value = ini.GetValue("Temperature" + monthstr, "lowdewpointvalue", 9999.0);
					Recs[month].LowDewPoint.Time = ini.GetValue("Temperature" + monthstr, "lowdewpointtime", defTime);

					Recs[month].HighDailyRange.Value = ini.GetValue("Temperature" + monthstr, "hightemprangevalue", 0.0);
					Recs[month].HighDailyRange.Time = ini.GetValue("Temperature" + monthstr, "hightemprangetime", defTime);

					Recs[month].LowDailyRange.Value = ini.GetValue("Temperature" + monthstr, "lowtemprangevalue", 9999.0);
					Recs[month].LowDailyRange.Time = ini.GetValue("Temperature" + monthstr, "lowtemprangetime", defTime);

					Recs[month].HighWindAvg.Value = ini.GetValue("Wind" + monthstr, "highwindvalue", 0.0);
					Recs[month].HighWindAvg.Time = ini.GetValue("Wind" + monthstr, "highwindtime", defTime);

					Recs[month].HighWindGust.Value = ini.GetValue("Wind" + monthstr, "highgustvalue", 0.0);
					Recs[month].HighWindGust.Time = ini.GetValue("Wind" + monthstr, "highgusttime", defTime);

					Recs[month].HighWindRun.Value = ini.GetValue("Wind" + monthstr, "highdailywindrunvalue", 0.0);
					Recs[month].HighWindRun.Time = ini.GetValue("Wind" + monthstr, "highdailywindruntime", defTime);

					Recs[month].HighRainRate.Value = ini.GetValue("Rain" + monthstr, "highrainratevalue", 0.0);
					Recs[month].HighRainRate.Time = ini.GetValue("Rain" + monthstr, "highrainratetime", defTime);

					Recs[month].HighDailyRain.Value = ini.GetValue("Rain" + monthstr, "highdailyrainvalue", 0.0);
					Recs[month].HighDailyRain.Time = ini.GetValue("Rain" + monthstr, "highdailyraintime", defTime);

                    Recs[month].High24hRain.Value = ini.GetValue("Rain" + monthstr, "high24hourrainvalue", 0.0);
                    Recs[month].High24hRain.Time = ini.GetValue("Rain" + monthstr, "high24hourraintime", defTime);

                    Recs[month].HighHourlyRain.Value = ini.GetValue("Rain" + monthstr, "highhourlyrainvalue", 0.0);
					Recs[month].HighHourlyRain.Time = ini.GetValue("Rain" + monthstr, "highhourlyraintime", defTime);

					Recs[month].HighMonthlyRain.Value = ini.GetValue("Rain" + monthstr, "highmonthlyrainvalue", 0.0);
					Recs[month].HighMonthlyRain.Time = ini.GetValue("Rain" + monthstr, "highmonthlyraintime", defTime);

					Recs[month].LongestDry.Value = ini.GetValue("Rain" + monthstr, "longestdryperiodvalue", 0);
					Recs[month].LongestDry.Time = ini.GetValue("Rain" + monthstr, "longestdryperiodtime", defTime);

					Recs[month].LongestWet.Value = ini.GetValue("Rain" + monthstr, "longestwetperiodvalue", 0);
					Recs[month].LongestWet.Time = ini.GetValue("Rain" + monthstr, "longestwetperiodtime", defTime);

					Recs[month].HighPressure.Value = ini.GetValue("Pressure" + monthstr, "highpressurevalue", 0.0);
					Recs[month].HighPressure.Time = ini.GetValue("Pressure" + monthstr, "highpressuretime", defTime);

					Recs[month].LowPressure.Value = ini.GetValue("Pressure" + monthstr, "lowpressurevalue", 9999.0);
					Recs[month].LowPressure.Time = ini.GetValue("Pressure" + monthstr, "lowpressuretime", defTime);

					Recs[month].HighHumidity.Value = ini.GetValue("Humidity" + monthstr, "highhumidityvalue", 0.0);
					Recs[month].HighHumidity.Time = ini.GetValue("Humidity" + monthstr, "highhumiditytime", defTime);

					Recs[month].LowHumidity.Value = ini.GetValue("Humidity" + monthstr, "lowhumidityvalue", 9999.0);
					Recs[month].LowHumidity.Time = ini.GetValue("Humidity" + monthstr, "lowhumiditytime", defTime);
				}

				Program.LogMessage("Completed monthlyAlltime.ini file read");
			}
			else
			{
				Program.LogMessage("No monthlyAlltime.ini file found");
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
				for (int month = 1; month <= 12; month++)
				{
					string monthstr = month.ToString("D2");

					ini.SetValue("Temperature" + monthstr, "hightempvalue", Recs[month].HighTemperature.Value);
					ini.SetValue("Temperature" + monthstr, "hightemptime", Recs[month].HighTemperature.Time);
					ini.SetValue("Temperature" + monthstr, "lowtempvalue", Recs[month].LowTemperature.Value);
					ini.SetValue("Temperature" + monthstr, "lowtemptime", Recs[month].LowTemperature.Time);
					ini.SetValue("Temperature" + monthstr, "lowchillvalue", Recs[month].LowWindChill.Value);
					ini.SetValue("Temperature" + monthstr, "lowchilltime", Recs[month].LowWindChill.Time);
					ini.SetValue("Temperature" + monthstr, "highmintempvalue", Recs[month].HighMinTemp.Value);
					ini.SetValue("Temperature" + monthstr, "highmintemptime", Recs[month].HighMinTemp.Time);
					ini.SetValue("Temperature" + monthstr, "lowmaxtempvalue", Recs[month].LowMaxTemp.Value);
					ini.SetValue("Temperature" + monthstr, "lowmaxtemptime", Recs[month].LowMaxTemp.Time);
					ini.SetValue("Temperature" + monthstr, "highapptempvalue", Recs[month].HighApparant.Value);
					ini.SetValue("Temperature" + monthstr, "highapptemptime", Recs[month].HighApparant.Time);
					ini.SetValue("Temperature" + monthstr, "lowapptempvalue", Recs[month].LowApparant.Value);
					ini.SetValue("Temperature" + monthstr, "lowapptemptime", Recs[month].LowApparant.Time);
					ini.SetValue("Temperature" + monthstr, "highfeelslikevalue", Recs[month].HighFeelsLike.Value);
					ini.SetValue("Temperature" + monthstr, "highfeelsliketime", Recs[month].HighFeelsLike.Time);
					ini.SetValue("Temperature" + monthstr, "lowfeelslikevalue", Recs[month].LowFeelsLike.Value);
					ini.SetValue("Temperature" + monthstr, "lowfeelsliketime", Recs[month].LowFeelsLike.Time);
					ini.SetValue("Temperature" + monthstr, "highhumidexvalue", Recs[month].HighHumidex.Value);
					ini.SetValue("Temperature" + monthstr, "highhumidextime", Recs[month].HighHumidex.Time);
					ini.SetValue("Temperature" + monthstr, "highheatindexvalue", Recs[month].HighHeatIndex.Value);
					ini.SetValue("Temperature" + monthstr, "highheatindextime", Recs[month].HighHeatIndex.Time);
					ini.SetValue("Temperature" + monthstr, "highdewpointvalue", Recs[month].HighDewPoint.Value);
					ini.SetValue("Temperature" + monthstr, "highdewpointtime", Recs[month].HighDewPoint.Time);
					ini.SetValue("Temperature" + monthstr, "lowdewpointvalue", Recs[month].LowDewPoint.Value);
					ini.SetValue("Temperature" + monthstr, "lowdewpointtime", Recs[month].LowDewPoint.Time);
					ini.SetValue("Temperature" + monthstr, "hightemprangevalue", Recs[month].HighDailyRange.Value);
					ini.SetValue("Temperature" + monthstr, "hightemprangetime", Recs[month].HighDailyRange.Time);
					ini.SetValue("Temperature" + monthstr, "lowtemprangevalue", Recs[month].LowDailyRange.Value);
					ini.SetValue("Temperature" + monthstr, "lowtemprangetime", Recs[month].LowDailyRange.Time);
					ini.SetValue("Wind" + monthstr, "highwindvalue", Recs[month].HighWindAvg.Value);
					ini.SetValue("Wind" + monthstr, "highwindtime", Recs[month].HighWindAvg.Time);
					ini.SetValue("Wind" + monthstr, "highgustvalue", Recs[month].HighWindGust.Value);
					ini.SetValue("Wind" + monthstr, "highgusttime", Recs[month].HighWindGust.Time);
					ini.SetValue("Wind" + monthstr, "highdailywindrunvalue", Recs[month].HighWindRun.Value);
					ini.SetValue("Wind" + monthstr, "highdailywindruntime", Recs[month].HighWindRun.Time);
					ini.SetValue("Rain" + monthstr, "highrainratevalue", Recs[month].HighRainRate.Value);
					ini.SetValue("Rain" + monthstr, "highrainratetime", Recs[month].HighRainRate.Time);
					ini.SetValue("Rain" + monthstr, "highdailyrainvalue", Recs[month].HighDailyRain.Value);
					ini.SetValue("Rain" + monthstr, "highdailyraintime", Recs[month].HighDailyRain.Time);
					ini.SetValue("Rain" + monthstr, "highhourlyrainvalue", Recs[month].HighHourlyRain.Value);
					ini.SetValue("Rain" + monthstr, "highhourlyraintime", Recs[month].HighHourlyRain.Time);
					ini.SetValue("Rain" + monthstr, "highmonthlyrainvalue", Recs[month].HighMonthlyRain.Value);
					ini.SetValue("Rain" + monthstr, "highmonthlyraintime", Recs[month].HighMonthlyRain.Time);
					ini.SetValue("Rain" + monthstr, "longestdryperiodvalue", Recs[month].LongestDry.Value);
					ini.SetValue("Rain" + monthstr, "longestdryperiodtime", Recs[month].LongestDry.Time);
					ini.SetValue("Rain" + monthstr, "longestwetperiodvalue", Recs[month].LongestWet.Value);
					ini.SetValue("Rain" + monthstr, "longestwetperiodtime", Recs[month].LongestWet.Time);
                    ini.SetValue("Rain" + monthstr, "high24hourrainvalue", Recs[month].High24hRain.Value);
                    ini.SetValue("Rain" + monthstr, "high24hourraintime", Recs[month].High24hRain.Time);
                    ini.SetValue("Pressure" + monthstr, "highpressurevalue", Recs[month].HighPressure.Value);
					ini.SetValue("Pressure" + monthstr, "highpressuretime", Recs[month].HighPressure.Time);
					ini.SetValue("Pressure" + monthstr, "lowpressurevalue", Recs[month].LowPressure.Value);
					ini.SetValue("Pressure" + monthstr, "lowpressuretime", Recs[month].LowPressure.Time);
					ini.SetValue("Humidity" + monthstr, "highhumidityvalue", Recs[month].HighHumidity.Value);
					ini.SetValue("Humidity" + monthstr, "highhumiditytime", Recs[month].HighHumidity.Time);
					ini.SetValue("Humidity" + monthstr, "lowhumidityvalue", Recs[month].LowHumidity.Value);
					ini.SetValue("Humidity" + monthstr, "lowhumiditytime", Recs[month].LowHumidity.Time);
				}
				ini.Flush();
			}
			catch (Exception ex)
			{
				Program.LogMessage("Error writing MonthlyAlltime.ini file: " + ex.Message);
			}
		}
	}
}
