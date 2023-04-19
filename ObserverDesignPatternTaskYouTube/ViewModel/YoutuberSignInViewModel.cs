using ObserverDesignPatternTaskYouTube.Commands;
using ObserverDesignPatternTaskYouTube.Models;
using ObserverDesignPatternTaskYouTube.Views;
using ObserverDesignPatternTaskYouTube.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObserverDesignPatternTaskYouTube.ViewModel
{

    public class YoutuberSignInViewModel : BaseViewModel
    {
        public RelayCommand SingButtonClicked { get; set; }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        static List<Youtuber> youtubers = new List<Youtuber>
        {
            new Youtuber()
            {
                Name="Eyvaz",
                Password="1234"
            },
            new Youtuber()
            {
                Name="Mustang",
                Password="123"
            },
            new Youtuber()
            {
                Name="OPPO",
                Password="123"
            },
            new Youtuber()
            {
                Name="Iphone",
                Password="1234"
            },
        };

        static bool b = false;

        public YoutuberSignInViewModel()
        {
            if (!b)
            {
                App.Youtuber = youtubers;
                b = !b;
            }
            SingButtonClicked = new RelayCommand((a) =>
            {
                foreach (var item in youtubers)
                {
                    if (item.Name == Name && item.Password == Password)
                    {
                        YouTubeWindow youTubeWindow = new YouTubeWindow();
                        youTubeWindow.Show();
                    }
                }
            });
        }
    }
}
