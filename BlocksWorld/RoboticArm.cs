using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlocksWorld
{
    class RoboticArm : Rules
    {
        private Grid initEnv { get; set; }
        private Grid curEnv { get; set; }

        public RoboticArm(Grid Environment)
        {
            this.initEnv = Environment;
            this.curEnv = Environment;
        }

        public bool Stack(Label X, Label Y)
        {
            //Precondition
            if (Clear(Y) && Holding(X))
            {

                Grid.SetRow(X, Grid.GetRow(Y) - 1);
                Grid.SetColumn(X, Grid.GetColumn(Y));
                //Add
                if (ArmEmpty(this.curEnv) && On(X, Y))
                {
                    return true;
                }
            }
            return false;
        }

        public void Unstack(Label X, Label Y)
        {
            //Precondition
            if (On(X, Y) && Clear(X) && ArmEmpty(this.curEnv))
            {
                //Delete
                if (On(X, Y) && ArmEmpty(this.curEnv))
                {
                    //Add
                    if (Holding(X) && Clear(Y))
                    {
                    }
                }
            }
        }

        public void PickUp(Label X)
        {
            //Precondition
            if (Clear(X) && OnTable(X) && ArmEmpty(this.curEnv))
            {
                //Delete
                if (OnTable(X) && ArmEmpty(this.curEnv))
                {
                    //Add
                    if (!Holding(X))
                    {
                        X.Visibility = System.Windows.Visibility.Visible;
                        Grid.SetColumn(X, 3);
                        Grid.SetRow(X, 1);
                    }
                }
            }
        }

        public void PutDown(Label X)
        {
            //Precondition
            if (Holding(X))
            {
                //Delete
                Grid.SetRow(X, 3);
                switch (X.Content.ToString())
                {
                    case "A": Grid.SetColumn(X, 1); break;
                    case "B": Grid.SetColumn(X, 2); break;
                    case "C": Grid.SetColumn(X, 3); break;
                }
                if (Clear(X) && OnTable(X) && ArmEmpty(this.curEnv))
                {
                }
            }
        }
    }
}
