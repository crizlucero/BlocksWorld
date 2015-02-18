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
        public bool On(Label X, Label Y)
        {
            if (X.IsVisible && (Grid.GetRow(X) == (Grid.GetRow(Y) - 1)))
                return true;
            return false;
        }
        public bool OnTable(Label X)
        {
            if (X.IsVisible)
                return true;
            return false;
        }
        public bool Clear(Label X)
        {
            return false;
        }
        public bool Holding(Label X)
        {
            if (X.IsVisible && (Grid.GetRow(X) == 1 && Grid.GetColumn(X) == 3))
                return true;
            return false;
        }

        public bool ArmEmpty(Label X)
        {
            if (X.IsVisible && (Grid.GetRow(X) == 1 && Grid.GetColumn(X) == 3))
                return true;
            return false;
        }
    }
}
