using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{    
    // Класс брокера, который торгует акциями
    public class Broker : ISubscriber
    {
        private int brokerMoney;
        private Dictionary<string, int> shares;
        // устанавливаем деньги брокера        
        // Как хранить купленные акции - решайте сами
        public Broker(int money = 1000)
        {
            brokerMoney = money;
            shares = new Dictionary<string, int>();
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public void Notified(object sender, MarketEventArgs args)
        {
            Market market = sender as Market;
            int dif = args.UpdatedPrice - args.OldPrice;
            // Если разница больше 0, значит можно получить выгоду
            if (dif > 0 && shares.ContainsKey(args.NameOfShare))  
            {
                int count = shares[args.NameOfShare];
                market.Sell(args.NameOfShare, ref count, ref brokerMoney);
                shares[args.NameOfShare] = count;
            }
            else
            {
                if(dif < 0 && brokerMoney > args.UpdatedPrice)
                {
                    int count = shares.ContainsKey(args.NameOfShare) ? shares[args.NameOfShare] : 0;
                    market.Buy(args.NameOfShare, ref count, ref brokerMoney);
                    shares[args.NameOfShare] = count;
                }
            }

        }
    }
}
