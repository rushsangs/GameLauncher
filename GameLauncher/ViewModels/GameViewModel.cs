using GameLauncher.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameLauncher.ViewModels
{
    public class GameViewModel
    {
        private readonly NavigationViewModel _viewModel;
        public ICommand BackCommand { get; set; }
        public ICommand PlayGameCommand { get; set; }

        public Game Game
        {
            get;
            set;
        }

        public GameViewModel(NavigationViewModel viewModel, Game game)
        {
            this._viewModel = viewModel;
            this.Game = game;
            BackCommand = new BaseCommand(backToListView);
            PlayGameCommand = new BaseCommand(playGame);
        }

        private void playGame(Game g)
        {
            Process.Start(Game.link);
        }
        private void backToListView(Object obj)
        {
            Debug.WriteLine("going back to list view ");
            _viewModel.SelectedViewModel = new ListViewModel(_viewModel);
        }
    }
}
