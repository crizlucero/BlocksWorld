using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BlocksWorld
{
    class Belief : Rules
    {
        private Grid curEnv { get; set; }
        public List<List<string>> b0 = new List<List<string>>();
        public Belief(Grid Environment)
        {
            this.curEnv = Environment;
            this.getBelieves();
        }

        public void getBelieves()
        {
            bool flag = true;
            foreach (UIElement child in this.curEnv.Children)
            {
                if (child is Label)
                {
                    //Hold the box
                    if (Grid.GetColumn(child) == 3 && Grid.GetRow(child) == 1)
                    {
                        this.b0.Add(new List<string> { "Holding", ((Label)child).Content.ToString() });
                        flag = false;
                    }

                    //On a box
                    if (Grid.GetColumn(child) == 1 && Grid.GetRow(child) == 2)
                    {
                        var e = this.curEnv.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetColumn(x) == Grid.GetColumn(child) && Grid.GetRow(x) == (Grid.GetRow(child) + 1) && x is Label);
                        this.b0.Add(new List<string> { "On", ((Label)child).Content.ToString(), ((Label)e).Content.ToString() });
                    }
                    //On the table
                    if ((Grid.GetColumn(child) == 1 || Grid.GetColumn(child) == 2 || Grid.GetColumn(child) == 3) && Grid.GetRow(child) == 3)
                    {
                        this.b0.Add(new List<string> { "OnTable", ((Label)child).Content.ToString() });
                    }
                    //Clear
                    var box = this.curEnv.Children.Cast<UIElement>().Where(x => Grid.GetColumn(x) == Grid.GetColumn(child) && Grid.GetRow(x) == (Grid.GetRow(child) - 1) && x is Label && ((Label)x).Content != ((Label)child).Content);
                    if (box.Count() == 0)
                    {

                        this.b0.Add(new List<string> { "Clear", ((Label)child).Content.ToString() });
                    }
                }
            }
            //Arm free
            if (flag) 
            {
                this.b0.Add(new List<string> { "ArmEmpty" });
            }
        }

    }
}
