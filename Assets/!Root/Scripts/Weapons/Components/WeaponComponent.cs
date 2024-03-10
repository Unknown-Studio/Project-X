using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	 public abstract class WeaponComponent : MonoBehaviour
	 {
		 protected Weapon weapon;
		 protected AnimationEventHandler eventHandler => weapon.EventHandler;
		 protected Core Core => weapon.Core;
		 protected bool isAttackActive;

		 public virtual void Init()
		 {
			 weapon = GetComponent<Weapon>();
		 }

		 protected virtual void Awake()
		 {
			 weapon = GetComponent<Weapon>();
		 }
		 
		 protected virtual void Start()
		 {
			 weapon.OnEnter += EnterHandle;
			 weapon.OnExit += ExitHandle;
		 }

		 protected virtual void EnterHandle()
		 {
			 isAttackActive = true;
		 }

		 protected virtual void ExitHandle()
		 {
			 isAttackActive = false;
		 }

		 protected virtual void OnDestroy()
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

		 public override void Init()
		 {
			 base.Init();
			 data = weapon.Data.GetData<T1>();
		 }
	 }
}