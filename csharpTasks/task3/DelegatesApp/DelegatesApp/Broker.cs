using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{    
    // Класс брокера, который торгует акциями
    public class Broker : ISubscriber
    {
        // устанавливаем деньги брокера        
        // Как хранить купленные акции - решайте сами
        public Broker(int money = 1000)
        {
            brokerMoney = money;
            stocks = new Dictionary<string, int>();
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public void Notified(object sender, MarketEventArgs args)
        {
            var market = sender as Market;
            var differenсу = args.NewPrice - args.OldPrice;
            var count = 0;
            if (stocks.Keys.Contains(args.Name))
            {
                count = stocks[args.Name];
            }
            if (differenсу > 0 && stocks.ContainsKey(args.Name))
            {
                market.Sell(args.Name, ref count, ref brokerMoney);
            } else if (differenсу < 0 && brokerMoney > args.NewPrice) {
                market.Buy(args.Name, ref count, ref brokerMoney);
            }
            stocks[args.Name] = count;
        }

        private int brokerMoney;
        private IDictionary<string, int> stocks;
    }
}
