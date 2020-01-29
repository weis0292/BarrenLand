using log4net;
using MikeWeispfenning.BarrenLandAnalysis.Application.Interfaces;
using System;

namespace MikeWeispfenning.BarrenLandAnalysis.Application.Factories
{
	/// <summary>
	/// A factory that creates points
	/// </summary>
	public class PointFactory : IPointFactory
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(PointFactory));

		/// <summary>
		/// Creates a points from strings representing integers
		/// </summary>
		/// <param name="xAsString">The X value represented as a string</param>
		/// <param name="yAsString">The Y value represented as a string</param>
		/// <returns>Returns a new Point with the X and Y values passed in</returns>
		public Point CreatePoint(string xAsString, string yAsString)
		{
			_logger.Debug($"Entering {nameof(CreatePoint)} with {nameof(xAsString)} = {xAsString} and {nameof(yAsString)} = {yAsString}");

			if (!int.TryParse(xAsString, out var x))
			{
				var exception = new ArgumentException(string.Format("Cannot convert {0} to an integer.", xAsString), nameof(xAsString));
				_logger.Error(exception.Message, exception);
				throw exception;
			}
			if (!int.TryParse(yAsString, out var y))
			{
				var exception = new ArgumentException(string.Format("Cannot convert {0} to an integer.", yAsString), nameof(yAsString));
				_logger.Error(exception.Message, exception);
				throw exception;
			}

			return new Point(x, y);
		}

		/// <summary>
		/// Creates a points from integers
		/// </summary>
		/// <param name="x">The X value</param>
		/// <param name="y">The Y value</param>
		/// <returns>Returns a new Point with the X and Y values passed in</returns>
		public Point CreatePoint(int x, int y)
		{
			_logger.Debug($"Entering {nameof(CreatePoint)} with {nameof(x)} = {x} and {nameof(y)} = {y}");
			return new Point(x, y);
		}
	}
}
