using Suhdo.StateMachineCore;
using Suhdo.Weapons;

namespace Suhdo.Player
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private Weapon _weapon;
        
        public PlayerAttackState(
            StateMachine stateMachine,
            Entity entity,
            string animBoolName,
            PlayerData data,
            Weapon weapon
            ) : base(stateMachine, entity, animBoolName, data)
        {
            _weapon = weapon;
        }

        public override void Enter()
        {
            base.Enter();
            _weapon.Enter();
        }
    }
}
