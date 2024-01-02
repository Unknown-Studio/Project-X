using UnityEngine;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton : Enemy
    {
        [SerializeField] private D_EnemyIdleState _idleStateData;
        
        public Skeleton_IdleState IdleState { get; private set; }

        protected override void Start()
        {
            base.Start();

            IdleState = new Skeleton_IdleState(StateMachine, this, "idle", _idleStateData);
            
            StateMachine.Initiallize(IdleState);
        }
    }
}
