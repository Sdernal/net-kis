namespace Factory
{
    interface IFactoryProvider<out T> where T : IMovable
    {
        T CreateObject();
    }
}