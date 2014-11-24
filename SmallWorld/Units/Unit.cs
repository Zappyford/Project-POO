using System;
namespace PetitMonde.Units
{
    public interface Unit: IComparable<Unit>
    {
        int Attack
        {
            get;
            set;
        }

        int Defense
        {
            get;
            set;
        }


        int Health
        {
            get;
            set;
        }

        int X
        {
            get;
            set;
        }

        int Y
        {
            get;
            set;
        }

        float MovingPoints
        {
            get;
            set;
        }

        

        Faction Faction
        {
            get;
            set;
        }

        Boolean IsDead
        {
            get;
        }
        int BonusPoints
        {
            get;
        }
        void AttackUnit(Unit unit);

        bool Move(int x, int y);

        void Die();

        bool CanMove(int x, int y);

    }
}
