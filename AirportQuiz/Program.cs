using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportQuiz
{
	public class Program
	{
		
		static Random randomNumber = new Random();

		public void Main(string[] args)
		{
			int totalNumberOfFlights = CalculateMonthlyFlights(DateTime.Now.Month, 25, 0.4, 0.6);
			Console.WriteLine($"Ay sonunda tahmini uçuş sayısı: {totalNumberOfFlights}");
			Console.ReadKey();
		}

		public int CalculateFlightsBadWeather(int dailyOperations, double badWeatherLandings, double badWeatherTakeoffs)
		{
			int landings = (int)(dailyOperations * (1 - badWeatherLandings));
			int takeoffs = (int)(dailyOperations * (1 - badWeatherTakeoffs));
			return landings + takeoffs;
		}

		public int CalculateFlightsGoodWeather(int dailyOperations)
		{
			return dailyOperations * 2;
		}
		public int CalculateMonthlyFlights(int month, int dailyOperations, double badWeatherLandings, double badWeatherTakeoffs)
		{
			int totalNumberOfFlights = 0;
			int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);

			for (int i = 1; i <= daysInMonth; i++)
			{
				DateTime date = new DateTime(DateTime.Now.Year, month, i);
				int numberOfFlights = randomNumber.Next(25, 30);
				int weatherNumber = randomNumber.Next(0, 2);

				if (weatherNumber == 1)
				{
					Console.WriteLine($"{date:dd/MM/yyyy} tarihinde toplam {CalculateFlightsGoodWeather(numberOfFlights)} uçuş gerçekleştirildi.");
					totalNumberOfFlights += numberOfFlights;
				}
				else
				{
					Console.WriteLine($"{date:dd/MM/yyyy} tarihinde kötü hava koşulları nedeniyle toplam {CalculateFlightsBadWeather(numberOfFlights, badWeatherLandings, badWeatherTakeoffs)} uçuş gerçekleştirildi.");
					totalNumberOfFlights += numberOfFlights;
				}
			}

			return totalNumberOfFlights;
		}
		

	}
}
