using System;
using System.Collections;

namespace RobotGame.Models.Blocks
{
    public abstract class Block
    {
        public virtual void Tick() { }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }
    }
}
