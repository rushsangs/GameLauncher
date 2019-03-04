using GameLauncher.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace GameLauncher.Views
{
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        public ListViewModel MyListViewModel
        {
            get;
            set;
        }

        public ListView()
        {
            InitializeComponent();
        }

        //private void selectGame(object sender, RoutedEventArgs e)
        //{
            
        //    var game = ((Button)sender).Tag;
        //    Debug.WriteLine("button clicked" + game);
        //    DataContext = new GameViewModel();
        //}
    }
}
