using MikeWeispfenning.BarrenLandAnalysis.Interfaces;

namespace MikeWeispfenning.BarrenLandAnalysis
{
    /// <summary>
    /// A class that represents a single square meter of land.
    /// </summary>
    public class SquareMeter : ISquareMeter
    {
        /// <summary>
        /// Returns if this square meter is still fertile.
        /// </summary>
        public bool IsFertile { get; private set; } = true;

        /// <summary>
        /// Adds salt to this entire square meter, rendering it barren.
        /// </summary>
        public void AddSalt()
        {
            IsFertile = false;
        }

        public override string ToString()
        {
            return $"{nameof(SquareMeter)}: {nameof(IsFertile)} = {IsFertile};";
        }
    }
}
