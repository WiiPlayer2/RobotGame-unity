﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotGame.Models.Blocks
{
    public class Air : Block
    {
        public Air()
        {
            IsSolid = false;
            Hardness = -1;
        }
    }
}
