using System;
using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	 public abstract class WeaponComponent : MonoBehaviour
	 {
		 protected Weapon weapon;
		 //TODO: fix this when finishig weapon data
		 //protected AnimationEventHandler eventHandler => weapon.EventHandler;
		 protected AnimationEventHandler eventHandler;
		 protected Core Core => weapon.Core;
		 protected bool isAttackActive;

		 protected virtual void Awake()
		 {
			 weapon = GetComponent<Weapon>();
			 eventHandler = GetComponentInChildren<AnimationEventHandler>();
		 }

		 protected virtual void EnterHandle()
		 {
			 isAttackActive = true;
		 }

		 protected virtual void ExitHandle()
		 {
			 isAttackActive = false;
		 }

		 protected virtual void OnEnable()
		 {
			 weapon.OnEnter += EnterHandle;
			 weapon.OnExit += ExitHandle;
		 }

		 protected virtual void OnDisable()
		 {
			 weapon.OnEnter -= EnterHandle;
			 weapon.OnExit -= ExitHandle;
		 }
	 }
}