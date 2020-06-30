using log4net;
using MikeWeispfenning.BarrenLandAnalysis.Application.Factories;
using System;
using System.Linq;

namespace MikeWeispfenning.BarrenLandAnalysis.Application
{
	public class Program
	{
		private const int COLUMNS_OF_LAND = 400;
		private const int ROWS_OF_LAND = 600;
		private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));

		public static void Main(string[] args)
		{
			_logger.Debug($"Entering {nameof(Main)} with args = {{ {string.Join(", ", args.Select((arg, index) => $"[{index}] = {arg}"))} }}");

			try
			{
				var fertileLandAsOrderedString = GetFertileLandsAsOrderedString(args);

				// Satisfy requirements
				Console.WriteLine(fertileLandAsOrderedString);
			}
			catch (Exception exception)
			{
				_logger.Error(exception.Message, exception);
				Console.WriteLine(string.Format("There was a problem running the application as desired: {0}", exception.Message));
			}

			Console.WriteLine("Press any key to continue");
			Console.ReadKey();

			_logger.Debug($"Exiting {nameof(Main)}");
		}

		/// <summary>
		/// Gets the fertile plots of land in ascending order as a single string
		/// </summary>
		/// <param name="plotsToSaltAsStrings">The plots to salt as a collection of strings, with each string representing an plot to salt</param>
		/// <returns>A single string containing the fertile plots, separated by a space, in ascending order</returns>
		public static string GetFertileLandsAsOrderedString(string[] plotsToSaltAsStrings)
		{
			_logger.Debug($"Entering {nameof(GetFertileLandsAsOrderedString)}");

			var pointFactory = new PointFactory();
			var rectangleFactory = new RectangleFactory();
			var landFactory = new LandFactory();

			var landDefinition = rectangleFactory.CreateRectangle(pointFactory, COLUMNS_OF_LAND, ROWS_OF_LAND);
			var land = landFactory.CreateLand(landDefinition);

			// Salt the land
			var plotsToSalt = plotsToSaltAsStrings.Select(plotToSaltAsString => rectangleFactory.CreateRectangle(pointFactory, plotToSaltAsString));
			foreach (var plotToSalt in plotsToSalt)
			{
				land.AddSalt(plotToSalt);
			}

			// This line satisfies the output requirements
			string fertileLandAsOrderedString = string.Join(" ", land.FertilePlotsInSquareMeters.OrderBy(plot => plot));

			_logger.Debug($"Exiting {nameof(GetFertileLandsAsOrderedString)} with a return value of \"{fertileLandAsOrderedString}\"");
			return fertileLandAsOrderedString;
		}
	}
}
