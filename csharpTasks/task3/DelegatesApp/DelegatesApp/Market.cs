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
        public int old_price;
        public int current_priсe;
        public string share;

        public MarketEventArgs(int old_priсe_, int new_priсe_, string share_) {
            old_priсe = old_priсe_;
            current_priсe = new_priсe_;
            share = share_;
        }
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
            string random_share = Shares.Keys.ElementAt(rnd.Next(0, Shares.Keys.Count));
            int old_share_priсe = Shares[random_share];
            Shares[random_share] = rnd.Next(500, 1501);
            Notify?.Invoke(this, new MarketEventArgs(old_share_priсe, Shares[random_share], random_share));
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
            count--;
            account += Shares[shareName];
        }
    }
}
