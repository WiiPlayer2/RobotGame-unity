using System;
using System.Collections;

namespace RobotGame.Models
{
    public class Chunk
    {
        public const int WIDTH = 16;
        public const int DEPTH = 16;
        public const int HEIGHT = 256;

        public Block this[int x, int y, int z]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}