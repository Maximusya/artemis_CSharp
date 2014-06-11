namespace Artemis
{
	using Artemis.Interface;

	public sealed partial class Entity
	{
		/// <summary>
		/// Gets the Component of the type specified.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>the Component or null if there is none of the type specified</returns>
		public T Get<T>() where T : IComponent
		{
			return this.GetComponent<T>();
		}

		/// <summary>
		/// Adds the Component to the entity
		/// </summary>
		/// <param name="component"></param>
		public void Add(IComponent component)
		{
			this.AddComponent(component);
		}

		/// <summary>
		/// Adds the Component to the entity
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="component"></param>
		public void Add<T>(T component) where T : IComponent
		{
			this.AddComponent<T>(component);
		}

		/// <summary>
		/// Adds the pooled component to the entity
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>The component added</returns>
		public T Add<T>() where T : ComponentPoolable
		{
			return this.AddComponentFromPool<T>();
		}

		/// <summary>
		/// Adds the initialized pooled component to the entity
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="init"></param>
		public void Add<T>(global::System.Action<T> init) where T : ComponentPoolable
		{
			this.AddComponentFromPool<T>(init);
		}

		/// <summary>
		/// Returns whether the entity has a Component of the type specified.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public bool Has<T>() where T : IComponent
		{
			return this.HasComponent<T>();
		}

		/// <summary>
		/// Removes Component of the type specified from the entity
		/// </summary>
		/// <typeparam name="T">Component type</typeparam>
		public void Remove<T>() where T : IComponent
		{
			this.RemoveComponent<T>();
		}
	}
}
