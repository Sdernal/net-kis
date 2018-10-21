﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory {
    interface IFactoryProvider<out T> where T : Transport {
        T CreateObject();
    }
}
