using ObserverDesignPatternTaskYouTube.Commands;
using ObserverDesignPatternTaskYouTube.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObserverDesignPatternTaskYouTube.ViewModel
{
    public class MainWindowViewModel
    {
        public RelayCommand SubscriberButtonClicked { get; set; }
        public RelayCommand YouTubeButtonClicked { get; set; }

        public MainWindowViewModel()
        {
            SubscriberButtonClicked = new RelayCommand((a) =>
            {
                SubscriberWindow subscriberWindow= new SubscriberWindow();
                subscriberWindow.ShowDialog();
            });

            YouTubeButtonClicked = new RelayCommand((a) =>
            {
                YoutuberSignInWindow youtuberSignInWindow= new YoutuberSignInWindow();
                youtuberSignInWindow.ShowDialog();
            });

        }
    }
}
