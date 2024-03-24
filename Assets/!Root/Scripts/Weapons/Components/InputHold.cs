using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class InputHold : WeaponComponent
	{
		private Animator _anim;
		private bool _input;
		private bool _minHoldPassed;

		protected override void Awake()
		{
			base.Awake();

			_anim = GetComponentInChildren<Animator>();
			eventHandler.OnMinHoldPassed += HandleOnMinHoldPassed;
			weapon.OnCurrentInputChange += HandleCurrentInputChange;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			
			eventHandler.OnMinHoldPassed -= HandleOnMinHoldPassed;
			weapon.OnCurrentInputChange -= HandleCurrentInputChange;
		}

		private void HandleOnMinHoldPassed()
		{
			_minHoldPassed = true;
			SetAnimatorParameter();
		}

		private void HandleCurrentInputChange(bool newInput)
		{
			_input = newInput;
			
			SetAnimatorParameter();
		}
		
		private void SetAnimatorParameter()
		{
			if (_input)
			{
				_anim.SetBool("hold", _input);
				return;
			}

			if (_minHoldPassed)
			{
				_anim.SetBool("hold", false);
			}
		}
	}
}