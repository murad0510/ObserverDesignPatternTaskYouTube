using ObserverDesignPatternTaskYouTube.Commands;
using ObserverDesignPatternTaskYouTube.Models;
using ObserverDesignPatternTaskYouTube.Views;
using ObserverDesignPatternTaskYouTube.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ObserverDesignPatternTaskYouTube.ViewModel
{
    public class CorrectSignInUserControlViewModel : BaseViewModel
    {
        public RelayCommand Checked { get; set; }
        public RelayCommand ShowAllSubscriber { get; set; }
        public RelayCommand AddNewPost { get; set; }
        public Subscriber Subscriber { get; set; }
        public RelayCommand BackButton { get; set; }
        public RelayCommand BackButtonYoutube { get; set; }
        public RelayCommand UnChecked { get; set; }
        public RelayCommand SharedChannelButtonClicked { get; set; }
        public RelayCommand ShareVideo { get; set; }
        public RelayCommand BackButtonUserMainWindow { get; set; }
        public RelayCommand BackButtonYoutuberMainWindow { get; set; }
        public string YoutuberName { get; set; }

        private string selectedItemListBox;

        public string SelectedItemListBox
        {
            get { return selectedItemListBox; }
            set { selectedItemListBox = value; OnPropertyChanged(); }
        }

        private string selectedItemListBoxUnsubscribe;

        public string SelectedItemListBoxUnsubscribe
        {
            get { return selectedItemListBoxUnsubscribe; }
            set { selectedItemListBoxUnsubscribe = value; OnPropertyChanged(); }
        }



        private string b;

        public string A
        {
            get { return b; }
            set { b = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Youtuber> youtuber;

        public ObservableCollection<Youtuber> ItemSource
        {
            get { return youtuber; }
            set { youtuber = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Youtuber> itemSourceUnsubscribe = new ObservableCollection<Youtuber>();

        public ObservableCollection<Youtuber> ItemSourceUnsubscribe
        {
            get { return itemSourceUnsubscribe; }
            set { itemSourceUnsubscribe = value; OnPropertyChanged(); }
        }


        private string txtBlockContent;

        public string TxtBlockContent
        {
            get { return txtBlockContent; }
            set { txtBlockContent = value; OnPropertyChanged(); }
        }

        private string videoTitle;

        public string VideoTitle
        {
            get { return videoTitle; }
            set { videoTitle = value; OnPropertyChanged(); }
        }


        private static List<IObserver> observers = new List<IObserver>();
        public class Subject : ISubject
        {
            public void Notify(string videoTitle)
            {
                foreach (var item in observers)
                {
                    item.Update(videoTitle);
                }
            }

            public void Attach(ViewModel.IObserver observer)
            {
                if (!observers.Contains(observer))
                {
                    observers.Add(observer);
                }
            }

            public void Detach(ViewModel.IObserver observer)
            {
                observers.Remove(observer);
            }

            public void SomeBusinessLogic(string videoTitle)
            {
                this.Notify(videoTitle);
            }
        }

        static bool a = true;
        static bool notSubs = false;
        static int indexer = 0;
        static bool checkboxContent = false;
        static List<YoutubeShowAllSubscriberWindow> youtubeShowAlls = new List<YoutubeShowAllSubscriberWindow>();
        static List<Youtuber> youtubers = new List<Youtuber>();
        public CorrectSignInUserControlViewModel()
        {
            if (checkboxContent)
            {
                if (App.Youtuber.Count > indexer)
                {
                    if (a)
                    {
                        A = App.Youtuber[indexer].Name;
                        indexer += 1;
                        a = !a;
                        YoutubeShowAllSubscriberWindow youtubeShowAll = new YoutubeShowAllSubscriberWindow();
                        youtubeShowAll.Title = A;
                        youtubeShowAlls.Add(youtubeShowAll);
                    }
                    else
                    {
                        a = !a;
                    }
                }
            }
            ItemSource = App.Youtuber;
            if (App.Subscriber != null)
            {
                if (App.Subscriber.Youtubers.Count > 0)
                {
                    ItemSourceUnsubscribe = App.Subscriber.Youtubers;
                }
            }

            checkboxContent = true;
            var youtube = new Subject();
            Checked = new RelayCommand((b) =>
            {
                bool a = false;
                for (int i = 0; i < youtubeShowAlls.Count; i++)
                {
                    if (youtubeShowAlls[i].Title == SelectedItemListBox)
                    {
                        for (int k = 0; k < App.Subscriber.Youtubers.Count; k++)
                        {
                            if (App.Subscriber.Youtubers[k].Name == SelectedItemListBox)
                            {
                                a = true;
                            }
                        }
                        if (!a)
                        {
                            youtubeShowAlls[i].MyTxtBlock.Text += $"{App.Subscriber.Name}\n";

                            App.Subscriber.Youtubers.Add(App.Youtuber[i]);
                            youtube.Attach(App.Subscriber);

                            ItemSourceUnsubscribe = App.Subscriber.Youtubers;

                            MessageBox.Show($"You have subscribed to the channel called {SelectedItemListBox}");
                        }
                        else
                        {
                            MessageBox.Show($"You are subscribed to {SelectedItemListBox} channel!!!");
                        }
                        break;
                    }
                }

            });

            AddNewPost = new RelayCommand((a) =>
            {
                YoutubeAddNewPostButtinUserControl youtubeAddNewPostButtin = new YoutubeAddNewPostButtinUserControl();
                App.YoutuberShow.YoutubeShowAllSubscriberWindow.Children.Clear();
                App.YoutuberShow.YoutubeShowAllSubscriberWindow.Children.Add(youtubeAddNewPostButtin);
            });

            ShareVideo = new RelayCommand((a) =>
            {
                youtube.SomeBusinessLogic(VideoTitle);
            });

            BackButton = new RelayCommand((a) =>
            {
                App.SubscriberWindow.MyStackPanel.Children.Clear();
                App.SubscriberWindow.MyStackPanel.Children.Add(App.SignInUseControl);
            });

            ShowAllSubscriber = new RelayCommand((b) =>
            {
                if (youtubeShowAlls.Count == 0 || youtubeShowAlls.Count == 2)
                {
                    MessageBox.Show("You have no subscribers!!!");
                }
                else
                {
                    for (int i = 0; i < youtubeShowAlls.Count; i++)
                    {
                        try
                        {
                            if (youtubeShowAlls[i].Title == App.SignInYoutuberName)
                            {
                                if (youtubeShowAlls[i].MyTxtBlock.Text != string.Empty)
                                {
                                    YoutuberShowSubscriberUserControl subscriberUserControl = new YoutuberShowSubscriberUserControl();

                                    string subscribers = youtubeShowAlls[i].MyTxtBlock.Text;

                                    subscriberUserControl.MyTxtBlock.Text = subscribers;
                                    notSubs = true;
                                    App.YoutuberShow.YoutubeShowAllSubscriberWindow.Children.Clear();
                                    App.YoutuberShow.YoutubeShowAllSubscriberWindow.Children.Add(subscriberUserControl);

                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("You have no subscribers!!!");
                                }
                            }

                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            });

            BackButtonYoutube = new RelayCommand((a) =>
            {
                App.YoutuberShow.Close();
                YouTubeWindow youTubeWindow = new YouTubeWindow();
                youTubeWindow.ShowDialog();
                App.YoutuberShow = youTubeWindow;
            });

            UnChecked = new RelayCommand((a) =>
            {
                for (int i = 0; i < App.Subscriber.Youtubers.Count; i++)
                {
                    if (App.Subscriber.Youtubers[i].Name == SelectedItemListBoxUnsubscribe)
                    {
                        MessageBox.Show($"You have unsubscribed from {SelectedItemListBoxUnsubscribe} channel");
                        for (int k = 0; k < youtubeShowAlls.Count; k++)
                        {
                            if (youtubeShowAlls[k].Title == SelectedItemListBoxUnsubscribe)
                            {
                                youtubeShowAlls[k].MyTxtBlock.Text = youtubeShowAlls[k].MyTxtBlock.Text.Replace(App.Subscriber.Name, null);
                                youtubeShowAlls[k].MyTxtBlock.Text = youtubeShowAlls[k].MyTxtBlock.Text.Trim();
                            }
                        }
                        App.Subscriber.Youtubers.Remove(App.Subscriber.Youtubers[i]);
                        youtube.Detach(App.Subscriber);
                        break;
                    }
                }
            });

            SharedChannelButtonClicked = new RelayCommand((a) =>
            {
                YoutubeNotifyUserControl youtubeNotifyUser = new YoutubeNotifyUserControl();
                ShareVideoTitlePIctureYoutuberName shareVideoTitlePIcture = new ShareVideoTitlePIctureYoutuberName();
                App.SubscriberWindow.MyStackPanel.Children.Clear();
                App.SubscriberWindow.MyStackPanel.Children.Add(shareVideoTitlePIcture);
                for (int i = 0; i < App.Subscriber.YoutubeNotifyUser.Count; i++)
                {
                    App.SubscriberWindow.MyStackPanel.Children.Add(App.Subscriber.YoutubeNotifyUser[i]);
                }
            });

            BackButtonUserMainWindow = new RelayCommand((a) =>
            {
                App.SubscriberWindow.MyStackPanel.Children.Clear();
                App.SubscriberWindow.MyStackPanel.Children.Add(App.CorrectSignInUserControl);
            });
        }
    }
}
