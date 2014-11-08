using PetitMonde.Units;
using System;
namespace PetitMonde
{
    public interface Player
    {

        void AttackUnit(Unit unit, Cell dest);

        void EndTurn();

        void Fight(Unit unit1, Unit unit2);

        void MoveUnit(Unit unit, int x, int y);

        bool HasLost();

        int GetScore();
    }
}
