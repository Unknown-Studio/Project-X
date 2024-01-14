using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
    public class PlayerSecondaryAttack : PlayerAttackState
    {
        public PlayerSecondaryAttack(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }
    }
}
