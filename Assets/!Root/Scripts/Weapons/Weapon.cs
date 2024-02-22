using System;
using Suhdo.CharacterCore;
using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.Weapons
{
	public class Weapon : MonoBehaviour
	{
		[field:SerializeField] public WeaponDataSO Data{get; private set; }
		[SerializeField] private float attackCounterResetCoolDown;
		
		public event Action OnExit;
		public event Action OnEnter;

		public int CurrentAttackCounter
		{
			get => _currentAttackCounter;
			private set => _currentAttackCounter = value >= Data.NumberOfAttack ? 0 : value;
		}
		
		public Core Core { get; private set; }
		public AnimationEventHandler EventHandler { get; private set; }
		public GameObject BaseGameObject { get; private set; }
		public GameObject WeaponSpriteGameObject { get; private set; }
		
		private Animator _anim;
		private int _currentAttackCounter;

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