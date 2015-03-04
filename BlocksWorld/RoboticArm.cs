using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlocksWorld
{
    class RoboticArm
    {
        private Grid initEnv { get; set; }
        private Grid curEnv { get; set; }

        private Intention Intentions;
        private Belief Believes;
        private Desire Desires;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Environment">Entorno</param>
        public RoboticArm(Grid Environment)
        {
            this.initEnv = Environment;
            this.curEnv = Environment;
            this.Intentions = new Intention(Environment);
            this.Believes = new Belief(Environment);
            this.Desires = new Desire();
        }

        public void DoAction()
        {
            bool flag = true;
            List<List<string>> temp = new List<List<string>>();
            while (flag)
            {
                foreach (List<string> list in this.Intentions.Goals)
                {
                    if (this.Believes.b0.Remove(new List<string> { list[0], list[1] }))
                        temp.Add(list);
                }
                foreach (List<string> list in temp)
                    this.Intentions.Goals.Remove(new List<string> { list[0], list[1] });
                if (this.Believes.b0.Count != 0)
                {
                    this.Believes.getBelieves();
                }
                else flag = false;

            }
        }

    }
}