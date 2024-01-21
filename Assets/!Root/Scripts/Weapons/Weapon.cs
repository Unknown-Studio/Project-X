using System;
using Suhdo.CharacterCore;
using Suhdo.Player;
using UnityEngine;

namespace Suhdo.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected D_Weapon weaponData;

        protected Core core;
        protected PlayerAttackState state;
        protected Animator anim;
        protected int attackCounter;
        
        public void InitializeWeapon(PlayerAttackState state, Core core)
        {
            this.state = state;
            this.core = core;
        }
        
        protected virtual void Awake()
        {
            anim = transform.Find("Base").GetComponent<Animator>();
            
            gameObject.SetActive(false);
        }

        public virtual void EnterWeapon()
        {
            gameObject.SetActive(true);
            if (attackCounter >= weaponData.MovementSpeed.Length) attackCounter = 0;
            
            anim.SetBool("attack", true);
            anim.SetInteger("attackCounter", attackCounter);
        }

        public virtual void ExitWeapon()
        {
            anim.SetBool("attack", false);

            attackCounter++;
            
            gameObject.SetActive(false);
        }

        #region Animation Trigger

        public virtual void AnimationFinishTrigger()
        {
            state.AnimationFinishTrigger();
        }

        public virtual void AnimationStartMovementTrigger()
        {
            state.SetPlayerVelocity(weaponData.MovementSpeed[attackCounter]);
        }

        public virtual void AnimationStopMovementTrigger()
        {
            state.SetPlayerVelocity(0f);
        }

        public virtual void AnimationTurnOffFlip()
        {
            state.SetFlipCheck(false);
        }

        public virtual void AnimationTurnOnFlip()
        {
            state.SetFlipCheck(true);
        }

        public virtual void AnimationActionTrigger()
        {
        }

        #endregion
    }
}
