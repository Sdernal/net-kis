using System;
using Xunit;
using DelegatesApp;
using System.Linq;
using Moq;

namespace DelegatesApp.Test
{
    public class MarketTest
    {
        [Fact]
        public void SubscriberTest()
        {
            Market market = new Market(new string[] { "Apple", "Google" });
            var mock = new Mock<ISubscriber>();
            mock.Setup(foo => foo.Notified(market, It.IsAny<MarketEventArgs>()));
            market.AddSubscriber(mock.Object);
            market.Trade();
            mock.Verify(r => r.Notified(market, It.IsAny<MarketEventArgs>()));
        }
    }
}
