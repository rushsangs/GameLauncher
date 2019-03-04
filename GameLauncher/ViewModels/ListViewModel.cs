using GameLauncher.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameLauncher.ViewModels
{
    public class ListViewModel
    {
        private readonly NavigationViewModel _viewModel;
        public ICommand GameCommand { get; set; }
        public ListViewModel(NavigationViewModel viewModel)
        {
            loadGames();
            this._viewModel = viewModel;
            GameCommand = new BaseCommand(openGame);
        }

        public ObservableCollection<Game> games
        {
            get;
            set;
        }
        public void loadGames()
        {
            ObservableCollection<Game> games = new ObservableCollection<Game>();
            games.Add(new Game("Chess", 2012, false, "C:\\Program Files\\Microsoft Games\\Chess\\Chess.exe"));
            games.Add(new Game("FreeCell", 2002, true, "C:\\Program Files\\Microsoft Games\\FreeCell\\FreeCell.exe"));
            games.Add(new Game("Notepad", 1993, false, "notepad.exe"));
            this.games = games;
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
}
