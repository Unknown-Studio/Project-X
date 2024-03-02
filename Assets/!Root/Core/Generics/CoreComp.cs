using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Generics
{
	public class CoreComp<T> where T : CoreComponent
	{
		private Core _core;
		private T _component;

		public T Comp => _component ??= _core.GetCoreComponent<T>();

		public CoreComp(Core core)
		{
			if(core == null) Debug.LogWarning($"Core is null for component {typeof(T)}");
			_core = core;
		}
	}
}