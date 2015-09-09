using RobotGame.Models.ScriptParser.Instructions;
using ScriptFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotGame.Models.ScriptParser
{
    public class RobotScriptParser : ScriptFunction.ScriptParser
    {
        static RobotScriptParser()
        {
            RegisterCommand("robot.move.forward", m => null);
            RegisterCommand("robot.move.back", m => null);

            RegisterCommand("robot.turn.left", m => null);
            RegisterCommand("robot.turn.right", m => null);

            RegisterCommand("robot.data.save", "(?<arg>.+)", m =>
                {
                    return new RobotDataSave(m.Groups["arg"].Value);
                });
            RegisterCommand("robot.data.load", "(?<arg>.+)", m =>
                {
                    return new RobotDataLoad(m.Groups["arg"].Value);
                });
            RegisterCommand("robot.data.exist", "(?<arg>.+)", m =>
                {
                    return new RobotDataExist(m.Groups["arg"].Value);
                });

            RegisterCommand("robot.cooldown.wait", m => new RobotCooldownWait());
            RegisterCommand("robot.cooldown.set", @"(?<turns>\d+)", m =>
            {
                var turns = int.Parse(m.Groups["turns"].Value);
                return new RobotCooldownSet(turns);
            });

            RegisterCommand("robot.construct.dig", m => null);
            RegisterCommand("robot.construct.place", m => null);
        }
    }
}
