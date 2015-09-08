using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotGame.Models
{
    public interface IGenerator
    {
        Chunk Generate(ChunkManager manager, int x, int z);
    }
}
