using PetitMonde.Units;
using System;
namespace PetitMonde
{
    public interface Player
    {
        Tribe Tribe { get; set; }
        System.Collections.Generic.List<Unit> Units { get; set; }
    }
}
