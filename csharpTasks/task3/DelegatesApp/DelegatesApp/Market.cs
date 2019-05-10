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
            throw new NotImplementedException();
        }

        // Запускает ход торгов (устанавливает цену акциям) и уведомляет подписчиков
        public void Trade()
        {
            // При реализации можно взять рандомную акцию, выставить у неё цену (тоже рандомно в некоторых пределах)
            // и проинформировать подписчиков
            throw new NotImplementedException();
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
            // Биржа сама должна из одного места вычесть, в другое прибавить
        }


        public void Sell(string shareName, ref int count, ref int account)
        {
            // Продажа 
        }
    }
}
