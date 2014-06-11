namespace Artemis
{
	using global::System;
	using Interface;

	public partial class Aspect
	{
		/// <summary>
		/// Returns the Aspect requiring presence of the type specified
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static Aspect Of(Type type)
		{
			return All(type);
		}

		/// <summary>
		/// Returns the Aspect requiring presence of all of the types specified
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public static Aspect Of(params Type[] types)
		{
			return All(types);
		}

		/// <summary>
		/// Returns the Aspect requiring presence of the type specified
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Aspect Of<T>() where T : IComponent
		{
			return All(typeof(T));
		}

		/// <summary>
		/// Returns the Aspect requiring presence of any of the types specified
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public static Aspect AnyOf(params Type[] types)
		{
			return One(types);
		}

		/// <summary>
		/// Returns the Aspect requiring absence of all of the types specified
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public static Aspect Not(params Type[] types)
		{
			return Exclude(types);
		}

		/// <summary>
		/// Adds the requirement of presence of all the types specified
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public Aspect AndAllOf(params Type[] types)
		{
			return this.GetAll(types);
		}

		/// <summary>
		/// Adds the requirement of presence of any of the types specified
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public Aspect AndAnyOf(params Type[] types)
		{
			return this.GetOne(types);
		}

		/// <summary>
		/// Adds the requirement of absence of all of the types specified
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public Aspect AndNot(params Type[] types)
		{
			return this.GetExclude(types);
		}
	}
}