using System;
namespace PetitMonde.Map
{
    public interface MapBuilder
    {
        /// <summary>
        /// Builds the map
        /// </summary>
        /// <returns>The map</returns>
        Map BuildMap();


        /// <summary>
        /// The number of unit per default for the size of the map
        /// </summary>
        int NumberOfUnits
        {
            get;
        }

        /// <summary>
        /// Number of turn to play for the size of the map
        /// </summary>
        int TurnsToPlay
        {
            get;
        }
    }
}
