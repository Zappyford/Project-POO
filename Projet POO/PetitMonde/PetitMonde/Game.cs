using PetitMonde.Map.Cells;
using PetitMonde.Units;
using System;
namespace PetitMonde
{
    public interface Game
    {
        Player Player1 { get; set; }
        Player Player2 { get; set; }

        Map.Map Map
        {
            get;
            set;
        }

        Player GetCurrentPlayer();
    }
}
