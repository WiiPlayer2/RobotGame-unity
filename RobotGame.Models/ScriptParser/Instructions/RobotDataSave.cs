using ScriptFunction;
using ScriptFunction.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGame.Models.ScriptParser.Instructions
{
    class RobotDataSave : Instruction
    {
        public RobotDataSave(string arg)
        {
            Argument = arg;
        }

        public string Argument { get; private set; }

        public override void Execute(ScriptEnvironment env)
        {
            var robot = env.GetSpecialArgument<Robot>();
            robot.Data[Argument] = env.Pop();
        }
    }
}
