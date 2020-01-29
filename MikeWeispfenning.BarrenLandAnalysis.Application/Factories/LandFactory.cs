using log4net;
using MikeWeispfenning.BarrenLandAnalysis.Application.Interfaces;
using MikeWeispfenning.BarrenLandAnalysis.Interfaces;

namespace MikeWeispfenning.BarrenLandAnalysis.Application.Factories
{
    /// <summary>
    /// A factory that creates land
    /// </summary>
    public class LandFactory : ILandFactory
    {
		private static readonly ILog _logger = LogManager.GetLogger(typeof(LandFactory));

		/// <summary>
		/// Creates a Land object using the rectangle provided to define the outside of the land
		/// </summary>
		/// <param name="landDefinition">The rectangle that defines the outside of the land</param>
		/// <returns>Returns a land object</returns>
		public ILand CreateLand(Rectangle landDefinition)
        {
			_logger.Debug($"Entering {nameof(CreateLand)} with {nameof(landDefinition)} = {landDefinition}");

			// Create the square meters to be used in the land.
			var columnsOfLand = landDefinition.XLength;
            var rowsOfLand = landDefinition.YLength;

            ISquareMeter[,] squareMeters = new ISquareMeter[columnsOfLand, rowsOfLand];
            for (int y = 0; y < squareMeters.GetLength(1); y++)
            {
                for (int x = 0; x < squareMeters.GetLength(0); x++)
                {
                    squareMeters[x, y] = new SquareMeter();
                }
            }

			return new Land(squareMeters);
		}
    }
}
