using Factory.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Providers
{
    public interface IProvider<out TVehicle>
    {
        TVehicle CreateObject();
    }
}
