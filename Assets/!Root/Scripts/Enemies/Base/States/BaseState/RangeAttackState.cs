using Suhdo.Items;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class RangeAttackState : AttackState
    {
        protected D_EnemyRangeAttackState stateData;

        protected GameObject projectile;
        protected Projectile projectileScript;
        
        public RangeAttackState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyRangeAttackState data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void TriggerAttack()
        {
            base.TriggerAttack();

            projectile = GameObject.Instantiate(stateData.projectile,
                enemy.EnemyCore.EnemyCollisionSenses.AttackPlayerPosition.position,
                enemy.EnemyCore.EnemyCollisionSenses.AttackPlayerPosition.rotation);
            projectileScript = projectile.GetComponent<Projectile>();
            projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage);
        }
    }
}
