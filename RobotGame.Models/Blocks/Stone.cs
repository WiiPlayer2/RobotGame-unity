using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGame.Models.Blocks
{
    public class Stone : Block
    {
        public Stone()
        {
            IsSolid = true;
            Hardness = 10;
        }
    }
}
