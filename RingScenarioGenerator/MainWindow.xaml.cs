using RingScenarioGenerator.ViewModel;
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

namespace RingScenarioGenerator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();

            if(!System.Diagnostics.Debugger.IsAttached)
            {
                Ring1.Visibility = Visibility.Hidden;
                Ring2.Visibility = Visibility.Hidden;
                Ring3.Visibility = Visibility.Hidden;
                Ring4.Visibility = Visibility.Hidden;
                Line1.Visibility = Visibility.Hidden;
                Line2.Visibility = Visibility.Hidden;
                Line3.Visibility = Visibility.Hidden;
                Line4.Visibility = Visibility.Hidden;
                Line1bis.Visibility = Visibility.Hidden;
                Line2bis.Visibility = Visibility.Hidden;
                Line3bis.Visibility = Visibility.Hidden;
                Line4bis.Visibility = Visibility.Hidden;
            }

   
        }



    }
}
