using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Models
{
    public class GameModel { }
    public class Game  
    {
        public String name
        {
            get;
            set;
        }
        public int year
        {
            get;
            set;
        }
        public Boolean isGradGame
        {
            set;
            get;
        }
        public String link
        {
            get;
            set;
        }
        public String gradString
        {
            get
            {
                return getGradString();
            }
        }
        public Game(String name, int year, Boolean isGradGame, String link)
        {
            this.name = name;
            this.year = year;
            this.isGradGame = isGradGame;
            this.link = link;
        }
        public String getGradString()
        {
            if (isGradGame)
                return "Graduate";
            else
                return "Undergraduate";
        }

    }
}
