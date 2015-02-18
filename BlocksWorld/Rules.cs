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
        public bool On(Label X, Label Y)
        {
            if (X.IsVisible && (Grid.GetRow(X) == (Grid.GetRow(Y) - 1)))
                return true;
            return false;
        }
        /// <summary>
        /// El bloque está en la mesa
        /// </summary>
        /// <param name="X">Bloque</param>
        /// <returns>Si el bloque está en la mesa</returns>
        public bool OnTable(Label X)
        {
            if (X.IsVisible)
                return true;
            return false;
        }
        /// <summary>
        /// Nada arriba de la caja
        /// </summary>
        /// <param name="X">Caja</param>
        /// <returns>Si existe algo o no</returns>
        public bool Clear(Label X)
        {
            return false;
        }
        /// <summary>
        /// El brazo robótico sostiene al bloque
        /// </summary>
        /// <param name="X">Bloque</param>
        /// <returns>Si el brazo sostiene al bloque</returns>
        public bool Holding(Label X)
        {
            if (X.IsVisible && (Grid.GetRow(X) == 1 && Grid.GetColumn(X) == 3))
                return true;
            return false;
        }
        /// <summary>
        /// El brazo está desocupado
        /// </summary>
        /// <param name="X">Bloque</param>
        /// <returns>Si el brazo está desocupado</returns>
        public bool ArmEmpty(Label X)
        {
            if (X.IsVisible && (Grid.GetRow(X) == 1 && Grid.GetColumn(X) == 3))
                return true;
            return false;
        }
    }
}
