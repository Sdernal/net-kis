using System;

namespace DelegatesApp
{
    public class RandomPearson : ISubscriber
    {
        private int _money;
        private int _bitcoins;

        public RandomPearson(int money = 500)
        {
            _money = money;
            _bitcoins = 0;
        }

        public void Notified(object sender, MarketEventArgs args)
        {
            if (!(sender is Market market))
            {
                Console.WriteLine("It's a spam!");
                return;
            }

            if (args.Name != "Bitcoin")
            {
                return;
            }

            if (args.NewPrice > args.OldPrice)
            {
                try
                {
                    market.Buy(args.Name, 1, ref _bitcoins, ref _money);
                }
                catch (ArgumentException)
                {
                }
            }
            else if (args.NewPrice < args.OldPrice)
            {
                market.Sell(args.Name, _bitcoins, ref _bitcoins, ref _money);
            }
        }

        public override string ToString()
        {
            return $"Someone who can't into trading\nMoney: {_money}\n" +
                   $"Bitcoins: {_bitcoins}";
        }
    }
}
