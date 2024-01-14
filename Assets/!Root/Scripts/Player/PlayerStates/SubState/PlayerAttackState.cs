using Suhdo.StateMachineCore;
using Suhdo.Weapons;

namespace Suhdo.Player
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private Weapon _weapon;
        
        public PlayerAttackState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data)
            : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            _weapon.EnterWeapon();
        }

        public override void Exit()
        {
            base.Exit();
            
            _weapon.ExitWeapon();
        }

        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
            _weapon.InitializeWeapon(this);
        }

        #region Animation Trigger

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
            isAbilityDone = true;
        }

        #endregion
    }
}
