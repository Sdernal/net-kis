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
            int price_change = args.current_price - args.old_price;
            int count = shares.ContainsKey(args.share) ? shares[args.share] : 0;
            //покупаем акцию, если цена на нее упала
            if (price_change < 0 && brokerMoney >= args.current_price) {
                market.Buy(args.share, ref count, ref brokerMoney);
            }
            //продаем акцию, если она есть в наличии у брокера, и цена на нее возросла
            if (price_change > 0 && shares.ContainsKey(args.Name)) {
                market.Sell(args.share, ref count, ref brokerMoney);
            }
            shares[args.share] = count;
        }
    }
}
