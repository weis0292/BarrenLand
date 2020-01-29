using log4net;
using System;

namespace MikeWeispfenning.BarrenLandAnalysis
{
	/// <summary>
	/// A structure representing a rectangle
	/// </summary>
	public struct Rectangle
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(Rectangle));

		/// <summary>
		/// Gets the location of the bottom left corner of the rectangle
		/// </summary>
		public Point BottomLeft { get; }

		/// <summary>
		/// Gets the location of the top right corner of the rectangle
		/// </summary>
		public Point TopRight { get; }

		/// <summary>
		/// Gets the location of the bottom right corner of the rectangle
		/// </summary>
		public Point BottomRight { get; }

		/// <summary>
		/// Gets the location of the top left corner of the rectangle
		/// </summary>
		public Point TopLeft { get; }

		/// <summary>
		/// Gets the length of the X side of the rectangle
		/// </summary>
		public int XLength { get { return TopRight.X - BottomLeft.X; } }

		/// <summary>
		/// Gets the length of the Y side of the rectangle
		/// </summary>
		public int YLength { get { return TopRight.Y - BottomLeft.Y; } }

		/// <summary>
		/// Creates a new rectangle with opposite corners as given
		/// </summary>
		/// <param name="bottomLeft">The desired bottom left corner of the rectangle</param>
		/// <param name="topRight">The desired top right corner of the rectangle</param>
		public Rectangle(Point bottomLeft, Point topRight)
		{
			_logger.Debug($"Entering ctor with {nameof(bottomLeft)} = {bottomLeft} and {nameof(topRight)} = {topRight}");

			if (bottomLeft.X < 0)
			{
				var exception = new ArgumentOutOfRangeException(string.Format("{0}.{1}", nameof(bottomLeft), nameof(bottomLeft.X)), bottomLeft.X, "The bottom left point of the rectangle must have a positive X value.");
				_logger.Error(exception.Message, exception);
				throw new ArgumentOutOfRangeException(string.Format("{0}.{1}", nameof(bottomLeft), nameof(bottomLeft.X)), bottomLeft.X, "The bottom left point of the rectangle must have a positive X value.");
			}
			if (bottomLeft.Y < 0)
			{
				var exception = new ArgumentOutOfRangeException(string.Format("{0}.{1}", nameof(bottomLeft), nameof(bottomLeft.Y)), bottomLeft.Y, "The bottom left point of the rectangle must have a positive Y value.");
				_logger.Error(exception.Message, exception);
				throw exception;
			}
			if (topRight.X < bottomLeft.X)
			{
				var exception = new ArgumentOutOfRangeException(string.Format("{0}.{1}", nameof(topRight), nameof(topRight.X)), topRight.X, "The top right point must have an X value greater than the bottom left point.");
				_logger.Error(exception.Message, exception);
				throw exception;
			}
			if (topRight.Y < bottomLeft.Y)
			{
				var exception = new ArgumentOutOfRangeException(string.Format("{0}.{1}", nameof(topRight), nameof(topRight.Y)), topRight.Y, "The top right point must have a Y value greater than the bottom left point.");
				_logger.Error(exception.Message, exception);
				throw exception;
			}

			BottomLeft = bottomLeft;
			TopRight = topRight;
			BottomRight = new Point(TopRight.X, BottomLeft.Y);
			TopLeft = new Point(BottomLeft.X, TopRight.Y);
		}

		public override string ToString()
		{
			return $"{nameof(Rectangle)}: {nameof(BottomLeft)} = {BottomLeft}; {nameof(BottomRight)} = {BottomRight}; {nameof(TopLeft)} = {TopLeft}; {nameof(TopRight)} = {TopRight};";
		}
	}
}
