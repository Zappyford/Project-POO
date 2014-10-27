using System;
namespace PetitMonde.Units
{
    public interface Unit
    {
        int Attack { get; set; }
        int Coordinates { get; set; }
        int Defense { get; set; }
        int Health { get; set; }
    }
}
