using ObserverDesignPatternTaskYouTube.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPatternTaskYouTube.Models
{
    public class Subscriber:IObserver
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public void Update(ISubject subject)
        {
            
        }
    }
}
