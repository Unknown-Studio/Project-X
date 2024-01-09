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
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= StartTime + stateData.chargeTime)
            {
                enemy
                    .transform
                    .DOMove(enemy.transform.position +
                            (Vector3.right * stateData.DistanceTele * enemy.EnemyCore.EnemyMovement.FacingDirection),
                        stateData.Speed)
                    .OnComplete(() => teleDone = true);
            }
        }
    }
}
