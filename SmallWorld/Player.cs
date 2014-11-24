using PetitMonde.Units;
using System.Collections.Generic;
namespace PetitMonde
{
    public interface Player
    {
        /// <summary>
        /// 
        /// </summary>
        void EndTurn();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit1"></param>
        /// <param name="unit2"></param>
        void Fight(Unit unit1, Unit unit2);

        /// <summary>
        /// 
        /// </summary>
        bool HasLost
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        int Score
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        List<Unit> GetUnitsOnCell(int x, int y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        Unit GetBestDefensiveUnit(int x, int y);
    }
}
