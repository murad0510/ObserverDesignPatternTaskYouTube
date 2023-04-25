using ObserverDesignPatternTaskYouTube.ViewModel;
using ObserverDesignPatternTaskYouTube.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObserverDesignPatternTaskYouTube.Models
{

    public class Subscriber : BaseViewModel, IObserver
    {
        private string shareVideoTitle;

        public string ShareVideoTitle
        {
            get { return shareVideoTitle; }
            set { shareVideoTitle = value; OnPropertyChanged(); }
        }

        private string shareVideoYoutuberName;

        public string ShareVideoYoutuberName
        {
            get { return shareVideoYoutuberName; }
            set { shareVideoYoutuberName = value; OnPropertyChanged(); }
        }


        public string Name { get; set; }
        public string Password { get; set; }
        public ObservableCollection<Youtuber> Youtubers { get; set; } = new ObservableCollection<Youtuber>();
        public List<YoutubeNotifyUserControl> YoutubeNotifyUser { get; set; } = new List<YoutubeNotifyUserControl>();

        public void Update(string videoTitle)
        {
            YoutubeNotifyUserControl youtubeNotifyUser = new YoutubeNotifyUserControl();
            youtubeNotifyUser.VideoTitleLabel.Content = videoTitle;
            youtubeNotifyUser.YoutuberNameLabel.Content = App.SignInYoutuberName;
            YoutubeNotifyUser.Add(youtubeNotifyUser);
            MessageBox.Show("The video has been successfully sent to all subscribers");
        }
    }
}
