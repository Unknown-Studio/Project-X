using System;
using Suhdo.Player;
using UnityEngine;

namespace Suhdo.Weapons
{
    public class Weapon : MonoBehaviour
    {
        protected PlayerAttackState state;
        protected Animator anim;
        
        public void InitializeWeapon(PlayerAttackState state)
        {
            this.state = state;
        }
        
        private void Awake()
        {
            anim = transform.Find("Base").GetComponent<Animator>();
            
            gameObject.SetActive(false);
        }

        public virtual void EnterWeapon()
        {
            gameObject.SetActive(true);
            anim.SetBool("attack", true);
        }

        public virtual void ExitWeapon()
        {
            anim.SetBool("attack", false);
            gameObject.SetActive(false);
        }

        #region Animation Trigger

        public void AnimationFinishTrigger()
        {
            state.AnimationFinishTrigger();
        }

        public void AnimationStartMovementTrigger()
        {
            throw new NotImplementedException();
        }

        public void AnimationStopMovementTrigger()
        {
            throw new NotImplementedException();
        }

        public void AnimationTurnOffFlip()
        {
            throw new NotImplementedException();
        }

        public void AnimationTurnOnFlip()
        {
            throw new NotImplementedException();
        }

        public void AnimationActionTrigger()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
