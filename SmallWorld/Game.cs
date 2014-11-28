using PetitMonde.Units;
namespace PetitMonde
{
    public interface Game
    {
        /// <summary>
        /// The second player
        /// </summary>
        PetitMonde.PlayerImpl Player2
        {
            get;
            set;
        }

        /// <summary>
        /// The first player
        /// </summary>
        PetitMonde.PlayerImpl Player1
        {
            get;
            set;
        }

        /// <summary>
        /// The map
        /// </summary>
        PetitMonde.Map.MapImpl Map
        {
            get;
            set;
        }

        /// <summary>
        /// The player that plays his turn
        /// </summary>
        PetitMonde.PlayerImpl CurrentPlayer
        {
            get;
        }

        /// <summary>
        /// The unit that is selected
        /// </summary>
        Unit SelectedUnit
        {
            get;
            set;
        }

        /// <summary>
        /// The X coordinate of the selected cell
        /// </summary>
        int XSelected
        {
            get;
            set;
        }

        /// <summary>
        /// The Y coordinate of the selected cell
        /// </summary>
        int YSelected
        {
            get;
            set;
        }

        /// <summary>
        /// The player that doesn't play his turn
        /// </summary>
        PlayerImpl OpponentPlayer
        {
            get;
        }

        /// <summary>
        /// Moves the unit on the selected cell, and start a fight if an ennemy unit is present on the targeted cell
        /// </summary>
        /// <param name="unit">The unit that tries to move on the targeted cell</param>
        /// <param name="xTargeted">The x coordinate of the targeted cell</param>
        /// <param name="yTargeted">The y coordinate of the targeted Cell</param>
        void MoveUnit(Units.Unit unit, int xTargeted, int yTargeted);

        /// <summary>
        /// Ends the current player's turn
        /// </summary>
        void EndTurn();
    }
}
