using System;
using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.Weapons
{
	public class Weapon : MonoBehaviour
	{
		[SerializeField] private int numberOfAttack;
		[SerializeField] private float attackCounterResetCoolDown;
		
		public event Action OnExit;

		public int CurrentAttackCounter
		{
			get => _currentAttackCounter;
			private set => _currentAttackCounter = value >= numberOfAttack ? 0 : value;
		}
		
		private Animator _anim;
		private GameObject _baseGameObject;
		private AnimationEventHandler _eventHandler;
		private int _currentAttackCounter;

		private Timer _attackCounterResetTimer;

		private void Awake()
		{
			_baseGameObject = transform.Find("Base").gameObject;
			_anim = _baseGameObject.GetComponent<Animator>();
			_eventHandler = _baseGameObject.GetComponent<AnimationEventHandler>();
			_attackCounterResetTimer = new Timer(attackCounterResetCoolDown);
		}

		private void OnEnable()
		{
			_eventHandler.Exit += Exit;
			_attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
		}

		private void OnDisable()
		{
			_eventHandler.Exit -= Exit;
			_attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
		}

		public void Enter()
		{
			print($"{transform.name} enter");
			
			_attackCounterResetTimer.StopTimer();
			_anim.SetBool("active", true);
			_anim.SetInteger("counter", CurrentAttackCounter);
		}

		private void Update()
		{
			_attackCounterResetTimer.Tick();
		}

		private void Exit()
		{
			CurrentAttackCounter++;
			_anim.SetBool("active", false);
			OnExit?.Invoke();
			_attackCounterResetTimer.StartTimer();
		}

		private void ResetAttackCounter() => CurrentAttackCounter = 0;
	}
}