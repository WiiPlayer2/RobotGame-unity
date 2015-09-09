using RobotGame.Models.Blocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RobotGame.Models
{
    public class Chunk : IEnumerable<Block>
    {
        public const int WIDTH = 16;
        public const int DEPTH = 16;
        public const int HEIGHT = 256;

        private Block[, ,] blocks;

        public Chunk()
        {
            blocks = new Block[WIDTH, HEIGHT, DEPTH];
        }

        public Block this[int x, int y, int z]
        {
            get
            {
                return blocks[x, y, z];
            }
            set
            {
                blocks[x, y, z] = value;
            }
        }

        public void Tick()
        {
            foreach(var b in blocks)
            {
                b.Tick();
            }
        }

        #region Data
        public int X { get; set; }

        public int Z { get; set; }
        #endregion

        public IEnumerator<Block> GetEnumerator()
        {
            return blocks
                .Cast<Block>()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return blocks.GetEnumerator();
        }
    }
}