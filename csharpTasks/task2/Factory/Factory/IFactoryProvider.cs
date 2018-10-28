using System;

namespace Factory
{
    public interface IFactoryProvider<out T> where T : IMovable
    {
        T CreateObject();
    }
}