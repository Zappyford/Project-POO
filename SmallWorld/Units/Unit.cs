using System;
using System.ComponentModel;
namespace PetitMonde.Units
{
    public interface Unit : INotifyPropertyChanged
    {
        /// <summary>
        /// Current Attack of this unit
        /// </summary>
        int Attack
        {
            get;
            set;
        }

        /// <summary>
        /// Current defense of this unit
        /// </summary>
        int Defense
        {
            get;
            set;
        }

        /// <summary>
        /// Current health of this unit
        /// </summary>
        int Health
        {
            get;
            set;
        }

        /// <summary>
        /// X coordinate of the current location of this unit
        /// </summary>
        int X
        {
            get;
        }

        /// <summary>
        /// Y coordinate of the current location of this unit
        /// </summary>
        int Y
        {
            get;
        }

        /// <summary>
        /// Current moving points of this unit
        /// </summary>
        float MovingPoints
        {
            get;
            set;
        }

        
        /// <summary>
        /// Faction of this unit
        /// </summary>
        Faction Faction
        {
            get;
            set;
        }

        /// <summary>
        /// True if the unit is dead, false otherwise
        /// </summary>
        Boolean IsDead
        {
            get;
        }

        /// <summary>
        /// Gets the bonus points for this unit
        /// </summary>
        int BonusPoints
        {
            get;
        }

        /// <summary>
        /// Attack the given unit
        /// </summary>
        /// <param name="unit">The unit to attack</param>
        void AttackUnit(Unit unit);

        /// <summary>
        /// Move this unit to the given location, if possible
        /// </summary>
        /// <param name="x">X coordinate of the targeted cell</param>
        /// <param name="y">Y coordinate of the targeted cell</param>
        /// <returns>True if the unit moved, false otherwise</returns>
        bool Move(int x, int y);

        /// <summary>
        /// Kills this unit
        /// </summary>
        void Die();

        /// <summary>
        /// Know if the unit can move to the selected cell
        /// </summary>
        /// <param name="x">X coordinate of the targeted cell</param>
        /// <param name="y">Y coordinate of the targeted cell</param>
        /// <returns>True if the unit can move to the given cell</returns>
        bool CanMove(int x, int y);

        /// <summary>
        /// Sets the unit's moving points to their default
        /// </summary>
        void clearMovingPoints();
    }
}
