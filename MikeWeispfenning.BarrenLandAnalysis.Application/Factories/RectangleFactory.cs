using log4net;
using MikeWeispfenning.BarrenLandAnalysis.Application.Interfaces;
using System;

namespace MikeWeispfenning.BarrenLandAnalysis.Application.Factories
{
	/// <summary>
	/// A factory that creates rectangles
	/// </summary>
	public class RectangleFactory : IRectangleFactory
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(RectangleFactory));

		/// <summary>
		/// Creates a rectangle using a string of points and a point factory
		/// </summary>
		/// <param name="pointFactory">A factory that creates points</param>
		/// <param name="pointsAsString">The points of the rectangle in the form "bottomLeftX bottomLeftY topRightX topRightY"</param>
		/// <returns>A rectangle with the corners as given</returns>
		public Rectangle CreateRectangle(IPointFactory pointFactory, string pointsAsString)
		{
			_logger.Debug($"Entering {nameof(CreateRectangle)} with {nameof(pointsAsString)} = \"{pointsAsString}\"");

			if (pointFactory == null)
			{
				var exception = new ArgumentNullException(nameof(pointFactory));
				_logger.Error(exception.Message, exception);
				throw exception;
			}

			if (string.IsNullOrEmpty(pointsAsString))
			{
				var exception = new ArgumentException("The string passed in cannot be null or empty.", nameof(pointsAsString));
				_logger.Error(exception.Message, exception);
				throw exception;
			}

			var points = pointsAsString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

			if (points.Length != 4)
			{
				var exception = new ArgumentException(string.Format("The number of points passed in must be four, not {0}", points.Length), nameof(pointsAsString));
				_logger.Error(exception.Message, exception);
				throw exception;
			}

			var bottomLeft = pointFactory.CreatePoint(points[0], points[1]);
			var topRight = pointFactory.CreatePoint(points[2], points[3]);

			return new Rectangle(bottomLeft, topRight);
		}

		/// <summary>
		/// Creates a rectangle with the x and y length as given
		/// </summary>
		/// <param name="pointFactory">A factory that creates points</param>
		/// <param name="xLength">The length of the rectangle in the x direction</param>
		/// <param name="yLength">The length of the rectangle in the y direction</param>
		/// <returns>A rectangle with the size given with the bottom left corner located at (0, 0)</returns>
		public Rectangle CreateRectangle(IPointFactory pointFactory, int xLength, int yLength)
		{
			_logger.Debug($"Entering {nameof(CreateRectangle)} with {nameof(xLength)} = {xLength} and {nameof(yLength)} = {yLength}");

			if (xLength < 0)
			{
				var exception = new ArgumentOutOfRangeException(nameof(xLength), xLength, "The value of X must be greater than or equal to zero");
				_logger.Error(exception.Message, exception);
				throw exception;
			}
			if (yLength < 0)
			{
				var exception = new ArgumentOutOfRangeException(nameof(yLength), yLength, "The value of Y must be greater than or equal to zero");
				_logger.Error(exception.Message, exception);
				throw exception;
			}

			var bottomLeft = pointFactory.CreatePoint(0, 0);
			var topRight = pointFactory.CreatePoint(xLength, yLength);

			return new Rectangle(bottomLeft, topRight);
		}
	}
}
