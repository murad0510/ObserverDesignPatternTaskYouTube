using ObserverDesignPatternTaskYouTube.Models;
using ObserverDesignPatternTaskYouTube.ViewModel;
using ObserverDesignPatternTaskYouTube.Views;
using ObserverDesignPatternTaskYouTube.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ObserverDesignPatternTaskYouTube
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SubscriberWindow SubscriberWindow { get; set; }
        public static YoutubeShowAllSubscriberWindow CorrectSignIn { get; set; }
        public static CorrectSignInUserControlViewModel Correct { get; set; }
        public static ObservableCollection<Youtuber> Youtuber { get; set; }
        public static CorrectSignInUserControl CorrectSignInUserControl { get; set; }
        public static Subscriber Subscriber { get; set; }
        public static string SignInYoutuberName { get; set; }
        public static YouTubeWindow YoutuberShow { get; set; }
        public static SignInUseControl SignInUseControl { get; set; }
        public static List<YoutubeShowAllSubscriberWindow> YoutubeShowAlls { get; set; }
        public static List<string> YoutubeTitles { get; set; }

    }
}
