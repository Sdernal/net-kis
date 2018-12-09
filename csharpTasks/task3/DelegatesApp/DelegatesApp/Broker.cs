using System;
using System.Collections.Generic;

namespace DelegatesApp
{    
    // Класс брокера, который торгует акциями
    public abstract class Broker : ISubscriber
    {
        protected double brokerMoney;
        protected Dictionary<string, int> brokerStocks;

        public Broker(double money = 1000.0)
        {
            brokerMoney = money;
            brokerStocks = new Dictionary<string, int>();
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public abstract void Notified(object sender, MarketEventArgs args);
    }

    public sealed class Bernoulli : Broker {
        public override void Notified(object sender, MarketEventArgs args)
        {
            Market market = sender as Market;
            int stocks = 0;
            if (brokerStocks.ContainsKey(args.ShareName)) {
                stocks = brokerStocks[args.ShareName];
            }

            Random rnd = new Random();
            if (rnd.Next() % 2 == 0) {
                market.Buy(args.ShareName, ref stocks, ref brokerMoney);
            }
            else {
                market.Sell(args.ShareName, ref stocks, ref brokerMoney);
            }
            brokerStocks[args.ShareName] = stocks;
        }
    }

    public sealed class Player : Broker {
        private Dictionary<string, (double, double)> stocksThresholds;

        public Player(Market market) : base() {
            brokerStocks = new Dictionary<string, int>();
            stocksThresholds = new Dictionary<string, (double, double)>();
            foreach (string key in market.Stocks.Keys) {
                brokerStocks[key] = 0;
                stocksThresholds[key] = (market.Stocks[key] - 1, market.Stocks[key] + 4);
            }
        }

        public override void Notified(object sender, MarketEventArgs args) {
            Market market = sender as Market;

            int stocks = brokerStocks[args.ShareName];
            if (args.ExchangeRate < stocksThresholds[args.ShareName].Item1) {
                market.Buy(args.ShareName, ref stocks, ref brokerMoney);
            }
            else if (args.ExchangeRate > stocksThresholds[args.ShareName].Item2) {
                market.Sell(args.ShareName, ref stocks, ref brokerMoney);
            }
            brokerStocks[args.ShareName] = stocks;
        }
    }
}
