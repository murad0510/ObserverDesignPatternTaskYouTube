using ObserverDesignPatternTaskYouTube.ViewModel;
using ObserverDesignPatternTaskYouTube.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ObserverDesignPatternTaskYouTube.Views
{
    /// <summary>
    /// Interaction logic for SubscriberWindow.xaml
    /// </summary>
    public partial class SubscriberWindow : Window
    {
        public SubscriberWindow()
        {
            InitializeComponent();
            SubscriberWindowViewModel subscriberWindowViewModel = new SubscriberWindowViewModel();
            subscriberWindowViewModel.SubscriberWindow = this;
            this.DataContext = subscriberWindowViewModel;
        }
    }
}
