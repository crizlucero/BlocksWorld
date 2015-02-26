using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlocksWorld
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RoboticArm ra;
        public MainWindow()
        {
            InitializeComponent();
            this.ra = new RoboticArm(this.Environment);
        }

        private void Stack_Click(object sender, RoutedEventArgs e)
        {
        //    Console.WriteLine(this.ra.Stack(this.BlockA,this.BlockB));
        }

        private void Unstack_Click(object sender, RoutedEventArgs e)
        {
          //  Console.WriteLine(this.ra.Unstack(this.BlockA,this.BlockB));
        }

        private void Pickup_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(this.ra.PickUp(this.BlockB));
        }

        private void Putdown_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(this.ra.PutDown(this.BlockB));
        }

    }
}
