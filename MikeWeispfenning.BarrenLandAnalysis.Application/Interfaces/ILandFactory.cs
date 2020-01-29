using MikeWeispfenning.BarrenLandAnalysis.Interfaces;

namespace MikeWeispfenning.BarrenLandAnalysis.Application.Interfaces
{
	/// <summary>
	/// A factory that creates land
	/// </summary>
	public interface ILandFactory
	{
		/// <summary>
		/// Creates a Land object using the rectangle provided to define the outside of the land
		/// </summary>
		/// <param name="landDefinition">The rectangle that defines the outside of the land</param>
		/// <returns>Returns a land object</returns>
		ILand CreateLand(Rectangle landDefinition);
	}
}
