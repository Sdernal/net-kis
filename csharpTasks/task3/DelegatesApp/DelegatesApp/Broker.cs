using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{    
    // Класс брокера, который торгует акциями
    public class Broker : ISubscriber
    {
        private double brokerMoney;
        private Dictionary<string, int> brokerStocks;

        public Broker(double money = 1000.0)
        {
            brokerMoney = money;
            brokerStocks = new Dictionary<string, int>();
        }
        
        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public void Notified(object sender, MarketEventArgs args)
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
}
