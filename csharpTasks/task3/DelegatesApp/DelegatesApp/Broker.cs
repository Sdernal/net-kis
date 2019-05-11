using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{    
    // Класс брокера, который торгует акциями
    public abstract class Broker : ISubscriber
    {
        protected int brokerMoney;

        protected Dictionary<string, int> shares;
        // устанавливаем деньги брокера        
        // Как хранить купленные акции - решайте сами
        public Broker(int money = 1000)
        {
            brokerMoney = money;
            shares = new Dictionary<string, int>();
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public abstract void Notified(object sender, MarketEventArgs args);
//        {
//            throw new NotImplementedException();
//        }
    }

    public class BrokerSell : Broker
    {
        public BrokerSell() {}

        public override void Notified(object sender, MarketEventArgs args)
        {
            var market = sender as Market;
            int count = shares[args.Name];
            market?.Sell(args.Name, ref count,ref brokerMoney);
            shares[args.Name] = count;
        }
    }

    public class BrokerBuy : Broker
    {
        public BrokerBuy() {}
        public override void Notified(object sender, MarketEventArgs args)
        {
            var market = sender as Market;
            int count = shares[args.Name];
            market?.Buy(args.Name, ref count,ref brokerMoney);
            shares[args.Name] = count;
        }
    }
}
