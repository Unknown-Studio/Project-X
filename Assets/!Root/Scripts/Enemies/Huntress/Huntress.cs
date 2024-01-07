using Unity.VisualScripting;
using UnityEngine;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress : Enemy
    {
        [SerializeField] private D_EnemyIdleState _idleStateData;
        [SerializeField] private D_EnemyMoveState _moveStateData;
        
        public Huntress_IdleState IdleState { get; private set; }
        public Huntress_MoveState MoveState { get; private set; }

        protected override void Start()
        {
            base.Start();

            IdleState = new Huntress_IdleState(StateMachine, this, "idle", _idleStateData);
            MoveState = new Huntress_MoveState(StateMachine, this, "move", _moveStateData);
            
            StateMachine.Initiallize(IdleState);
        }
    }
}
