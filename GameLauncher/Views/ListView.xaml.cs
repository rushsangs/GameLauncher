using GameLauncher.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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

        

        

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var colView = Resources["cvs"] as CollectionViewSource;
            MyListViewModel.Sort(colView, (sender as ComboBox).SelectedItem);
            
        }

        //private void selectGame(object sender, RoutedEventArgs e)
        //{

        //    var game = ((Button)sender).Tag;
        //    Debug.WriteLine("button clicked" + game);
        //    DataContext = new GameViewModel();
        //}

        
    }
    

}
