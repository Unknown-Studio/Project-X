using System;
using DG.Tweening;
using Suhdo.CharacterCore;
using Suhdo.Enemies;
using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.Items
{
    public class Projectile : PoolableMonoBehaviour
    {
        [SerializeField] private float gravity;
        [SerializeField] private float damgageRadius;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private Transform damagePos;
        [SerializeField] private float delayBeforeReturnPool;
        
        private AttackDetails attackDetails;

        private float speed;
        private float travelDistance;
        private float xStartPos;
        private float timeSinceHitGround;

        private Rigidbody2D rb;

        private bool isGravityOn;
        private bool isFired;
        private bool hasHitGround;

        public override void OnObjectPoolCreate()
        {
            base.OnObjectPoolCreate();

            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Project tile is not have a Rigidbody2D");
                return;
            }

            isGravityOn = false;
            rb.gravityScale = 0f;
        }

        private void Update()
        {
            if (hasHitGround) return;
            attackDetails.position = transform.position;
            if (isGravityOn)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        private void FixedUpdate()
        {
            if (hasHitGround)
            {
                timeSinceHitGround += Time.fixedDeltaTime;
                if(timeSinceHitGround >= delayBeforeReturnPool)
                    Release();
                return;
            }

            Collider2D damageHit = Physics2D.OverlapCircle(damagePos.position, damgageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePos.position, damgageRadius, whatIsGround);

            // Touched player
            if (damageHit && damageHit.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.Damage(20f);
                Release();
            }

            // Touched ground
            if (groundHit)
            {
                hasHitGround = true;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }

            // don't touch anything
            if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn && isFired)
            {
                isGravityOn = true;
                rb.gravityScale = gravity;
            }
        }

        public override void OnObjectPoolReturn()
        {
            base.OnObjectPoolReturn();
            isGravityOn = false;
            isFired = false;
            hasHitGround = false;
            rb.gravityScale = 0f;
            timeSinceHitGround = 0f;
        }

        public void FireProjectile(float speed, float travelDistance, float damage)
        {
            this.speed = speed;
            this.travelDistance = travelDistance;
            attackDetails.damageAmount = damage;
            
            xStartPos = transform.position.x;
            rb.velocity = transform.right * speed;
            isFired = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(damagePos.position, damgageRadius);
        }
    }
}
