using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesApp
{
    // Интерфейс подписчика на изменения цен в акциях
    public interface ISubscriber
    {
        void Notified(object sender, MarketEventArgs args);
    }

    public class MarketEventArgs
    {
        public readonly string ShareName;
        public readonly double ExchangeRate;

        private MarketEventArgs() { }

        public MarketEventArgs(string _ShareName, double _ExchangeRate) {
            ShareName = _ShareName;
            ExchangeRate = _ExchangeRate;
        }
    }
    
    public class Market
    {
        public delegate void MarketDelegate(object sender, MarketEventArgs args);
        public event MarketDelegate Notify;

        public readonly Dictionary<string, double> Stocks;

        public Market(string[] shares)
        {
            Stocks = new Dictionary<string, double>();

            Random rnd = new Random();
            foreach (var share in shares)
            {
                Stocks.Add(share, rnd.Next(100, 1000) + rnd.NextDouble());
            }
        }

        public void AddSubscriber(ISubscriber sub)
        {
            Notify += sub.Notified;
        }
        
        public void Trade()
        {
            Random rnd = new Random();
            string shareName = Enumerable.ToList(Stocks.Keys)[rnd.Next(Stocks.Count)];
            double delta = rnd.Next(-5, 4) + rnd.NextDouble();
            Stocks[shareName] += delta;

            MarketEventArgs args = new MarketEventArgs(shareName, Stocks[shareName]);
            Notify(this, args);
        }
        
        public void Buy(string shareName, ref int count, ref double account)
        {
            int shareCount = (int)Math.Floor(account / Stocks[shareName]);
            count += shareCount;
            account -= Stocks[shareName] * shareCount;
        }


        public void Sell(string shareName, ref int count, ref double account)
        {
            account += Stocks[shareName] * count;
            count = 0;
        }
    }
}
