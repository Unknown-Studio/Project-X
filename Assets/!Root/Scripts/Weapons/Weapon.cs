using System;
using Suhdo.CharacterCore;
using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.Weapons
{
	public class Weapon : MonoBehaviour
	{
		[SerializeField] private float attackCounterResetCoolDown;
		
		public WeaponDataSO Data{get; private set; }
		
		public event Action OnExit;
		public event Action OnEnter;
		public event Action<bool> OnCurrentInputChange; 

		public int CurrentAttackCounter
		{
			get => _currentAttackCounter;
			private set => _currentAttackCounter = value >= Data.NumberOfAttack ? 0 : value;
		}

		public bool CurrentInput
		{
			get => _currentInput;
			set
			{
				if (_currentInput != value)
				{
					_currentInput = value;
					OnCurrentInputChange?.Invoke(_currentInput);
				}
			}
		}
		
		public Core Core { get; private set; }
		public AnimationEventHandler EventHandler { get; private set; }
		public GameObject BaseGameObject { get; private set; }
		public GameObject WeaponSpriteGameObject { get; private set; }
		
		private int _currentAttackCounter;
		private bool _currentInput;
		
		private Animator _anim;
		private Timer _attackCounterResetTimer;

		private void Awake()
		{
			BaseGameObject = transform.Find("Base").gameObject;
			WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;
			_anim = BaseGameObject.GetComponent<Animator>();
			EventHandler = BaseGameObject.GetComponent<AnimationEventHandler>();
			_attackCounterResetTimer = new Timer(attackCounterResetCoolDown);
		}

		private void OnEnable()
		{
			EventHandler.OnFinish += OnFinish;
			_attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
		}

		private void OnDisable()
		{
			EventHandler.OnFinish -= OnFinish;
			_attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
		}

		public void Enter()
		{
			_attackCounterResetTimer.StopTimer();
			_anim.SetBool("active", true);
			_anim.SetInteger("counter", CurrentAttackCounter);

			OnEnter?.Invoke();
		}
		
		public void SetCore(Core core)
		{
			Core = core;
		}

		public void SetData(WeaponDataSO data)
		{
			Data = data;
		}

		private void Update()
		{
			_attackCounterResetTimer.Tick();
		}

		private void OnFinish()
		{
			CurrentAttackCounter++;
			_anim.SetBool("active", false);
			OnExit?.Invoke();
			_attackCounterResetTimer.StartTimer();
		}

		private void ResetAttackCounter() => CurrentAttackCounter = 0;
	}
}