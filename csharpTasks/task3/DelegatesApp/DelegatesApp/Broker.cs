using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{
    // Класс брокера, который торгует акциями
    public class Broker : ISubscriber
    {
        private int _brokerMoney;
        private Dictionary<string, int> _shares;

        public Broker(int money = 1000)
        {
            _brokerMoney = money;
            _shares = new Dictionary<string, int>();
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public void Notified(object sender, MarketEventArgs args)
        {
            if (!(sender is Market market))
            {
                Console.WriteLine("It's a spam!");
                return;
            }

            if (args.NewPrice < 330)
            {
                var amount = _brokerMoney / args.NewPrice;
                int count;
                try
                {
                    count = _shares[args.Name];
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("It's empty!");
                    return;
                }
                catch (KeyNotFoundException)
                {
                    count = 0;
                }

                market.Buy(args.Name, amount, ref count, ref _brokerMoney);
                _shares[args.Name] = count;
            }
            else if (args.NewPrice > 670)
            {
                int count;
                try
                {
                    count = _shares[args.Name];
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("It's empty!");
                    return;
                }
                catch (KeyNotFoundException)
                {
                    return;
                }

                if (count == 0) return;
                market.Sell(args.Name, count, ref count, ref _brokerMoney);
                _shares[args.Name] = count;
            }
        }

        public override string ToString()
        {
            var res = $"Broker\n Money: {_brokerMoney}\n Shares:\n";

            var enumerator = _shares.GetEnumerator();
            enumerator.MoveNext();

            for (var i = 0; i < _shares.Count; i++)
            {
                res += $"  {enumerator.Current.Key}: " +
                       $"{enumerator.Current.Value}\n";
                enumerator.MoveNext();
            }

            enumerator.Dispose();
            return res;
        }
    }
}
