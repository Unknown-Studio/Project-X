using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
    public class PlayerPrimaryAttack : PlayerAttackState
    {
        public PlayerPrimaryAttack(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }
    }
}
