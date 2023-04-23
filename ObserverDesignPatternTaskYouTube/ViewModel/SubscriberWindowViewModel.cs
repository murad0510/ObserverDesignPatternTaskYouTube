using ObserverDesignPatternTaskYouTube.Commands;
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
    public class SubscriberWindowViewModel
    {
        public RelayCommand SignInButtonClicked { get; set; }
        public RelayCommand RegisterButtonClicked { get; set; }
        public SubscriberWindow SubscriberWindow { get; set; }

        public SubscriberWindowViewModel()
        {
            SignInButtonClicked = new RelayCommand((a) =>
            {
                SignInUseControl signInUseControl = new SignInUseControl();
                SubscriberWindow.MyStackPanel.Children.Clear();
                SubscriberWindow.MyStackPanel.Children.Add(signInUseControl);
                App.SubscriberWindow = SubscriberWindow;
            });

            RegisterButtonClicked = new RelayCommand((a) =>
            {
                RegisterUserControl registerUserControl = new RegisterUserControl();
                SubscriberWindow.MyStackPanel.Children.Clear();
                SubscriberWindow.MyStackPanel.Children.Add(registerUserControl);
                App.SubscriberWindow = SubscriberWindow;
            });
        }
    }
}
