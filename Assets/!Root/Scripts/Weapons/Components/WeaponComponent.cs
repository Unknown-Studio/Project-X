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
		 
		 protected virtual void Start(){}

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

	 public abstract class WeaponComponent<T1, T2> : WeaponComponent
		 where T1 : ComponentData<T2>
		 where T2 : AttackData
	 {
		 protected T1 data;
		 protected T2 currentAttackData;

		 protected override void EnterHandle()
		 {
			 base.EnterHandle();
			 currentAttackData = data.AttackData[weapon.CurrentAttackCounter];
		 }

		 protected override void Awake()
		 {
			 base.Awake();
			 data = weapon.Data.GetData<T1>();
		 }
	 }
}