using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp
{
    public interface IMyService
    {
        string GetText();
    }
    public class MyService1 : IMyService
    {
        public string GetText() => "MyService1";
    }
    public class MyService2 : IMyService
    {
        public string GetText() => "MyService2";
    }
}
