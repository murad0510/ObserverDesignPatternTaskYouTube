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

                for (int i = 0; i < subscribers.Count; i++)
                {
                    if (subscribers[i].Name == Name && subscribers[i].Password == Password)
                    {
                        App.Subscriber = subscribers[i];
                        if (!b)
                        {
                            YoutuberSignInViewModel youtuberSignIn = new YoutuberSignInViewModel();
                            b = !b;
                        }

                        for (int k = 0; k < App.Youtuber.Count; k++)
                        {
                            CorrectSignInUserControl correctSignInUserControl = new CorrectSignInUserControl();

                            //if (AppSubscriberWindowClear)
                            //{
                            //    App.SubscriberWindow.MyStackPanel.Children.Clear();
                            //    AppSubscriberWindowClear = !AppSubscriberWindowClear;
                            //}

                            ////YoutubeShowAllSubscriberWindow youtubeShowAll = new YoutubeShowAllSubscriberWindow();
                            ////youtubeShowAll.Title = correctSignInUserControl.Content.ToString();
                            ////correctSignInUserControl1.YoutubeShowAlls.Add(youtubeShowAll);

                            //correctSignInUserControl.Margin = new Thickness(100, 30, 0, 0);
                            //App.SubscriberWindow.MyStackPanel.Children.Add(correctSignInUserControl);
                        }

                        CorrectSignInUserControl signInUserControl = new CorrectSignInUserControl();
                        CorrectSignInUserControlViewModel correctSignInUserControl1 = new CorrectSignInUserControlViewModel();
                        correctSignInUserControl1.YoutuberName = subscribers[i].Name;
                        App.SubscriberWindow.MyStackPanel.Children.Clear();
                        App.SubscriberWindow.MyStackPanel.Children.Add(signInUserControl);
                        Name = string.Empty;
                        Password = string.Empty;
                        break;
                    }
                    else if (i == subscribers.Count - 1)
                    {
                        MessageBox.Show("Incorrect username or password!!!");
                    }
                }
            });

            BackButton = new RelayCommand((a) =>
            {
                //MessageBox.Show("a");
                SubscriberWindow subscriber = new SubscriberWindow();
                App.SubscriberWindow.Close();
                subscriber.ShowDialog();
                App.SubscriberWindow = subscriber;
                //App.SubscriberWindow.MyStackPanel.Children.Clear();
                //App.SubscriberWindow.MyStackPanel.Children.Add(subscriber);
            });

            RegisterButtonClicked = new RelayCommand((a) =>
            {
                Subscriber subscriber = new Subscriber();
                subscriber.Name = RegisterName;
                subscriber.Password = RegisterPassword;
                subscribers.Add(subscriber);
                MessageBox.Show("You have successfully registered");
            });
        }
    }
}
