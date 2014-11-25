﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Map
{
    class InvalidCellException : Exception
    {
        public InvalidCellException() 
            : base("Invalid coordinates were given.") 
        { }
    }
}
