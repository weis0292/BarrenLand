using log4net;

namespace MikeWeispfenning.BarrenLandAnalysis
{
    /// <summary>
    /// A structure representing a point in space defined by integers
    /// </summary>
    public struct Point
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Point));

        /// <summary>
        /// The X value of the point
        /// </summary>
        public int X { get; }

        /// <summary>
        /// The Y value of the point
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Creates a new point with the X and Y values given
        /// </summary>
        /// <param name="x">The desired X value of the point</param>
        /// <param name="y">The desired Y value of the point</param>
        public Point(int x, int y)
        {
            _logger.Debug($"Entering ctor with {nameof(x)} = {x} and {nameof(Y)} = {y}");
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(Point)}: {{ {X}, {Y} }}";
        }
    }
}
