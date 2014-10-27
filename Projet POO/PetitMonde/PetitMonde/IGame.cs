using System;
namespace PetitMonde
{
    interface IGame
    {
        Player Player1 { get; set; }
        Player Player2 { get; set; }
    }
}
