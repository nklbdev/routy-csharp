namespace Service
{
    public class IoC
    {
        public T Resolve<T>() where T : class, new()
        {
            return new T();
        }
    }
}