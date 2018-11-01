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
        public readonly string CompanyName;
        public readonly double ExchangeRate;

        private MarketEventArgs() { }

        public MarketEventArgs(string _CompanyName, double _ExcnahgeRate) {
            CompanyName = _CompanyName;
            ExchangeRate = _ExcnahgeRate;
        }
    }

    // Биржа, торгующая акциями
    public class Market
    {
        public delegate void MarketDelegate(object sender, MarketEventArgs args);
        public event MarketDelegate Notify;

        public readonly Dictionary<string, int> Stocks;

        private List<ISubscriber> subscribers;

        public Market(string[] shares)
        {
            Stocks = new Dictionary<string, int>();
            Random rnd = new Random();
            foreach (var share in shares)
            {
                Stocks.Add(share, rnd.Next(100, 1000));
            }
        }

        public void AddSubscriber(ISubscriber sub)
        {
            subscribers.Add(sub);
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
            // Биржа сама должна из одного мметса вычесть, в другое прибавить
        }


        public void Sell(string shareName, ref int count, ref int account)
        {
            // Продажа 
        }
    }
}
