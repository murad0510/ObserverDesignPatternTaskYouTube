using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ObserverDesignPatternTaskYouTube.ViewModel.CorrectSignInUserControlViewModel;

namespace ObserverDesignPatternTaskYouTube.ViewModel
{
    public interface IObserver
    {
        void Update(string videoTitle);
    }
}
