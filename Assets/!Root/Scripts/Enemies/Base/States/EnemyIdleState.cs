using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyIdleState : EnemyState
    {
        public EnemyIdleState(StateMachine stateMachine, Entity entity, string animBoolName)
            : base(stateMachine, entity, animBoolName)
        {
        }
    }
}
