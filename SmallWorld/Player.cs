using PetitMonde.Units;
using System.Collections.Generic;
namespace PetitMonde
{
    public interface Player
    {

        void EndTurn();

        void Fight(Unit unit1, Unit unit2);

        bool HasLost();

        int GetScore();

        List<Unit> GetUnitsOnCell(int x, int y);

        Unit GetBestDefensiveUnit(int x, int y);
    }
}
