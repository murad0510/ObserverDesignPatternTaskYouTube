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
    public class SignInUserControlViewModel : BaseViewModel
    {
        public RelayCommand SingButtonClicked { get; set; }
        public RelayCommand RegisterButtonClicked { get; set; }


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

        private string registerName;

        public string RegisterName
        {
            get { return registerName; }
            set { registerName = value; OnPropertyChanged(); }
        }

        private string registerPassword;

        public string RegisterPassword
        {
            get { return registerPassword; }
            set { registerPassword = value; OnPropertyChanged(); }
        }


        static List<Subscriber> subscribers = new List<Subscriber>
        {
            new Subscriber()
            {
                Name="Orxan",
                Password="123"
            },
            new Subscriber()
            {
                Name="Ilkin",
                Password="1234"
            },
        };
        static bool AppSubscriberWindowClear = true;
        static bool b = false;
        public SignInUserControlViewModel()
        {
            SingButtonClicked = new RelayCommand((a) =>
            {
                foreach (var item in subscribers)
                {
                    if (item.Name == Name && item.Password == Password)
                    {
                        if (!b)
                        {
                            YoutuberSignInViewModel youtuberSignIn = new YoutuberSignInViewModel();
                            b = !b;
                        }
                        CorrectSignInUserControlViewModel correctSignInUserControl1 = new CorrectSignInUserControlViewModel();
                        correctSignInUserControl1.YoutuberName = item.Name;
                        App.Subscriber = item;
                        for (int i = 0; i < App.Youtuber.Count; i++)
                        {
                            CorrectSignInUserControl correctSignInUserControl = new CorrectSignInUserControl();
                            if (AppSubscriberWindowClear)
                            {
                                App.SubscriberWindow.MyStackPanel.Children.Clear();
                                AppSubscriberWindowClear = !AppSubscriberWindowClear;
                            }
                            correctSignInUserControl1.CheckBoxTextWriter(correctSignInUserControl);
                            //correctSignInUserControl.Margin = new Thickness(0, 0, 0, 10);
                            //App.SubscriberWindow.MyStackPanel.Children.Add(correctSignInUserControl);
                        }
                    }
                }
            });

            RegisterButtonClicked = new RelayCommand((a) =>
            {
                Subscriber subscriber = new Subscriber();
                subscriber.Name = RegisterName;
                subscriber.Password = RegisterPassword;
                subscribers.Add(subscriber);
                MessageBox.Show("Successfully register");
            });
        }
    }
}
