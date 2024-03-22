using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Suhdo.CharacterCore.StatsSystem
{
	[Serializable]
	public class Stat
	{
		public event Action OnCurrentValueZero;
		
		[field: SerializeField] public float MaxValue { get; private set; }
		private float _currentValue;

		public float CurrentValue
		{
			get => _currentValue;
			private set
			{
				_currentValue = Mathf.Clamp(value, 0f, MaxValue);
				if(_currentValue <= 0f) OnCurrentValueZero?.Invoke();
			}
		}

		public void Init() => _currentValue = MaxValue;

		public void Increase(float amount) => CurrentValue += amount;
		
		public void Decrease(float amount) => CurrentValue -= amount;
	}
}