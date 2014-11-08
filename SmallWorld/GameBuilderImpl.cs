using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde
{
    public abstract class GameBuilderImpl : GameBuilder
    {
        public abstract Game BuildGame();
    }
}
