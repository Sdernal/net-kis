using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{
    public class AppleBroker : ISubscriber
    {
        // устанавливаем деньги брокера        
        // Как хранить купленные акции - решайте сами
        public AppleBroker(int money = 1000)
        {
            brokerMoney = money;
            stocks = new Dictionary<string, int>();
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public void Notified(object sender, MarketEventArgs args)
        {
            if (args.Name != "Apple") return;
            var market = sender as Market;
            var differenсу = args.NewPrice = args.OldPrice;
            var count = stocks[args.Name];
            if (differenсу > 0 && stocks.ContainsKey(args.Name))
            {
                market.Sell(args.Name, ref count, ref brokerMoney);
            }
            else if (differenсу < 0 && brokerMoney > args.NewPrice)
            {
                market.Buy(args.Name, ref count, ref brokerMoney);
            }
            stocks[args.Name] = count;
        }

        private int brokerMoney;
        private IDictionary<string, int> stocks;
    }
}
