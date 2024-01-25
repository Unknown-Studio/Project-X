using DG.Tweening;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class TeleState : EnemyState
    {
        protected D_EnemyTeleState stateData;
        protected Vector3 startPos;
        protected bool teleDone;
        
        public TeleState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyTeleState data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void Enter()
        {
            base.Enter();

            teleDone = false;
            startPos = enemy.transform.position;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= StartTime + stateData.chargeTime)
            {
                Movement.SetVelocityX(stateData.Speed);
                if (IsPosWantToMove() || isDetectingWall || !isDetectingLedge)
                {
                    Movement.SetVelocityX(0f);
                    teleDone = true;
                }
            }
        }

        private bool IsPosWantToMove()
        {
            return Vector3.Distance(startPos, enemy.transform.position) >= stateData.DistanceTele;
        }
    }
}
