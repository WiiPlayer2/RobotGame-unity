using ScriptFunction;
using ScriptFunction.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGame.Models.ScriptParser.Instructions
{
    abstract class CooldownInstruction : Instruction
    {
        public override void Execute(ScriptEnvironment env)
        {
            var robot = env.SpecialArgument as Robot;
            if (robot.Cooldown == 0)
            {
                Execute(env, robot);
            }
            else
            {
                robot.Cooldown--;
                env.ProgramCounter--;
            }
        }

        protected abstract void Execute(ScriptEnvironment env, Robot robot);
    }
}
