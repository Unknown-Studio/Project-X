using System;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	[Serializable]
	public class ComponentData
	{
		[SerializeField, HideInInspector] private string name;

		public ComponentData()
		{
			SetComponentName();
		}
		
		public void SetComponentName() => name = GetType().Name;

		public virtual void SetAttackDataNames() {}
		public virtual void InitializeAttackData(int numberOfAttack){}
	}

	[Serializable]
	public class ComponentData<T> : ComponentData where T : AttackData
	{
		[SerializeField] private T[] attackData;
		public T[] AttackData { get => attackData; set => attackData = value; }

		public override void SetAttackDataNames()
		{
			base.SetAttackDataNames();
			
			for (var i = 0; i < AttackData.Length; i++)
			{
				AttackData[i].SetAttackDataName(i + 1);
			}
		}

		public override void InitializeAttackData(int numberOfAttack)
		{
			base.InitializeAttackData(numberOfAttack);

			var oldLength = attackData?.Length ?? 0;
			if (oldLength == numberOfAttack) return;
			
			Array.Resize(ref attackData, numberOfAttack);

			if (oldLength < numberOfAttack)
			{
				for (var i = oldLength; i < numberOfAttack; i++)
				{
					var newObj = Activator.CreateInstance(typeof(T)) as T;
					attackData[i] = newObj;
				}
			}
			
			SetAttackDataNames();
		}
	}
}