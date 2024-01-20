using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyLookingForPlayer : EnemyState
    {
        protected D_EnemyLookingForPlayer stateData;
        
        protected bool turnImmediately;
        protected float lastTurnTime;
        protected int amountOfTurnsDone;
        protected bool isAllTurnsIsDone;
        protected bool isAllTurnsTimeDone;
        
        public EnemyLookingForPlayer(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyLookingForPlayer data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void Enter()
        {
            base.Enter();
            isAllTurnsIsDone = false;
            isAllTurnsTimeDone = false;

            lastTurnTime = StartTime;
            amountOfTurnsDone = 0;
            enemy.Core.Movement.SetVelocityZero();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (turnImmediately)
            {
                enemy.Core.Movement.Flip();
                lastTurnTime = Time.time;
                amountOfTurnsDone++;
                turnImmediately = false;
            }
            else if(Time.time >= lastTurnTime + stateData.TimeBetweenTurns && !isAllTurnsIsDone)
            {
                enemy.Core.Movement.Flip();
                lastTurnTime = Time.time;
                amountOfTurnsDone++;
            }

            if (amountOfTurnsDone >=  stateData.AmountOfTurns)
            {
                isAllTurnsIsDone = true;
            }

            if(Time.time >= lastTurnTime + stateData.TimeBetweenTurns && isAllTurnsIsDone)
            {
                isAllTurnsTimeDone = true;
            }
        }
    }
}
