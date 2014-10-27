using System;
namespace PetitMonde
{
    interface IPlayer
    {
        Tribe Tribe { get; set; }
        System.Collections.Generic.List<Unit> Units { get; set; }
    }
}
