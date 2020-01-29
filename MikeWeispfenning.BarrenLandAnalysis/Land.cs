using log4net;
using MikeWeispfenning.BarrenLandAnalysis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MikeWeispfenning.BarrenLandAnalysis
{
	/// <summary>
	/// A class that repersents a plot of land, and the fertile sub plots contained within.
	/// </summary>
	public class Land : ILand
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(Land));
		private readonly ISquareMeter[,] _squareMeters;
		private bool _isFertilePlotsCalculationCurrent;
		private IEnumerable<int> _fertilePlotsInSquareMeters;

		/// <summary>
		/// Gets the number of one meter columns of land contained in this land.
		/// </summary>
		public int ColumnsOfLand { get { return _squareMeters.GetLength(0); } }

		/// <summary>
		/// Gets the number of one meter rows of land contained in this land.
		/// </summary>
		public int RowsOfLand { get { return _squareMeters.GetLength(1); } }

		/// <summary>
		/// A list of fertile plots in square meters.
		/// </summary>
		public IEnumerable<int> FertilePlotsInSquareMeters
		{
			get
			{
				if (!_isFertilePlotsCalculationCurrent)
				{
					CalculateFertileLand();
				}
				return _fertilePlotsInSquareMeters;
			}
			private set { _fertilePlotsInSquareMeters = value; }
		}

		/// <summary>
		/// Creates a new Land object to which you can add salt and get the size of plots that are fertile.
		/// </summary>
		/// <param name="squareMeters">The square meters the land contains.</param>
		public Land(ISquareMeter[,] squareMeters)
		{
			_logger.Debug($"Entering ctor with {nameof(squareMeters)}.X = {squareMeters.GetLength(0)} and {nameof(squareMeters)}.Y = {squareMeters.GetLength(1)}");
			_squareMeters = squareMeters;
		}

		/// <summary>
		/// Adds salt to the rectangle of land as defined by the plotToSalt, thereby rendering it barren.
		/// </summary>
		/// <param name="plotToSalt">The plot of land to salt within the land area.</param>
		public void AddSalt(Rectangle plotToSalt)
		{
			_logger.Debug($"Entering {nameof(AddSalt)} with {nameof(plotToSalt)} = {plotToSalt}");

			if (plotToSalt.BottomLeft.X < 0 || plotToSalt.TopRight.X > _squareMeters.GetLength(0))
			{
				var exception = new ArgumentOutOfRangeException(nameof(plotToSalt), "The X value provide is outside the bounds of the land.  This is not our land to salt.");
				_logger.Error(exception.Message, exception);
				throw exception;
			}
			if (plotToSalt.BottomLeft.Y < 0 || plotToSalt.TopRight.Y > _squareMeters.GetLength(1))
			{
				var exception = new ArgumentOutOfRangeException(nameof(plotToSalt), "The Y value provide is outside the bounds of the land.  This is not our land to salt.");
				_logger.Error(exception.Message, exception);
				throw exception;
			}

			for (int y = plotToSalt.BottomLeft.Y; y <= plotToSalt.TopRight.Y; y++)
			{
				for (int x = plotToSalt.BottomLeft.X; x <= plotToSalt.TopRight.X; x++)
				{
					if (_squareMeters[x, y].IsFertile)
					{
						_squareMeters[x, y].AddSalt();
						_isFertilePlotsCalculationCurrent = false;
					}
				}
			}
		}

		/// <summary>
		/// Calculates the total fertile land and updates the fertile land collection
		/// </summary>
		private void CalculateFertileLand()
		{
			_logger.Debug($"Entering {nameof(CalculateFertileLand)}");

			var subplotToPlotMap = new Dictionary<int, int>();
			var fertileLandSubPlotMap = new int[_squareMeters.GetLength(0), _squareMeters.GetLength(1)];

			for (int y = 0; y < _squareMeters.GetLength(1); y++)
			{
				for (int x = 0; x < _squareMeters.GetLength(0); x++)
				{
					// This square meter isn't fetile...nothing to do here.
					if (!_squareMeters[x, y].IsFertile)
					{
						continue;
					}

					// Let's assign a plot number to the square meter.  We'll use the plot to left
					// if it is available, or the plot below it otherwise.  If neither of those exist nor
					// are a fertile plot, we'll create a new fertile plot, and assign our square meter to it.
					if (x > 0 && _squareMeters[x - 1, y].IsFertile)
					{
						fertileLandSubPlotMap[x, y] = fertileLandSubPlotMap[x - 1, y];

						// If the left and bottom square meters are parts of different fertile plots, two
						// fertile plots have come together.  We need to combine them into a single fertile plot.
						if ((x > 0) && (y > 0) && _squareMeters[x, y - 1].IsFertile && (fertileLandSubPlotMap[x, y] != fertileLandSubPlotMap[x, y - 1]))
						{
							int plotToChange = fertileLandSubPlotMap[x, y - 1];
							for (int index = 0; index < subplotToPlotMap.Count; index++)
							{
								if (subplotToPlotMap[index] == plotToChange)
								{
									subplotToPlotMap[index] = fertileLandSubPlotMap[x, y];
								}
							}
						}
					}
					else if (y > 0 && _squareMeters[x, y - 1].IsFertile)
					{
						fertileLandSubPlotMap[x, y] = fertileLandSubPlotMap[x, y - 1];
					}
					else
					{
						fertileLandSubPlotMap[x, y] = subplotToPlotMap.Count;
						subplotToPlotMap.Add(fertileLandSubPlotMap[x, y], fertileLandSubPlotMap[x, y]);
					}
				}
			}

			FertilePlotsInSquareMeters = CalculateFertilePlotsFromSubPlotsInSquareMeters(fertileLandSubPlotMap, subplotToPlotMap);
			_isFertilePlotsCalculationCurrent = true;
		}

		/// <summary>
		/// Calculates the number of square meters in each fertile plot using
		/// the fertile land subplot map and the subplot to plot map.
		/// </summary>
		/// <param name="fertileLandSubPlotMap">The subplots of fertile land</param>
		/// <param name="subplotToPlotMap">The map of subplots to main plots with the key being the subplot, and the value being the main plot</param>
		/// <returns>Returns a list of the square meters in each fertile plot</returns>
		private IEnumerable<int> CalculateFertilePlotsFromSubPlotsInSquareMeters(int[,] fertileLandSubPlotMap, IDictionary<int, int> subplotToPlotMap)
		{
			_logger.Debug($"Entering {nameof(CalculateFertilePlotsFromSubPlotsInSquareMeters)}");

			IDictionary<int, int> fertilePlots = new Dictionary<int, int>();
			for (int y = 0; y < _squareMeters.GetLength(1); y++)
			{
				for (int x = 0; x < _squareMeters.GetLength(0); x++)
				{
					if (!_squareMeters[x, y].IsFertile)
					{
						continue;
					}

					// Use our sub-plot to plot map to add up the size of each fertile plot
					int plotNumber = subplotToPlotMap[fertileLandSubPlotMap[x, y]];
					if (!fertilePlots.ContainsKey(plotNumber))
					{
						fertilePlots.Add(plotNumber, 0);
					}
					fertilePlots[plotNumber]++;
				}
			}

			return fertilePlots.Select(kvp => kvp.Value);
		}
	}
}
