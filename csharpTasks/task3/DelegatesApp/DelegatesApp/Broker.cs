using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{    
    // Класс брокера, который торгует акциями
    public class Broker : ISubscriber
    {
        private int brokerMoney;
        private Dictionary<string, int> brokerShares;
        // устанавливаем деньги брокера        
        // Как хранить купленные акции - решайте сами
        public Broker(int money = 1000)
        {
            brokerMoney = money;
            brokerShares = new Dictionary<string, int>();
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public void Notified(Market sender, MarketEventArgs args)
        {
            int count;
            brokerShares.TryGetValue(args.ShareName, out count);
            if (brokerMoney > 100)
            {
                sender.Buy(args.ShareName, ref count, ref brokerMoney);
            }
            else
            {
                sender.Sell(args.ShareName, ref count, ref brokerMoney);
            }
            brokerShares[args.ShareName] = count;
        }
    }
}
