using ObserverDesignPatternTaskYouTube.Commands;
using ObserverDesignPatternTaskYouTube.Models;
using ObserverDesignPatternTaskYouTube.Views;
using ObserverDesignPatternTaskYouTube.Views.UserControls;
using System;
using System.Collections.Generic;
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
        public string YoutuberName { get; set; }

        private string selectedItemListBox;

        public string SelectedItemListBox
        {
            get { return selectedItemListBox; }
            set { selectedItemListBox = value; OnPropertyChanged(); }
        }


        private string b;

        public string A
        {
            get { return b; }
            set { b = value; OnPropertyChanged(); }
        }

        private List<Youtuber> youtuber;

        public List<Youtuber> ItemSource
        {
            get { return youtuber; }
            set { youtuber = value; OnPropertyChanged(); }
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
        static bool notSubs = false;
        static int indexer = 0;
        static bool checkboxContent = false;
        static List<YoutubeShowAllSubscriberWindow> youtubeShowAlls = new List<YoutubeShowAllSubscriberWindow>();
        static List<string> youtubeTitles = new List<string>();

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
                    //youtubeTitles.Add(A);
                    //CheckBox checkBox = new CheckBox();
                    //correctSignInUser.Content = "sa";
                    //correctSignInUser.Margin = new Thickness(0, 0, 0, 10);
                    //App.SubscriberWindow.MyStackPanel.Children.Add(correctSignInUser);
                }
            }
            ItemSource = App.Youtuber;
            checkboxContent = true;
            var youtube = new Subject();
            Checked = new RelayCommand((b) =>
            {
                for (int i = 0; i < youtubeShowAlls.Count; i++)
                {
                    if (youtubeShowAlls[i].Title == SelectedItemListBox)
                    {
                        //TxtBlockContent = App.Subscriber.Name;
                        youtubeShowAlls[i].MyTxtBlock.Text += $"{App.Subscriber.Name}\n";
                        MessageBox.Show("Abone oldunuz");
                        break;
                    }
                }

                //for (int i = 0; i < App.YoutubeTitles.Count; i++)
                //{
                //    if (App.YoutubeTitles[i] == YoutuberName)
                //    {
                //        App.CorrectSignIn = App.YoutubeShowAlls[i];
                //        break;
                //    }
                //    else
                //    {
                //        YoutubeShowAllSubscriberWindow youtubeShowAllSubscriberWindow = new YoutubeShowAllSubscriberWindow();
                //        //App.CorrectSignIn = youtubeShowAllSubscriberWindow;
                //        App.YoutubeShowAlls.Add(youtubeShowAllSubscriberWindow);
                //    }
                //}
                //a = !a;

                //TxtBlockContent += $"{App.Subscriber.Name}\n";
                //youtube.Attach()

            });

            AddNewPost = new RelayCommand((a) =>
            {
                youtube.SomeBusinessLogic();
            });

            ShowAllSubscriber = new RelayCommand((b) =>
            {
                if (youtubeShowAlls.Count == 0)
                {
                    MessageBox.Show("Abuneciniz yoxdur!!!");
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

                                    string a = youtubeShowAlls[i].MyTxtBlock.Text;
                                    //youtubeShowAlls[i] = new YoutubeShowAllSubscriberWindow();
                                    //youtubeShowAlls[i].Title = App.SignInYoutuberName;
                                    //youtubeShowAlls[i].MyTxtBlock.Text = a;
                                    //MessageBox.Show($"{youtubeShowAlls[i].MyTxtBlock.Text}");
                                    //youtubeShowAlls[i].Show();
                                    //TxtBlockContent = a;
                                    subscriberUserControl.MyTxtBlock.Text = a;
                                    notSubs = true;
                                    App.YoutuberShow.YoutubeShowAllSubscriberWindow.Children.Clear();
                                    App.YoutuberShow.YoutubeShowAllSubscriberWindow.Children.Add(subscriberUserControl);
                                    //MessageBox.Show($"{subscriberUserControl.MyTxtBlock.Text}");

                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Abuneciniz yoxdur!!!");
                                }
                            }

                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            });
        }
    }
}
