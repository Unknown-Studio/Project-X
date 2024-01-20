using Suhdo.StateMachineCore;
using Suhdo.Weapons;

namespace Suhdo.Player
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private Weapon _weapon;
        private int _xInput;

        private float _velocityToSet;
        private bool _setVelocity;
        private bool _shouldCheckFlip;
        
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

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (_shouldCheckFlip)
            {
                _xInput = player.InputHandler.NormInputX;
            }

            Core.Movement.CheckIfShouldFlip(_xInput);

            if (_setVelocity)
            {
                Core.Movement.SetVelocityX(_velocityToSet);
            }
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

        public void SetPlayerVelocity(float velocity)
        {
            Core.Movement.SetVelocityX(velocity);

            _velocityToSet= velocity;
            _setVelocity = true;
        }

        public void SetFlipCheck(bool value)
        {
            _shouldCheckFlip = value;
        }
        
        #endregion
    }
}
