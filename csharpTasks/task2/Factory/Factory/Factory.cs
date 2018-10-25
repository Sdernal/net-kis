using System;

namespace Factory
{
    class Factory
    {
        public Factory()
        {
            throw new NotImplementedException();
        }

        public void AddProvider(IFactoryProvider<IMovable> provider)
        {
            throw new NotImplementedException();
        }

        public T GetProvider<T>() where T : IFactoryProvider<IMovable>
        {
            throw new NotImplementedException();
        }
    }
}