using ObserverDesignPatternTaskYouTube.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPatternTaskYouTube.Models
{
    public class Youtuber : ISubject
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Subscriber> Subscribers { get; set; } = new List<Subscriber>();

        public void Attach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Detach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notify(string videoTitle)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
