using System;
namespace PetitMonde.Units
{
    public interface Unit
    {

        void AttackUnit(Unit unit);

        bool Move(int x, int y);

        void Die();

        bool IsDead();

        bool CanMove(int x, int y);

        int GetBonusPoints();
    }
}
