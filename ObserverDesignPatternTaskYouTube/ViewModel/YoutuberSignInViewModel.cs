using ObserverDesignPatternTaskYouTube.Commands;
using ObserverDesignPatternTaskYouTube.Models;
using ObserverDesignPatternTaskYouTube.Views;
using ObserverDesignPatternTaskYouTube.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObserverDesignPatternTaskYouTube.ViewModel
{

    public class YoutuberSignInViewModel : BaseViewModel
    {
        public RelayCommand SingButtonClicked { get; set; }
        public RelayCommand BackButton { get; set; }


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

        static ObservableCollection<Youtuber> youtubers = new ObservableCollection<Youtuber>
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
                for (int i = 0; i < youtubers.Count; i++)
                {
                    if (youtubers[i].Name == Name && youtubers[i].Password == Password)
                    {
                        YouTubeWindow youTubeWindow = new YouTubeWindow();
                        App.SignInYoutuberName = youtubers[i].Name;
                        
                        youTubeWindow.ShowDialog();
                        Name = string.Empty;
                        Password=string.Empty;
                        break;
                    }
                    else if (i == youtubers.Count - 1)
                    {
                        MessageBox.Show("Incorrect username or password!!!");
                    }
                }
            });
        }
    }
}
