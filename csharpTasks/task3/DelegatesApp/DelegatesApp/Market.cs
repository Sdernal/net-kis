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
        public string NameOfShare;
        public int UpdatedPrice;
        public int OldPrice;

        public MarketEventArgs(string name, int new_price, int old_price)
        {
            NameOfShare = name;
            UpdatedPrice = new_price;
            OldPrice = old_price;
        }
        /*Здесь можно добавить что угодно, цену, название компании и т.п.*/
    }

    // Биржа, торгующая акциями
    public class Market
    {
        public delegate void MarketDelegate(object sender, MarketEventArgs args);
        public event MarketDelegate Notify;

        public Dictionary<string, int> Shares { get; }
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
            Random rnd = new Random();
            string share = Shares.Keys.ElementAt(rnd.Next(0, Shares.Keys.Count));
            Notify?.Invoke(this, new MarketEventArgs(share, rnd.Next(100, 1000), rnd.Next(100, 1000)));
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
            account -= Shares[shareName];
            count++;
        }


        public void Sell(string shareName, ref int count, ref int account)
        {
            // Продажа 
            count -= 1;
            account += Shares[shareName];
        }
    }
}
