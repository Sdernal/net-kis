using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Providers
{
    /// <summary>
    /// Интерфейс для провайдеров, говорит что класс реализующий этот интерфейс должен реализовать функцию CreateObject
    /// </summary>
    /// <typeparam name="TVechile"> параметр говорящий что может придти параметр являющися наследником этого интерфейса</typeparam>
    public interface IProvider<out TVechile>
    {
        TVechile CreateObject();
    }
}
