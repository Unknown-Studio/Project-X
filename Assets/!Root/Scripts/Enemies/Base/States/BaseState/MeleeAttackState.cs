using Suhdo.Combat;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class MeleeAttackState : AttackState
    {
        protected D_EnemyMeleeAttack stateData;
        
        public MeleeAttackState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyMeleeAttack data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
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
                    damageableTarget.Damage(stateData.AttackDamage);
                }
                
                if (collider.TryGetComponent<IKnockbackable>(out var knockbackable))
                {
                    knockbackable.Knockback(stateData.KnockbackAngle, stateData.KnockbackStrength, enemy.Core.Movement.FacingDirection);
                }
            }
        }
    }
}
