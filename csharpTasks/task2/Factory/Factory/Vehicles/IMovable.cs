using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface IMovable
    {
        void Move();

        string Name { get; set; }

        int NumberOfPassengers { get; set; }
    }
}
