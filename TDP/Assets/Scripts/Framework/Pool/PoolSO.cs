using System.Collections.Generic;
using UnityEngine;

using Game.Framework.Factory;

namespace Game.Framework.Pool
{
    /// <summary>
    /// A generic pool that generates object of type T on-demend via a factory.
    /// </summary>
    /// <typeparam name="T">The type of object in the pool.</typeparam>
    public abstract class PoolSO<T> : ScriptableObject, IPool<T>
    {
        protected readonly Stack<T> Available = new Stack<T>();
        /// <summary>
        /// The factory that will create type of <typeparam name="T"> on demend.
        /// </summary>
        public abstract IFactory<T> Factory { get; set; }
        protected bool PreWarmed { get; set; }

        protected virtual T Create() => Factory.Create();

        /// <summary>
        /// Pre-generate batch of type of <typeparam name="T"> to the pool.
        /// </summary>
        /// <param name="num">The number to generate.</param>
		/// <remarks>NOTE: This method should be called only once for the lifetime of the pool.</remarks>
        public virtual void PreWarm(int num)
        {
            if (PreWarmed)
            {
                Debug.LogWarning($"The pool of type {typeof(T)} has been prewarmed!");
                return;
            }

            for (int i = 0; i < num; i++)
            {
                Available.Push(Create());
            }

            PreWarmed = true;
        }

        /// <summary>
        /// Request type <typeparam name="T"> from the pool.
        /// </summary>
        /// <returns>The requested <typeparam name="T"></returns>
        public virtual T Request() => (Available.Count > 0) ? Available.Pop() : Create();

        /// <summary>
        /// batch request a collection of <typeparam name="T"> from the pool.
        /// </summary>
        /// <returns>The requested collection of <typeparam name="T"></returns>
        public virtual IEnumerable<T> Request(int num)
        {
            List<T> collection = new List<T>();
            for (int i = 0; i < num; i++)
            {
                collection.Add(Request());
            }

            return collection;
        }

        /// <summary>
        /// Returns a type of <typeparam name="T"> to the pool.
        /// </summary>
        /// <param name="member"></param>
        public virtual void Return(T member)
        {
            Available.Push(member);
        }

        /// <summary>
        /// Returns a collection of <typeparam name="T"> to the pool.
        /// </summary>
        /// <param name="member">The collection of <typeparam name="T"></param>
        public virtual void Return(IEnumerable<T> members)
        {
            foreach (T member in members)
            {
                Return(member);
            }
        }

        public virtual void OnDisable()
        {
            Available.Clear();
            PreWarmed = false;
        }
    }
}
