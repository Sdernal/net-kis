using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesApp
{
    // Интерфейс подписчика на изменения цен в акциях
    public interface ISubscriber
    {
        void Notified(object sender, MarketEventArgs args);
    }

    public class MarketEventArgs
    {
        public string Name { get; set; }
        public int OldPrice { get; set; }
        public int NewPrice { get; set; }
    }

    // Биржа, торгующая акциями
    public class Market
    {
        public delegate void MarketDelegate(object sender, MarketEventArgs args);
        public event MarketDelegate Notify;

        public Dictionary<string, int> Shares { get; private set; }
        // Устанавливаем цены акций, хз как правильно они называются
        // В параметр передаем список имен акций
        public Market(string[] shares)
        {
            Shares = new Dictionary<string, int>();
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
            // При реализации можно взять рандомную акцию, выставить у неё цену (тоже рандомно в некоторых пределах)
            // и проинформировать подписчиков
            var rand = new Random();
            var newPrice = rand.Next(100, 1000);
            var key = Shares.Keys.ElementAt(rand.Next(0, Shares.Keys.Count));
            var oldPrice = Shares[key];
            Shares[key] = newPrice;
            Notify?.Invoke(this,
                new MarketEventArgs
                {
                    Name = key,
                    OldPrice = oldPrice,
                    NewPrice = newPrice
                });
        }
        
        /// <summary>
        /// Покупка акций
        /// </summary>
        /// <param name="shareName">Имя акции</param>
        /// <param name="count">Ссылка на акции брокера</param>
        /// <param name="account">Ссылка на счет брокера</param>
        public void Buy(string shareName, ref int count, ref int account)
        {
            account -= Shares[shareName];
            count += 1;
        }


        public void Sell(string shareName, ref int count, ref int account)
        {
            count -= 1;
            account += Shares[shareName];
        }
    }
}
