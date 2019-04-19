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
        public void Notified(object sender, MarketEventArgs args)
        {
            var market = sender as Market;
          
            if (args.NewPrice > args.OldPrice && brokerShares.ContainsKey(args.Name))
            {
                int count = brokerShares[args.Name] / 2;
                market.Sell(args.Name, ref count, ref brokerMoney);
                brokerShares[args.Name] = count;
            }
            else if (args.NewPrice < args.OldPrice && brokerMoney > args.NewPrice)
            {
                int count =brokerMoney / (2 * args.NewPrice);
                market.Buy(args.Name, ref count, ref brokerMoney);
                brokerShares[args.Name] = count;
            }


            
            
        }
    }

    public class AnotherBroker : ISubscriber
    {
        private int brokerMoney;
        int brokerShares;
        // устанавливаем деньги брокера        
        // Как хранить купленные акции - решайте сами
        public AnotherBroker(int money = 1000)
        {
            brokerMoney = money;
            brokerShares = 0;
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public void Notified(object sender, MarketEventArgs args)
        {
            var market = sender as Market;
            if (args.Name == "Google")
            {
                if (args.NewPrice > args.OldPrice )
                {
                    int count = brokerShares / 2;
                    market.Sell(args.Name, ref count, ref brokerMoney);
                    brokerShares = count;
                }
                else if (args.NewPrice < args.OldPrice && brokerMoney > args.NewPrice)
                {
                    int count = brokerMoney / (2 * args.NewPrice);
                    market.Buy(args.Name, ref count, ref brokerMoney);
                    brokerShares = count;
                }

            }
            




        }
    }
}
