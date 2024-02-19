using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Suhdo.Weapons
{
	public class Weapon : MonoBehaviour
	{
		public event Action OnExit;
		
		private Animator _anim;
		private GameObject _baseGameObject;
		private AnimationEventHandler _eventHandler;

		private void Awake()
		{
			_baseGameObject = transform.Find("Base").gameObject;
			_anim = _baseGameObject.GetComponent<Animator>();
			_eventHandler = _baseGameObject.GetComponent<AnimationEventHandler>();
		}

		private void OnEnable()
		{
			_eventHandler.Exit += Exit;
		}

		private void OnDisable()
		{
			_eventHandler.Exit -= Exit;
		}

		public void Enter()
		{
			print($"{transform.name} enter");
			
			_anim.SetBool("active", true);
		}

		private void Exit()
		{
			_anim.SetBool("active", false);
			
			OnExit?.Invoke();
		}
	}
}