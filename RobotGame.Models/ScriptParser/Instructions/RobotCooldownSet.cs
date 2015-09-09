using ScriptFunction;
using ScriptFunction.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGame.Models.ScriptParser.Instructions
{
    class RobotCooldownSet : Instruction
    {
        public RobotCooldownSet(int turns)
        {
            Turns = turns;
        }

        public int Turns { get; private set; }

        public override void Execute(ScriptEnvironment env)
        {
            var robot = env.GetSpecialArgument<Robot>();
            if(robot.Cooldown < Turns)
            {
                robot.Cooldown = Turns;
            }
        }
    }
}
