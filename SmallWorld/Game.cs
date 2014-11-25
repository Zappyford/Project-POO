using PetitMonde.Units;
namespace PetitMonde
{
    public interface Game
    {
        PetitMonde.PlayerImpl Player2
        {
            get;
            set;
        }

        PetitMonde.PlayerImpl Player1
        {
            get;
            set;
        }


        PetitMonde.Map.MapImpl Map
        {
            get;
            set;
        }


        PetitMonde.PlayerImpl CurrentPlayer
        {
            get;
        }

        Unit SelectedUnit
        {
            get;
            set;
        }

        int XSelected
        {
            get;
            set;
        }

        int YSelected
        {
            get;
            set;
        }

        PlayerImpl OpponentPlayer
        {
            get;
        }

        void AttackUnit(Units.Unit unit, Map.Cells.Cell dest);
    }
}
