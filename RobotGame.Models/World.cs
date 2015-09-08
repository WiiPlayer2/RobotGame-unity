using RobotGame.Models.Blocks;
using System;
using System.Collections;

namespace RobotGame.Models
{
    public class World
    {
        public Chunk this[int x, int z]
        {
            get
            {
                return ChunkManager[x, z];
            }
        }

        public Block this[int x, int y, int z]
        {
            get
            {
                return this[x / Chunk.WIDTH, z / Chunk.DEPTH][x % Chunk.WIDTH, y, z % Chunk.DEPTH];
            }
            set
            {
                this[x / Chunk.WIDTH, z / Chunk.DEPTH][x % Chunk.WIDTH, y, z % Chunk.DEPTH] = value;
            }
        }

        public ChunkManager ChunkManager { get; private set; }
    }
}