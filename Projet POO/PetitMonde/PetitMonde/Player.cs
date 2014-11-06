using PetitMonde.Units;
using System;
namespace PetitMonde
{
    public interface Player
    {
        Tribe Tribe { get; set; }
        System.Collections.Generic.List<Unit> Units { get; set; }

        void AttackUnit(Unit unit, Cell dest);

        void EndTurn();

        void Fight(Unit unit1, Unit unit2);

        void MoveUnit(Unit unit, int x, int y);
    }
}
