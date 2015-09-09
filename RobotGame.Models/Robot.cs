using RobotGame.Models.ScriptParser;
using ScriptFunction;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RobotGame.Models
{
    public class Robot
    {
        private ScriptDelegate scriptDelegate;
        private ScriptExecutionManager scriptExecution;

        static Robot()
        {
            Parser = new RobotScriptParser();
        }

        public Robot()
        {
            Data = new Dictionary<string, object>();
        }

        public static RobotScriptParser Parser { get; private set; }

        public World World { get; set; }

        #region Data
        public string ID { get; set; }

        public string Script { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public int Power { get; set; }

        public Dictionary<string, object> Data { get; private set; }

        public int Cooldown { get; set; }

        public int RechargeCooldown { get; set; }

        public int RechargePower { get; set; }

        public int RechargeCooldownSpeed { get; set; }
        #endregion

        public void LoadDelegate()
        {
            scriptDelegate = Parser.Create(Script);
        }

        public void StartScript()
        {
            scriptExecution = scriptDelegate.CreateExecutionManager();
            scriptExecution.KeepAsync = true;
        }

        public void Tick()
        {
            if (RechargeCooldown > 0)
            {
                RechargeCooldown--;
            }
            if (RechargeCooldown <= 0)
            {
                RechargeCooldown = RechargeCooldownSpeed;
                Power += RechargePower;
            }

            if(Cooldown > 0)
            {
                Cooldown--;
            }

            ActOnPower(1, () =>
            {
                if (scriptExecution == null)
                {
                    StartScript();
                }
                if (!scriptExecution.Step())
                {
                    scriptExecution = null;
                }
                Power--;
            });
        }

        public bool ActOnPower(int power, Action action)
        {
            if (Power >= power)
            {
                Power -= power;
                action();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}