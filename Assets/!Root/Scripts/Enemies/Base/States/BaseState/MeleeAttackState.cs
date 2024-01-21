using Suhdo.Combat;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class MeleeAttackState : AttackState
    {
        protected D_EnemyMeleeAttack stateData;

        protected AttackDetails attackDetails;
        
        public MeleeAttackState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyMeleeAttack data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void Enter()
        {
            base.Enter();
            
            attackDetails.damageAmount = stateData.attackDamage;
            attackDetails.position = enemy.transform.position;
        }

        public override void TriggerAttack()
        {
            base.TriggerAttack();
            
            Collider2D[] detectedObjects = 
                Physics2D.OverlapCircleAll(enemy.Core.CollisionSenses.AttackPlayerPosition.position,
                    enemy.Core.CollisionSenses.AttackRadius, enemy.Core.CollisionSenses.WhatIsPlayer);

            foreach (Collider2D collider in detectedObjects)
            {
                if (collider.TryGetComponent<IDamageable>(out var damageableTarget))
                {
                    // Gọi phương thức TakeDamage của giao diện
                    damageableTarget.Damage(10f);
                }
            }
        }
    }
}
