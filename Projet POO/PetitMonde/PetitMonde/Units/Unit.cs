using System;
namespace PetitMonde.Units
{
    public interface Unit
    {

        void AttackUnit(string Unit);

        bool Move(int x, int y);

        void Die();

        bool IsDead();
    }
}
