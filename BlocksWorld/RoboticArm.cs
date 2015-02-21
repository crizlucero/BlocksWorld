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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Environment">Entorno</param>
        public RoboticArm(Grid Environment)
        {
            this.initEnv = Environment;
            this.curEnv = Environment;
        }
        /// <summary>
        /// Apila un bloque con otro
        /// </summary>
        /// <param name="X">Bloque X</param>
        /// <param name="Y">Bloque Y</param>
        /// <returns>Se pudo efectuar la tarea</returns>
        public bool Stack(Label X, Label Y)
        {
            //Precondition
            if (this.Clear(X, this.curEnv) && this.Holding(Y))
            {
                Grid.SetRow(Y, Grid.GetRow(X) - 1);
                Grid.SetColumn(Y, Grid.GetColumn(X));
                //Add
                if (this.ArmEmpty(this.curEnv) && this.On(X, Y))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Quita un bloque que se encontraba encima de otro.
        /// </summary>
        /// <param name="X">Bloque X</param>
        /// <param name="Y">Bloque Y</param>
        /// <returns>Se pudo efectuar la tarea</returns>
        public bool Unstack(Label X, Label Y)
        {
            //Precondition
            if (this.On(X, Y) && this.Clear(Y, this.curEnv) && this.ArmEmpty(this.curEnv))
            {
                //Delete
                if (this.On(X, Y) && this.ArmEmpty(this.curEnv))
                {
                    //Add
                    Grid.SetColumn(Y, 3);
                    Grid.SetRow(Y, 1);
                    if (this.Holding(X) && this.Clear(Y, this.curEnv))
                    {
                        X.Visibility = System.Windows.Visibility.Hidden;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// El brazo carga un bloque
        /// </summary>
        /// <param name="X">Bloque X</param>
        /// <returns>Si pudo realizar la acción</returns>
        public bool PickUp(Label X)
        {
            //Precondition
            if (this.Clear(X, this.curEnv) && this.OnTable(X) && this.ArmEmpty(this.curEnv))
            {
                //Delete
                if (this.OnTable(X) && this.ArmEmpty(this.curEnv))
                {
                    //Add
                    if (!this.Holding(X))
                    {
                        X.Visibility = System.Windows.Visibility.Visible;
                        Grid.SetColumn(X, 3);
                        Grid.SetRow(X, 1);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Deja el bloque en la mesa
        /// </summary>
        /// <param name="X">Bloque X</param>
        /// <returns>Si pudo realizar la acción</returns>
        public bool PutDown(Label X)
        {
            //Precondition
            if (this.Holding(X))
            {
                //Delete
                Grid.SetRow(X, 3);
                switch (X.Content.ToString())
                {
                    case "A": Grid.SetColumn(X, 1); break;
                    case "B": Grid.SetColumn(X, 2); break;
                    case "C": Grid.SetColumn(X, 3); break;
                }
                //Add
                if (this.Clear(X, this.curEnv) && this.OnTable(X) && this.ArmEmpty(this.curEnv))
                {
                    return true;
                }
            }
            return false;
        }
    }
}