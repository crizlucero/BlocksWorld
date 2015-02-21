using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BlocksWorld
{
    class Rules
    {
        /// <summary>
        /// El bloque 1 está encima del bloque 2
        /// </summary>
        /// <param name="X">Bloque 1</param>
        /// <param name="Y">Bloque 2</param>
        /// <returns>Si el bloque 1 está encima del bloque 2</returns>
        protected bool On(Label X, Label Y)
        {
            if (Grid.GetRow(X) == (Grid.GetRow(Y) + 1) && Grid.GetColumn(X) == Grid.GetColumn(Y)) return true;
            return false;
        }
        /// <summary>
        /// El bloque está en la mesa
        /// </summary>
        /// <param name="X">Bloque</param>
        /// <returns>Si el bloque está en la mesa</returns>
        protected bool OnTable(Label X)
        {
            if (Grid.GetRow(X) == 3) return true;
            return false;
        }
        /// <summary>
        /// Nada arriba de la caja
        /// </summary>
        /// <param name="X">Caja</param>
        /// <param name="E">Entorno</param>
        /// <returns>Si existe algo o no</returns>
        protected bool Clear(Label X, Grid E)
        {
            var el = E.Children.Cast<UIElement>().Where(e => Grid.GetColumn(e) == Grid.GetColumn(X) && Grid.GetRow(e) == Grid.GetRow(X) - 1 && e is Label);
            if (el.Count() == 0) return true;
            return false;
        }
        /// <summary>
        /// El brazo robótico sostiene al bloque
        /// </summary>
        /// <param name="X">Bloque</param>
        /// <returns>Si el brazo sostiene al bloque</returns>
        protected bool Holding(Label X)
        {
            if (Grid.GetRow(X) == 1 && Grid.GetColumn(X) == 3) return true;
            return false;
        }
        /// <summary>
        /// El brazo está desocupado
        /// </summary>
        /// <param name="X">Entorno</param>
        /// <returns>Si el brazo está desocupado</returns>
        protected bool ArmEmpty(Grid X)
        {
            var el = X.Children.Cast<UIElement>().Where(e => Grid.GetColumn(e) == 3 && Grid.GetRow(e) == 1 && e is Label);
            if (el.Count() == 0) return true;
            return false;
        }
    }
}
