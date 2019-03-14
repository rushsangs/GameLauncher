using GameLauncher.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
using static GameLauncher.ViewModels.ListViewModel;

namespace GameLauncher.ViewModels
{
    public class ListViewModel
    {
        private readonly NavigationViewModel _viewModel;
        public ICommand GameCommand { get; set; }
        public ICommand SortingCommand { get; set; }
        public ListViewModel(NavigationViewModel viewModel)
        {
            loadGames();
            this._viewModel = viewModel;
            GameCommand = new BaseCommand(openGame);
            SortingCommand = new SortCommand(sortFunction);
        }

        public ObservableCollection<Game> games
        {
            get;
            set;
        }

        public enum OrderBy
        {
            [Description("name")]
            name = 0,

            [Description("year")]
            year = 1,

            [Description("gradString")]
            gradString = 2
        }

        internal void sortFunction(Object sortString)
        {
            ICollectionView colView = CollectionViewSource.GetDefaultView(games);
            System.Type a = sortString.GetType();
            Object b =(sortString as ComboBox).SelectedValue ;
            switch (b)
            {
                case  OrderBy.name:
                    colView.SortDescriptions.Clear();
                    colView.SortDescriptions.Add(new SortDescription("name", ListSortDirection.Ascending));
                    
                    colView.Refresh();
                    break;
                case OrderBy.year:
                    colView.SortDescriptions.Clear();
                    colView.SortDescriptions.Add(new SortDescription("year", ListSortDirection.Ascending));
                    colView.Refresh();
                    break;
                case OrderBy.gradString:
                    colView.SortDescriptions.Clear();
                    colView.SortDescriptions.Add(new SortDescription("gradString", ListSortDirection.Ascending));
                    colView.Refresh();
                    break;
            }
        }
        internal void Sort(CollectionViewSource colView, object selectedItem)
        {
            switch ((selectedItem as OrderOption).OrderBy)
            {
                case OrderBy.name:
                    colView.SortDescriptions.Clear();
                    colView.SortDescriptions.Add(new SortDescription("name", ListSortDirection.Ascending));
                    break;
                case OrderBy.year:
                    colView.SortDescriptions.Clear();
                    colView.SortDescriptions.Add(new SortDescription("year", ListSortDirection.Ascending));
                    break;
                case OrderBy.gradString:
                    colView.SortDescriptions.Clear();
                    colView.SortDescriptions.Add(new SortDescription("gradString", ListSortDirection.Ascending));
                    break;
            }
        }
        

        //public void loadGames()
        //{
        //    ObservableCollection<Game> games = new ObservableCollection<Game>();
        //    games.Add(new Game("Chess", 2012, false, "C:\\Program Files\\Microsoft Games\\Chess\\Chess.exe", @"C:\\Users\\drwiner\\Desktop\\chess.jpg", "Chess is a game"));
        //    games.Add(new Game("FreeCell", 2002, true, "C:\\Program Files\\Microsoft Games\\FreeCell\\FreeCell.exe", @"C:\\Users\\drwiner\\Desktop\\freecell.jpg", "Freecell is a game"));
        //    games.Add(new Game("Notepad", 1993, false, "notepad.exe", @"C:\\Users\\drwiner\\Desktop\\notepad.jpg", "Some info"));
        //    this.games = games;
        //}

        public IEnumerable<OrderOption> OrderOptions
        {
            get
            {
                return
                    Enum
                        .GetValues(typeof(OrderBy))
                        .Cast<OrderBy>()
                        .Select(x => new OrderOption { OrderBy = x, Description = x.ToString() });
            }
        }

        private void openGame(Game game)
        {
            Debug.WriteLine("opening game: ");
            if (game != null)
                Debug.WriteLine(game.name);
            else
                Debug.WriteLine("no arguemnt");
            _viewModel.SelectedViewModel = new GameViewModel(_viewModel, game);
        }

        public void loadGames()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"games.xml");
            ObservableCollection<Game> games = new ObservableCollection<Game>();
            XmlNode root = doc.LastChild;

            foreach (XmlNode xn in root.ChildNodes)
            {
                String name = xn["Name"].InnerText;
                int year = Int32.Parse(xn["Year"].InnerText);
                bool isGrad = Boolean.Parse(xn["IsGrad"].InnerText);
                String info = xn["Info"].InnerText;
                String imgpath = xn["ImagePath"].InnerText;
                String gamepath = xn["GamePath"].InnerText;

                Game g = new Game(name, year, isGrad, gamepath, imgpath, info);
                games.Add(g);
            }


            this.games = games;
        }

        //public void orderByName()
        //{
        //    var ng = from item in games orderby item.name select item;
        //    games = new ObservableCollection<Game>(ng);

        //}

        //public void orderByYear()
        //{
        //    games.OrderBy(g => g.year);
        //    games.Add(new Game("Chess", 2012, false, "C:\\Program Files\\Microsoft Games\\Chess\\Chess.exe", @"C:\\Users\\drwiner\\Desktop\\chess.jpg", "Chess is a game"));
            
        //    //var ng = from item in games orderby item.year select item;
        //    //games = new ObservableCollection<Game>(ng);
        //}
    }

    internal class BaseCommand : ICommand
    {
        private Action<Game> openGame;

        public BaseCommand(Action<Game> openGame)
        {
            this.openGame = openGame;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            openGame((Game)parameter);
        }
    }
    internal class SortCommand : ICommand
    {
        private Action<Object> sortFunction;
       
        public SortCommand(Action<Object> sortFunction)
        {
            this.sortFunction = sortFunction;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            sortFunction(parameter);
        }
    }
    public class OrderOption
    {
        public OrderBy OrderBy { get; set; }

        public string Description { get; set; }
    }



}
