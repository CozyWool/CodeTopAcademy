using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Observer
{
    public delegate void NotifyMessage(string message);

    internal class PublisherOnDelegate
    {
        //private List<Subscriber> _subscribers = new();
        public NotifyMessage Subscribers;

        //public void AddSubscriber(Subscriber subscriber) => _subscribers.Add(subscriber);
        //public void RemoveSubscriber(Subscriber subscriber) => _subscribers.Remove(subscriber);
        public void ProductArrvied(string productName)
        {
            Console.WriteLine($"Издатель. Поступил товар {productName}");
            //foreach (Subscriber subscriber in _subscribers)
            //{
            //    subscriber.NotifyMe($"Поступил товар {productName}");
            //}
            if( Subscribers != null )
                Subscribers($"Поступил товар {productName}");
        }
    }
}
