using System;
namespace PetitMonde
{
    interface IUnit
    {
        int Attack { get; set; }
        int Coordinates { get; set; }
        int Defense { get; set; }
        int Health { get; set; }
    }
}
