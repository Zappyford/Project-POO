﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetitMonde.Map.Cells
{
    public interface Cell
    {
        int x { get; }
        int y { get; }
        public CellType Type { get; }
    }
}
