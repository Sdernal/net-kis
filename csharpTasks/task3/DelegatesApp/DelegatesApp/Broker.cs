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
            throw new NotImplementedException();
        }
    }
}
