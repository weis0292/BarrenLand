namespace MikeWeispfenning.BarrenLandAnalysis.Application.Interfaces
{
	/// <summary>
	/// A factory that creates points
	/// </summary>
	public interface IPointFactory
	{
		/// <summary>
		/// Creates a points from strings representing integers
		/// </summary>
		/// <param name="xAsString">The X value represented as a string</param>
		/// <param name="yAsString">The Y value represented as a string</param>
		/// <returns>Returns a new Point with the X and Y values passed in</returns>
		Point CreatePoint(string xAsString, string yAsString);

		/// <summary>
		/// Creates a points from integers
		/// </summary>
		/// <param name="x">The X value</param>
		/// <param name="y">The Y value</param>
		/// <returns>Returns a new Point with the X and Y values passed in</returns>
		Point CreatePoint(int x, int y);
	}
}
