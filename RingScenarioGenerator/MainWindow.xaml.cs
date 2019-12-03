using RingScenarioGenerator.Model.Scenarii;
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
        public static System.Windows.Threading.Dispatcher MainDispatcher { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();

            debugGrid_Click(null, null);
            MainDispatcher = this.Dispatcher;
        }

        Visibility debugInfo = Visibility.Hidden;

        private void debugGrid_Click(object sender, RoutedEventArgs e)
        {
            Ring1.Visibility = debugInfo;
            Ring2.Visibility = debugInfo;
            Ring3.Visibility = debugInfo;
            Ring4.Visibility = debugInfo;
            Line1.Visibility = debugInfo;
            Line2.Visibility = debugInfo;
            Line3.Visibility = debugInfo;
            Line4.Visibility = debugInfo;
            Line1bis.Visibility = debugInfo;
            Line2bis.Visibility = debugInfo;
            Line3bis.Visibility = debugInfo;
            Line4bis.Visibility = debugInfo;

            if (debugInfo == Visibility.Hidden)
            {
                debugInfo = Visibility.Visible;
            }
            else
            {
                debugInfo = Visibility.Hidden;
            }

            if(AbstractScenario.TOTAL_LED == 60)
            {
                led5_1.Visibility = Visibility.Hidden;
            }
        }
    }
}

