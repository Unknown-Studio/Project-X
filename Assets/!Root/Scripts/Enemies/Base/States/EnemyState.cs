using Suhdo.CharacterCore;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyState : CoreState
    {
        protected Enemy enemy;
        protected EnemyCore enemyCore;
        
        public EnemyState(StateMachine stateMachine, Entity entity, string animBoolName)
            : base(stateMachine, entity, animBoolName)
        {
            enemy = (Enemy)entity;
            enemyCore = enemy.EnemyCore;
        }
    }
}
