using Suhdo.StateMachineCore;
using Suhdo.Weapons;

namespace Suhdo.Player
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private Weapon _weapon;
        private int _inputIndex;
        
        public PlayerAttackState(
            StateMachine stateMachine,
            Entity entity,
            string animBoolName,
            PlayerData data,
            Weapon weapon,
            CombatInputs input
            ) : base(stateMachine, entity, animBoolName, data)
        {
            _weapon = weapon;
            _inputIndex = (int) input;

            _weapon.OnExit += ExitHandler;
        }

        public override void Enter()
        {
            base.Enter();
            _weapon.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            var playerInputHandler = player.InputHandler;
            var attackInputs = playerInputHandler.AttackInputs;

            _weapon.CurrentInput = attackInputs[_inputIndex];
        }

        private void ExitHandler()
        {
            AnimationFinishTrigger();
            isAbilityDone = true;
        }
    }
}
