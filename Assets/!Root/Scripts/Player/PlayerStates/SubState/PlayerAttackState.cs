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

            PlayerCore.PlayerMovement.CheckIfShouldFlip(_xInput);

            if (_setVelocity)
            {
                PlayerCore.PlayerMovement.SetVelocityX(_velocityToSet * PlayerCore.PlayerMovement.FacingDirection);
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
            PlayerCore.PlayerMovement.SetVelocityX(velocity * PlayerCore.PlayerMovement.FacingDirection);

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
