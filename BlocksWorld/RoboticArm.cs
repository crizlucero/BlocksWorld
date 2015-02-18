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
                if (ArmEmpty(X) && On(X, Y))
                {
                    return true;
                }
            }
            return false;
        }

        public void Unstack(Label X, Label Y);

        public void PickUp(Label X);

        public void PutDown(Label X);
    }
}
