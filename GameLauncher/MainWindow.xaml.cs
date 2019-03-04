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

namespace GameLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new NavigationViewModel();
            viewModel.SelectedViewModel = new ListViewModel(viewModel);
            this.DataContext = viewModel;
        }

        private void LaunchGame1Button_Click(object sender, RoutedEventArgs e)
        {
            Launcher.PlayGame1();
        }

        private void LaunchGame2Button_Click(object sender, RoutedEventArgs e)
        {
            Launcher.playGame2();
        }
        private void LaunchGame3Button_Click(object sender, RoutedEventArgs e)
        {
            Launcher.playGame3();
        }

        //private void SelectGameButton_Click(object sender, RoutedEventArgs e)
        //{
        //    DataContext = new GameViewModel();
        //}
    }
}
