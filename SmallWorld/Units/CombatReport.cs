using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitMonde.Units
{
    public class CombatReport
    {
        public Unit AttackingUnit
        {
            get;
            set;
        }

        public Unit DefensingUnit 
        {   get; 
            set; 
        }

        public int AttackingUnitLostHealth
        {
            get;
            set;
        }

        public int DefensingUnitLostHealth
        {
            get;
            set;
        }

        public bool AttackingUnitRetreat
        {
            get;
            set;
        }

        public bool DefensingUnitRetreat
        {
            get;
            set;
        }

        public bool AttackingUnitDead
        {
            get { return AttackingUnit.IsDead; }
        }

        public bool DefensingUnitDead
        {
            get { return DefensingUnit.IsDead; }
        }

        public CombatReport(Unit AttackingUnit, Unit DefensingUnit)
        {
            this.AttackingUnit = AttackingUnit;
            this.DefensingUnit = DefensingUnit;
            this.AttackingUnitLostHealth = 0;
            this.DefensingUnitLostHealth = 0;
            AttackingUnitRetreat = false;
            DefensingUnitRetreat = false;
        }
    }
}
