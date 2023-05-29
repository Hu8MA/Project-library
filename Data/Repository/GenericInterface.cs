namespace Labrary2023.Data.Repository
{
    public interface GenericInterface
    {
        public IEnumerable<T> list<T>() where T : class;
        public bool add<T>(T obj) where T : class;
        public bool delete<T>(T obj) where T : class;
        public bool edit<T>(T obj) where T : class;
        public T get<T>(int id) where T : class;

    }
}
