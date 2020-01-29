namespace MikeWeispfenning.BarrenLandAnalysis.Interfaces
{
    /// <summary>
    /// An interface that represents a single square meter of land.
    /// </summary>
    public interface ISquareMeter
    {
        /// <summary>
        /// Returns if this square meter is still fertile.
        /// </summary>
        bool IsFertile { get; }

        /// <summary>
        /// Adds salt to this entire square meter, rendering it barren (infertile).
        /// </summary>
        void AddSalt();
    }
}
