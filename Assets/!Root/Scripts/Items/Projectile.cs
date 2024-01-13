using System;
using Suhdo.CharacterCore;
using Suhdo.Enemies;
using UnityEngine;

namespace Suhdo.Items
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float gravity;
        [SerializeField] private float damgageRadius;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private Transform damagePos;
        
        private AttackDetails attackDetails;

        private float speed;
        private float travelDistance;
        private float xStartPos;


        private Rigidbody2D rb;

        private bool isGravityOn;
        private bool hasHitGround;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            rb.gravityScale = 0f;
            rb.velocity = transform.right * speed;

            isGravityOn = false;
            xStartPos = transform.position.x;
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
            if (hasHitGround) return;

            Collider2D damageHit = Physics2D.OverlapCircle(damagePos.position, damgageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePos.position, damgageRadius, whatIsGround);

            // Touched player
            if (damageHit && damageHit.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.Damage(20f);
                Destroy(gameObject);
            }

            // Touched ground
            if (groundHit)
            {
                hasHitGround = true;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }

            // don't touch anything
            if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                rb.gravityScale = gravity;
            }
        }

        public void FireProjectile(float speed, float travelDistance, float damage)
        {
            this.speed = speed;
            this.travelDistance = travelDistance;
            attackDetails.damageAmount = damage;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(damagePos.position, damgageRadius);
        }
    }
}
