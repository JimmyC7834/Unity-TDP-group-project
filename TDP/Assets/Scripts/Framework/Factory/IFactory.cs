namespace Game.Framework.Factory
{
    /// <summary>
    /// Represents a factory
    /// </summary>
    /// <typeparam name="T">The type of object to create</typeparam>
    public interface IFactory<T>
    {
        T Create();
    }
}
