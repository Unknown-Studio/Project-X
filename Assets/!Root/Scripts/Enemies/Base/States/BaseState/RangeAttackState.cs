using Suhdo.Items;
using Suhdo.StateMachineCore;
using Suhdo.Ultils;
using Unity.VisualScripting;
using UnityEngine;
using StateMachine = Suhdo.StateMachineCore.StateMachine;

namespace Suhdo.Enemies
{
    public class RangeAttackState : AttackState
    {
        protected D_EnemyRangeAttackState stateData;

        protected PoolableMonoBehaviour projectile;
        protected Projectile projectileScript;
        
        public RangeAttackState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyRangeAttackState data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void TriggerAttack()
        {
            base.TriggerAttack();
            /*projectile = GameObject.Instantiate(stateData.projectile,
                enemy.Core.CollisionSenses.AttackPlayerPosition.position,
                enemy.Core.CollisionSenses.AttackPlayerPosition.rotation);*/
            projectile = stateData.pool.Get();
            projectile.transform.SetPositionAndRotation(
                CollisionSenses.AttackPlayerPosition.position,
                CollisionSenses.AttackPlayerPosition.rotation
                );
            projectileScript = projectile.GetComponent<Projectile>();
            projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage);
        }
    }
}
