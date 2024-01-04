using System.Collections;
using System.Collections.Generic;
using Suhdo.Enemies;
using Suhdo.Enemies.Skeleton;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo
{
    public class Skeleton_MoveState : EnemyMoveState
    {
        private Skeleton _skeleton;
        
        public Skeleton_MoveState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyMoveState data) : base(stateMachine, entity, animBoolName, data)
        {
            _skeleton = (Skeleton)entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerInMinAgroRange)
            {
                // Change to Detected state
            }
            else if (isDetectingWall || !isDetectingLedge)
            {
                _skeleton.IdleState.SetFlipAfterIdle(true);
                stateMachine.ChangeState(_skeleton.IdleState);
            }
        }
    }
}
