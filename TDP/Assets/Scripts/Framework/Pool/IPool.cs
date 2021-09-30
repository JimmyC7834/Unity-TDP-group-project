namespace Game.Framework.Pool
{
    /// <summary>
    /// Represents a collection that pools objects of type T
    /// </summary>
    /// <typeparam name="T">The type of object in the pool</typeparam>
    public interface IPool<T>
    {
        void PreWarm(int num);
        T Request();
        void Return(T member);
    }
}
