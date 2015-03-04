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
            List<List<string>> aux = new List<List<string>>();
            while (true)
            {
                aux.Clear();
                aux.AddRange(this.Believes.b0);
                this.Believes.b0.RemoveAll(i => this.Intentions.Goals.Contains(i));
                foreach (List<string> list in this.Intentions.Goals)
                    for (int i = 0; i < this.Believes.b0.Count; i++)
                        if (this.Believes.b0[i][0] == list[0] && this.Believes.b0[i][1] == list[1])
                        {
                            this.Believes.b0.RemoveAt(i);
                            break;
                        }

                foreach (List<string> list in aux)
                    for (int i = 0; i < this.Intentions.Goals.Count; i++)

                        if (this.Intentions.Goals[i][0] == list[0] && this.Intentions.Goals[i][1] == list[1])
                        {
                            this.Intentions.Goals.RemoveAt(i);
                            break;
                        }

                if (this.Intentions.Goals.Count != 0)
                {
                    bool flag = false;
                    for (int i = 0; i < this.Believes.b0.Count; i++)
                    {
                        foreach (var lbl in this.curEnv.Children)
                        {
                            if (lbl is Label)
                            {
                                if (((Label)lbl).Content.ToString() == this.Believes.b0[i][1])
                                {
                                    if (this.Believes.b0[i][0] == "On")
                                    {
                                        this.Intentions.PickUp((Label)lbl);
                                        
                                        flag = true;
                                        break;
                                    }
                                    else if (this.Believes.b0[i][0] == "Holding")
                                    {
                                        this.Intentions.PutDown((Label)lbl);
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (flag) break;
                    }
                    this.Believes.getBelieves();
                }
                else break;
            }
        }

    }
}