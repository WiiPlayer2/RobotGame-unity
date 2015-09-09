using System;
using System.Collections;
using System.Collections.Generic;

namespace RobotGame.Models.Blocks
{
    public abstract class Block
    {
        protected Block()
        {
            Data = new Dictionary<string, object>();
        }

        public virtual void Tick() { }

        public virtual bool IsSolid { get; protected set; }

        public virtual int Hardness { get; protected set; }

        #region Data
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public Dictionary<string, object> Data { get; private set; }
        #endregion

        public World World { get; set; }
    }
}
