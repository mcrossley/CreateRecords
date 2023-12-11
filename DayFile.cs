using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CreateRecords
{


	class DayFile
	{
		public List<Dayfilerec> DayfileRecs = new List<Dayfilerec>();


		private string dayFileName = "data" + Path.DirectorySeparatorChar + "dayfile.txt";

		public DayFile()
		{
			// read in the existing day file

			if (File.Exists(dayFileName + ".sav"))
			{
				Console.WriteLine("The dayfile.txt backup file dayfile.txt.sav already exists, aborting to prevent overwriting the original data.");
				Console.WriteLine("Press any key to exit");
				Console.ReadKey(true);
				Console.WriteLine("Exiting...");
				Environment.Exit(1);
			}

			LoadDayFile();
		}


		public void LoadDayFile()
		{
			int addedEntries = 0;

			Program.LogMessage($"LoadDayFile: Attempting to load the day file");
			if (File.Exists(dayFileName))
			{
				int linenum = 0;
				int errorCount = 0;

				// Clear the existing list
				DayfileRecs.Clear();

				try
				{
					using (var sr = new StreamReader(dayFileName))
					{
						do
						{
							try
							{
								// process each record in the file

								linenum++;
								string Line = sr.ReadLine();
								DayfileRecs.Add(ParseDayFileRec(Line));

								addedEntries++;
							}
							catch (Exception e)
							{
								Program.LogMessage($"LoadDayFile: Error at line {linenum} of {dayFileName} : {e.Message}");
								Program.LogMessage("Please edit the file to correct the error");
								errorCount++;
								if (errorCount >= 20)
								{
									Program.LogMessage($"LoadDayFile: Too many errors reading {dayFileName} - aborting load of daily data");
								}
							}
						} while (!(sr.EndOfStream || errorCount >= 20));
					}
				}
				catch (Exception e)
				{
					Program.LogMessage($"LoadDayFile: Error at line {linenum} of {dayFileName} : {e.Message}");
					Program.LogMessage("Please edit the file to correct the error");
				}
				Program.LogMessage($"LoadDayFile: Loaded {addedEntries} entries to the daily data list");
			}
			else
			{
				Program.LogMessage("LoadDayFile: No Dayfile found - No entries added to recent daily data list");
				// add a rcord for yesterday, just so we have something to process,
				// if it is left at default we will not write it out
				var newRec = new Dayfilerec();
				newRec.Date = DateTime.Today.AddDays(-1);
				DayfileRecs.Add(newRec);
			}
		}

		private Dayfilerec ParseDayFileRec(string data)
		{
			var st = new List<string>(Regex.Split(data, CultureInfo.CurrentCulture.TextInfo.ListSeparator));
			double varDbl;
			int varInt;
			int idx = 0;

			var rec = new Dayfilerec();
			try
			{
				rec.Date = DdmmyyStrToDate(st[idx++]);
				rec.HighGust = Convert.ToDouble(st[idx++]);
				rec.HighGustBearing = Convert.ToInt32(st[idx++]);
				rec.HighGustTime = GetDateTime(rec.Date, st[idx++]);
				rec.LowTemp = Convert.ToDouble(st[idx++]);
				rec.LowTempTime = GetDateTime(rec.Date, st[idx++]);
				rec.HighTemp = Convert.ToDouble(st[idx++]);
				rec.HighTempTime = GetDateTime(rec.Date, st[idx++]);
				rec.LowPress = Convert.ToDouble(st[idx++]);
				rec.LowPressTime = GetDateTime(rec.Date, st[idx++]);
				rec.HighPress = Convert.ToDouble(st[idx++]);
				rec.HighPressTime = GetDateTime(rec.Date, st[idx++]);
				rec.HighRainRate = Convert.ToDouble(st[idx++]);
				rec.HighRainRateTime = GetDateTime(rec.Date, st[idx++]);
				rec.TotalRain = Convert.ToDouble(st[idx++]);
				rec.AvgTemp = Convert.ToDouble(st[idx++]);

				if (st.Count > idx++ && double.TryParse(st[16], out varDbl))
					rec.WindRun = varDbl;

				if (st.Count > idx++ && double.TryParse(st[17], out varDbl))
					rec.HighAvgWind = varDbl;

				if (st.Count > idx++ && st[18].Length == 5)
					rec.HighAvgWindTime = GetDateTime(rec.Date, st[18]);

				if (st.Count > idx++ && int.TryParse(st[19], out varInt))
					rec.LowHumidity = varInt;

				if (st.Count > idx++ && st[20].Length == 5)
					rec.LowHumidityTime = GetDateTime(rec.Date, st[20]);

				if (st.Count > idx++ && int.TryParse(st[21], out varInt))
					rec.HighHumidity = varInt;

				if (st.Count > idx++ && st[22].Length == 5)
					rec.HighHumidityTime = GetDateTime(rec.Date, st[22]);

				if (st.Count > idx++ && double.TryParse(st[23], out varDbl))
					rec.ET = varDbl;

				if (st.Count > idx++ && double.TryParse(st[24], out varDbl))
					rec.SunShineHours = varDbl;

				if (st.Count > idx++ && double.TryParse(st[25], out varDbl))
					rec.HighHeatIndex = varDbl;

				if (st.Count > idx++ && st[26].Length == 5)
					rec.HighHeatIndexTime = GetDateTime(rec.Date, st[26]);

				if (st.Count > idx++ && double.TryParse(st[27], out varDbl))
					rec.HighAppTemp = varDbl;

				if (st.Count > idx++ && st[28].Length == 5)
					rec.HighAppTempTime = GetDateTime(rec.Date, st[28]);

				if (st.Count > idx++ && double.TryParse(st[29], out varDbl))
					rec.LowAppTemp = varDbl;

				if (st.Count > idx++ && st[30].Length == 5)
					rec.LowAppTempTime = GetDateTime(rec.Date, st[30]);

				if (st.Count > idx++ && double.TryParse(st[31], out varDbl))
					rec.HighHourlyRain = varDbl;

				if (st.Count > idx++ && st[32].Length == 5)
					rec.HighHourlyRainTime = GetDateTime(rec.Date, st[32]);

				if (st.Count > idx++ && double.TryParse(st[33], out varDbl))
					rec.LowWindChill = varDbl;

				if (st.Count > idx++ && st[34].Length == 5)
					rec.LowWindChillTime = GetDateTime(rec.Date, st[34]);

				if (st.Count > idx++ && double.TryParse(st[35], out varDbl))
					rec.HighDewPoint = varDbl;

				if (st.Count > idx++ && st[36].Length == 5)
					rec.HighDewPointTime = GetDateTime(rec.Date, st[36]);

				if (st.Count > idx++ && double.TryParse(st[37], out varDbl))
					rec.LowDewPoint = varDbl;

				if (st.Count > idx++ && st[38].Length == 5)
					rec.LowDewPointTime = GetDateTime(rec.Date, st[38]);

				if (st.Count > idx++ && int.TryParse(st[39], out varInt))
					rec.DominantWindBearing = varInt;

				if (st.Count > idx++ && double.TryParse(st[40], out varDbl))
					rec.HeatingDegreeDays = varDbl;

				if (st.Count > idx++ && double.TryParse(st[41], out varDbl))
					rec.CoolingDegreeDays = varDbl;

				if (st.Count > idx++ && int.TryParse(st[42], out varInt))
					rec.HighSolar = varInt;

				if (st.Count > idx++ && st[43].Length == 5)
					rec.HighSolarTime = GetDateTime(rec.Date, st[43]);

				if (st.Count > idx++ && double.TryParse(st[44], out varDbl))
					rec.HighUv = varDbl;

				if (st.Count > idx++ && st[45].Length == 5)
					rec.HighUvTime = GetDateTime(rec.Date, st[45]);

				if (st.Count > idx++ && double.TryParse(st[46], out varDbl))
					rec.HighFeelsLike = varDbl;

				if (st.Count > idx++ && st[47].Length == 5)
					rec.HighFeelsLikeTime = GetDateTime(rec.Date, st[47]);

				if (st.Count > idx++ && double.TryParse(st[48], out varDbl))
					rec.LowFeelsLike = varDbl;

				if (st.Count > idx++ && st[49].Length == 5)
					rec.LowFeelsLikeTime = GetDateTime(rec.Date, st[49]);

				if (st.Count > idx++ && double.TryParse(st[50], out varDbl))
					rec.HighHumidex = varDbl;

				if (st.Count > idx++ && st[51].Length == 5)
					rec.HighHumidexTime = GetDateTime(rec.Date, st[51]);

				if (st.Count > idx++ && double.TryParse(st[53], out varDbl))
					rec.HighRain24h = varDbl;

				if (st.Count > idx++ && st[54].Length == 5)
					rec.HighRain24hTime = GetDateTime(rec.Date, st[54]);

			}
			catch (Exception ex)
			{
				Program.LogMessage($"ParseDayFileRec: Error at record {idx} - {ex.Message}");
				var e = new Exception($"Error at record {idx} = \"{st[idx - 1]}\" - {ex.Message}");
				throw e;
			}
			return rec;
		}

		private DateTime DdmmyyStrToDate(string d)
		{
			// Converts a date string in UK order to a DateTime
			// Horrible hack, but we have localised separators, but UK sequence, so localised parsing may fail
			string[] date = d.Split(new string[] { CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator }, StringSplitOptions.None);

			int D = Convert.ToInt32(date[0]);
			int M = Convert.ToInt32(date[1]);
			int Y = Convert.ToInt32(date[2]);
			if (Y > 70)
			{
				Y += 1900;
			}
			else
			{
				Y += 2000;
			}

			return new DateTime(Y, M, D);
		}

		public DateTime DdmmyyhhmmStrToDate(string d, string t)
		{
			// Converts a date string in UK order to a DateTime
			// Horrible hack, but we have localised separators, but UK sequence, so localised parsing may fail
			string[] date = d.Split(new string[] { CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator }, StringSplitOptions.None);
			string[] time = t.Split(new string[] { CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator }, StringSplitOptions.None);

			int D = Convert.ToInt32(date[0]);
			int M = Convert.ToInt32(date[1]);
			int Y = Convert.ToInt32(date[2]);

			// Double check - just in case we get a four digit year!
			if (Y < 1900)
			{
				Y += Y > 70 ? 1900 : 2000;
			}
			int h = Convert.ToInt32(time[0]);
			int m = Convert.ToInt32(time[1]);

			return new DateTime(Y, M, D, h, m, 0);
		}

		private static DateTime GetDateTime(DateTime date, string time)
		{
			var tim = time.Split(CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator.ToCharArray()[0]);
			return new DateTime(date.Year, date.Month, date.Day, int.Parse(tim[0]), int.Parse(tim[1]), 0);
		}

	}

	public class Dayfilerec
	{
		public DateTime Date;
		public double HighGust;
		public int HighGustBearing;
		public DateTime HighGustTime;
		public double LowTemp;
		public DateTime LowTempTime;
		public double HighTemp;
		public DateTime HighTempTime;
		public double LowPress;
		public DateTime LowPressTime;
		public double HighPress;
		public DateTime HighPressTime;
		public double HighRainRate;
		public DateTime HighRainRateTime;
		public double TotalRain;
		public double AvgTemp;
		public double WindRun;
		public double HighAvgWind;
		public DateTime HighAvgWindTime;
		public int LowHumidity;
		public DateTime LowHumidityTime;
		public int HighHumidity;
		public DateTime HighHumidityTime;
		public double ET;
		public double SunShineHours;
		public double HighHeatIndex;
		public DateTime HighHeatIndexTime;
		public double HighAppTemp;
		public DateTime HighAppTempTime;
		public double LowAppTemp;
		public DateTime LowAppTempTime;
		public double HighHourlyRain;
		public DateTime HighHourlyRainTime;
		public double LowWindChill;
		public DateTime LowWindChillTime;
		public double HighDewPoint;
		public DateTime HighDewPointTime;
		public double LowDewPoint;
		public DateTime LowDewPointTime;
		public int DominantWindBearing;
		public double HeatingDegreeDays;
		public double CoolingDegreeDays;
		public int HighSolar;
		public DateTime HighSolarTime;
		public double HighUv;
		public DateTime HighUvTime;
		public double HighFeelsLike;
		public DateTime HighFeelsLikeTime;
		public double LowFeelsLike;
		public DateTime LowFeelsLikeTime;
		public double HighHumidex;
		public DateTime HighHumidexTime;
		public double HighRain24h;
		public DateTime HighRain24hTime;

        public Dayfilerec()
		{
			HighGust = -9999;
			HighGustBearing = 0;
			LowTemp = 9999;
			HighTemp = -9999;
			LowPress = 9999;
			HighPress = -9999;
			HighRainRate = -9999;
			TotalRain = -9999;
			AvgTemp = -9999;
			WindRun = -9999;
			HighAvgWind = -9999;
			LowHumidity = 9999;
			HighHumidity = -9999;
			ET = -9999;
			SunShineHours = -9999;
			HighHeatIndex = -9999;
			HighAppTemp = -9999;
			LowAppTemp = 9999;
			HighHourlyRain = -9999;
			LowWindChill = 9999;
			HighDewPoint = -9999;
			LowDewPoint = 9999;
			DominantWindBearing = 9999;
			HeatingDegreeDays = -9999;
			CoolingDegreeDays = -9999;
			HighSolar = -9999;
			HighUv = -9999;
			HighFeelsLike = -9999;
			LowFeelsLike = 9999;
			HighHumidex = -9999;
			HighRain24h = -9999;
		}

		public bool HasMissingData()
		{
			if (HighHumidex == -9999 || LowFeelsLike == 9999 || HighFeelsLike == -9999 || CoolingDegreeDays == -9999 || HeatingDegreeDays == -9999 ||
				DominantWindBearing == 9999 || LowDewPoint == 9999 || HighDewPoint == -9999 || LowWindChill == 9999 || HighHourlyRain == -9999 ||
				LowAppTemp == 9999 || HighAppTemp == -9999 || HighHeatIndex == -9999 || HighHumidity == -9999 || LowHumidity == 9999 ||
				HighAvgWind == -9999 || AvgTemp == -9999 || HighRainRate == -9999 || LowPress == 9999 || HighPress == -9999 ||
				HighTemp == -9999 || LowTemp == 9999 || HighGust == -9999 || HighRain24h == -9999
			)
			{
				return true;
			}

			return false;
		}
	}
}
