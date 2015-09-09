using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotGame.Models
{
    public class RobotManager : IEnumerable<Robot>
    {
        private Dictionary<string, Robot> loadedRobots;

        public RobotManager(ISaveLoad saveload)
        {
            SaveLoad = saveload;

            loadedRobots = new Dictionary<string, Robot>();
        }

        public Robot this[string id]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void UnloadAll()
        {
            foreach(var r in loadedRobots.Values)
            {
                SaveLoad.SaveRobot(r);
            }
        }

        public ISaveLoad SaveLoad { get; private set; }

        public void Tick()
        {
            foreach(var r in loadedRobots.Values)
            {
                r.Tick();
            }
        }

        public IEnumerator<Robot> GetEnumerator()
        {
            return loadedRobots.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
