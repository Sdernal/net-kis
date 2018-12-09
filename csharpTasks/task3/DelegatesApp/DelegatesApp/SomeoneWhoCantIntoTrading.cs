using System;

namespace DelegatesApp
{
    public class SomeoneWhoCantIntoTrading : ISubscriber
    {
        private int _money;
        private int _bitcoins;

        public SomeoneWhoCantIntoTrading(int money = 500)
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
                Console.WriteLine("Not interesting.");
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
                    Console.WriteLine("It's too expensive!");
                }
            }
            else if (args.NewPrice < args.OldPrice)
            {
                market.Sell(args.Name, _bitcoins, ref _bitcoins, ref _money);
            }
        }
    }
}
