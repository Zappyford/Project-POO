using PetitMonde.Units;
using System;
using System.Collections.Generic;
namespace PetitMonde
{
    public interface Player
    {
        /// <summary>
        /// Ends this player's turn
        /// </summary>
        void EndTurn();

        /// <summary>
        /// Nickname of the player
        /// </summary>
        string Nickname
        {
            get;
        }

        /// <summary>
        /// Starts a fight between the two units given
        /// </summary>
        /// <param name="unit1">The first unit</param>
        /// <param name="unit2">The second unit</param>
        void Fight(Unit unit1, Unit unit2);

        /// <summary>
        /// True if this player lost the game
        /// </summary>
        bool HasLost
        {
            get;
        }

        /// <summary>
        /// The current score of this player
        /// </summary>
        int Score
        {
            get;
        }

        /// <summary>
        /// List of all units of this player
        /// </summary>
        System.Collections.Generic.List<PetitMonde.Units.Unit> Units
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a list containing all the units owned by this player on the cell at the given coordinates
        /// </summary>
        /// <param name="x">X coordinate of the cell</param>
        /// <param name="y">Y coordinate of the cell</param>
        /// <returns>A list containing all the units owned by this player on the cell at the given coordinates</returns>
        List<Unit> GetUnitsOnCell(int x, int y);

        /// <summary>
        /// Select the best defensive unit on the given cell
        /// </summary>
        /// <param name="x">X coordinate of the cell</param>
        /// <param name="y">Y coordinate of the cell</param>
        /// <returns>The best defensive unit on the cell</returns>
        Unit GetBestDefensiveUnit(int x, int y);

        /// <summary>
        /// Sets the moving points of all alive units to their default
        /// </summary>
        void clearMovingPoints();
    }
}
