namespace MikeWeispfenning.BarrenLandAnalysis.Application.Interfaces
{
	/// <summary>
	/// A factory that creates rectangles
	/// </summary>
	public interface IRectangleFactory
	{
		/// <summary>
		/// Creates a rectangle using a string of points and a point factory
		/// </summary>
		/// <param name="pointFactory">A factory that creates points</param>
		/// <param name="pointsAsString">The points of the rectangle in the form "bottomLeftX bottomLeftY topRightX topRightY"</param>
		/// <returns>A rectangle with the corners as given</returns>
		Rectangle CreateRectangle(IPointFactory pointFactory, string pointsAsString);

		/// <summary>
		/// Creates a rectangle with the x and y length as given
		/// </summary>
		/// <param name="pointFactory">A factory that creates points</param>
		/// <param name="xLength">The length of the rectangle in the x direction</param>
		/// <param name="yLength">The length of the rectangle in the y direction</param>
		/// <returns>A rectangle with the size given with the bottom left corner located at (0, 0)</returns>
		Rectangle CreateRectangle(IPointFactory pointFactory, int xLength, int yLength);
	}
}
