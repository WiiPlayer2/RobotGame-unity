﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotGame.Models
{
    public interface ISaveLoad
    {
        Chunk LoadChunk(int x, int z);

        void SaveChunk(Chunk chunk);

        Robot LoadRobot(string id);

        void SaveRobot(Robot robot);
    }
}
