using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{
    /// <summary>
    /// Брокер, который может только покупать
    /// </summary>
    class BuуerBroker : ISubscriber
    {
        private int account;
        private Dictionary<string, int> shares;
        public BuуerBroker(int capital = 5000)
        {
            account = capital;
            shares = new Dictionary<string, int>();
        }

        public void Notified(object sender, MarketEventArgs args)
        {
            Market market = sender as Market;
            int price = args.UpdatedPrice;
            string share = args.NameOfShare;
            int count = shares.ContainsKey(share) ? shares[share] : 0;
            if(price <= account)
            {
                market.Buy(share, ref count, ref account);
            }
            shares[share] = count;
        }
    }
}
