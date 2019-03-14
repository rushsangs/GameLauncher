using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
        public String image
        {
            get;
            set;
        }
        public String info
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
       
        public Game(String name, int year, Boolean isGradGame, String link, String image, String info)
        {
            this.name = name;
            this.year = year;
            this.isGradGame = isGradGame;
            this.link = link;
            this.image = image;
            this.info = info;
        }
        public String getGradString()
        {
            if (isGradGame)
                return "Graduate";
            else
                return "Undergraduate";
        }
        public BitmapImage makeImage(String path)
        {
            BitmapImage bmpi = new BitmapImage();
            bmpi.BeginInit();
            bmpi.UriSource = new Uri(path, UriKind.Absolute);
            bmpi.EndInit();
            return bmpi;
        }
    }
}
