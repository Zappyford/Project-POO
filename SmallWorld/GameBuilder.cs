using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde
{
    public interface GameBuilder
    {
        /// <summary>
        /// Builds the game
        /// </summary>
        /// <returns>The game</returns>
        PetitMonde.Game BuildGame();
    }
}
