using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{
    // Интерфейс подписчика на изменения цен в акциях
    public interface ISubscriber
    {
        void Notified(Market sender, MarketEventArgs args);
    }

    public class MarketEventArgs
    {
        public string ShareName { get; }
        public int SharePrice { get; }

        public MarketEventArgs(string name, int price)
        {
            ShareName = name;
            SharePrice = price;
        }
    }

    // Биржа, торгующая акциями
    public class Market
    {
        public delegate void MarketDelegate(Market sender, MarketEventArgs args);
        public event MarketDelegate Notify;

        public Dictionary<string, int> Shares { get; }
        private List<ISubscriber> Subscribers;
        // Устанавливаем цены акций, хз как правильно они называются
        // В параметр передаем список имен акций
        public Market(string[] shares)
        {
            Shares = new Dictionary<string, int>();
            Subscribers = new List<ISubscriber>();
            Random rnd = new Random();
            foreach (var share in shares)
            {
                Shares.Add(share, rnd.Next(100, 1000));
            }
        }
        // Добавляет подписчика
        public void AddSubscriber(ISubscriber sub)
        {
            Notify += sub.Notified;
        }

        // Запускает ход торгов (устанавливает цену акциям) и уведомляет подписчиков
        public void Trade()
        {
            Random rnd = new Random();
            string ShareName = "";
            int index = rnd.Next(Shares.Count);

            foreach(string key in Shares.Keys)
            {
                if (index > 0)
                {
                    ShareName = key;
                    break;
                }
                index--;
            }

            Shares[ShareName] = rnd.Next(100, 1000);

            MarketEventArgs newArgs = new MarketEventArgs(ShareName, Shares[ShareName]);
            Notify(this, newArgs);
        }
        
        /// <summary>
        /// Покупка акций
        /// </summary>
        /// <param name="shareName">Имя акции</param>
        /// <param name="count">Ссылка на акции брокера</param>
        /// <param name="account">Ссылка на счет брокера</param>
        public void Buy(string shareName, ref int count, ref int account)
        {
            if (account >= Shares[shareName])
            {
                account -= Shares[shareName];
                count++;
            }
        }


        public void Sell(string shareName, ref int count, ref int account)
        {
            if (count > 0)
            {
                count--;
                account += Shares[shareName];
            }
        }
    }
}
