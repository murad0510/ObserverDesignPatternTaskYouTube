using ObserverDesignPatternTaskYouTube.Commands;
using ObserverDesignPatternTaskYouTube.Models;
using ObserverDesignPatternTaskYouTube.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ObserverDesignPatternTaskYouTube.ViewModel
{
    public class CorrectSignInUserControlViewModel : BaseViewModel
    {
        public RelayCommand Checked { get; set; }
        public RelayCommand ShowAllSubscriber { get; set; }
        public RelayCommand AddNewPost { get; set; }
        public Subscriber Subscriber { get; set; }
        public string YoutuberName { get; set; }

        private string b;

        public string A
        {
            get { return b; }
            set { b = value; OnPropertyChanged(); }
        }


        private string txtBlockContent;

        public string TxtBlockContent
        {
            get { return txtBlockContent; }
            set { txtBlockContent = value; OnPropertyChanged(); }
        }


        private static List<IObserver> observers = new List<IObserver>();
        public class Subject : ISubject
        {
            public void Notify()
            {
                foreach (var item in observers)
                {
                    item.Update(this);
                }
            }

            public void Attach(ViewModel.IObserver observer)
            {
                observers.Add(observer);
            }

            public void Detach(ViewModel.IObserver observer)
            {
                observers.Remove(observer);
            }
            public void SomeBusinessLogic()
            {
                this.Notify();
            }
        }

        static bool a = true;
        static int indexer = 0;
        //static List<YoutubeShowAllSubscriberWindow> youtubeShowAlls = new List<YoutubeShowAllSubscriberWindow>();
        //static List<string> youtubeTitles = new List<string>();
        public CorrectSignInUserControlViewModel()
        {
            if (App.Youtuber.Count > indexer)
            {
                A = App.Youtuber[indexer].Name;
                indexer += 1;
            }
            var youtube = new Subject();
            Checked = new RelayCommand((b) =>
            {
                //for (int i = 0; i < youtubeTitles.Count; i++)
                //{
                //    if (youtubeTitles[i] == YoutuberName)
                //    {
                //        App.CorrectSignIn = youtubeShowAlls[i];
                //        break;
                //    }
                //    else
                //    {
                        YoutubeShowAllSubscriberWindow youtubeShowAllSubscriberWindow = new YoutubeShowAllSubscriberWindow();
                        App.CorrectSignIn = youtubeShowAllSubscriberWindow;
                //        youtubeShowAlls.Add(youtubeShowAllSubscriberWindow);
                //    }
                //}
                //    a = !a;
                //}
                TxtBlockContent += $"{App.Subscriber.Name}\n";
                //youtube.Attach()
            });

            AddNewPost = new RelayCommand((a) =>
            {
                youtube.SomeBusinessLogic();
            });

            ShowAllSubscriber = new RelayCommand((b) =>
            {
                //if (a)
                //{
                //    YoutubeShowAllSubscriberWindow youtubeShowAllSubscriberWindow = new YoutubeShowAllSubscriberWindow();
                //    a = !a;
                //}
                try
                {
                    App.CorrectSignIn.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Abuneciniz yoxdur!!!");
                }
            });
        }
    }
}
