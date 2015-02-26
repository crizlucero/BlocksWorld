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
            while(flag){

            }
        }

    }
}