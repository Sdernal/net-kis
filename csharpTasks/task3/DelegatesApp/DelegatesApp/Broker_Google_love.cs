using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{    
    // Класс брокера, который покупает только акции Google
    public class Broker_Google_love : ISubscriber
    {
        private int brokerMoney;
        private Dictionary<string, int> shares;
        public Broker(int money = 10000)
        {
            brokerMoney = money;
            shares = new Dictionary<string, int>();
        }
        public void Notified(object sender, MarketEventArgs args)
        {
            Market market = sender as Market;
            int count = shares.ContainsKey(args.share) ? shares[args.share] : 0;
            if (args.share == "Google" && brokerMoney >= args.current_price) {
                market.Buy(args.share, ref count, ref brokerMoney);
            }
            shares[args.share] = count;
        }
    }
}
