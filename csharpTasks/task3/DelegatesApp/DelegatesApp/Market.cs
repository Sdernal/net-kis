using System;
using System.Collections.Generic;
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
        /*Здесь можно добавить что угодно, цену, название компании и т.п.*/
        public MarketEventArgs(string name, int newPrice)
        {
            Name = name;
            NewPrice = newPrice;
        }

        public string Name { get; set; }
        public int NewPrice { get; set; }
    }

    // Биржа, торгующая акциями
    public class Market
    {
        public delegate void MarketDelegate(object sender, MarketEventArgs args);

        public event MarketDelegate Notify;
        
        public Dictionary<string, int> Shares { get; }
        private Random random;

        // Устанавливаем цены акций, хз как правильно они называются
        // В параметр передаем список имен акций
        public Market(string[] shares)
        {
            Shares = new Dictionary<string, int>();
            random = new Random();
            foreach (var share in shares)
            {
                Shares.Add(share, random.Next(100, 1000));
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
            var enumerator = Shares.GetEnumerator();
            var num = random.Next(Shares.Count);
            for (var i = 0; i < num; i++)
            {
                enumerator.MoveNext();
            }

            Shares[enumerator.Current.Key] = random.Next(100, 1000);
            Notify?.Invoke(this, new MarketEventArgs(enumerator.Current.Key,
                enumerator.Current.Value));
            enumerator.Dispose();
        }

        /// <summary>
        /// Покупка акций
        /// </summary>
        /// <param name="shareName">Имя акции</param>
        /// <param name="count">Ссылка на акции брокера</param>
        /// <param name="account">Ссылка на счет брокера</param>
        public void Buy(string shareName, ref int count, ref int account)
        {
            // Покупка акций 
            // Биржа сама должна из одного мметса вычесть, в другое прибавить
        }


        public void Sell(string shareName, ref int count, ref int account)
        {
            // Продажа 
        }
    }
}