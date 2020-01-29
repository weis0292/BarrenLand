using System.Collections.Generic;

namespace MikeWeispfenning.BarrenLandAnalysis.Interfaces
{
    /// <summary>
    /// A contract that provides a way to represent land.
    /// </summary>
    public interface ILand
    {
        /// <summary>
        /// Gets the number of one meter columns of land contained in this land.
        /// </summary>
        int ColumnsOfLand { get; }
        /// <summary>
        /// Gets the number of one meter rows of land contained in this land.
        /// </summary>
        int RowsOfLand { get; }
        /// <summary>
        /// A list of fertile plots in square meters.
        /// </summary>
        IEnumerable<int> FertilePlotsInSquareMeters { get; }

        /// <summary>
        /// Adds salt to the rectangle of land as defined by the plotToSalt, thereby rendering it barren.
        /// </summary>
        /// <param name="plotToSalt">The plot of land to salt within the land area.</param>
        void AddSalt(Rectangle plotToSalt);
    }
}
