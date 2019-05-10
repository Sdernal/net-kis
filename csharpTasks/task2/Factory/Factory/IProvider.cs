


namespace Factory
{
    public interface IProvider <out T> where T : Transport
    {
        T CreateObject();
    }
}
