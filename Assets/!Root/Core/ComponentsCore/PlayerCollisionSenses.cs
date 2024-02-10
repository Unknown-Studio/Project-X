using Sirenix.OdinInspector;
using Suhdo.Generics;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class PlayerCollisionSenses : BaseCollisionSenses
    {
        [SerializeField] private LayerMask whatIsGround;

        [FoldoutGroup("Ground Check", expanded: false)] [SerializeField]
        private Transform groundCheck;
        [FoldoutGroup("Ground Check")] [SerializeField]
        private float groundCheckRadius;

        [FoldoutGroup("Wall Check", expanded: false)] [SerializeField]
        private Transform wallCheck;
        [FoldoutGroup("Wall Check")] [SerializeField]
        private float wallFrontCheckDistance;
        [FoldoutGroup("Wall Check")] [SerializeField]
        private float wallBackCheckDistance;

        [FoldoutGroup("Ceiling Check", expanded: false)]
        [SerializeField]
        private Transform ceilingCheck;
        [FoldoutGroup("Ceiling Check")]
        [SerializeField]
        private float ceilingCheckRadius;
        
        [FoldoutGroup("Ledge Check", expanded: false)] [SerializeField]
        private Transform ledgeCheck;
        [FoldoutGroup("Ledge Check")] [SerializeField]
        private float ledgeCheckDistance;

        #region Public variables

        public override LayerMask WhatIsGround => whatIsGround;
        
        public override float WallFrontCheckDistance => wallFrontCheckDistance;
        public override float LedgeCheckDistance => ledgeCheckDistance;

        public override Transform GroundCheck => GenericNotImplementedError<Transform>.TryGet(groundCheck, Core.transform.parent.name);

        public override Transform WallCheck => GenericNotImplementedError<Transform>.TryGet(wallCheck, Core.transform.parent.name);

        public override Transform CeilingCheck => GenericNotImplementedError<Transform>.TryGet(ceilingCheck, Core.transform.parent.name);

        public override Transform LedgeCheck => GenericNotImplementedError<Transform>.TryGet(ledgeCheck, Core.transform.parent.name);
        
        public override bool Ground => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        public override bool Ceiling => Physics2D.OverlapCircle(ceilingCheck.position, ceilingCheckRadius, whatIsGround);
        
        public override bool WallFront => Physics2D.Raycast(wallCheck.position, Vector2.right * Movement.FacingDirection,
            wallFrontCheckDistance, whatIsGround);

        public override bool WallBack => Physics2D.Raycast(wallCheck.position, Vector2.right * -Movement.FacingDirection,
            wallBackCheckDistance, whatIsGround);
        
        public override bool Ledge => Physics2D.Raycast(ledgeCheck.position, Vector2.right * Movement.FacingDirection,
            ledgeCheckDistance, whatIsGround);

        #endregion

        #region Gizmos

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            Gizmos.DrawWireSphere(ceilingCheck.position, ceilingCheckRadius);
            Gizmos.DrawLine(wallCheck.position,
                wallCheck.position + (Vector3)(Vector2.right * Movement.FacingDirection * wallFrontCheckDistance));
            Gizmos.DrawLine(wallCheck.position,
                wallCheck.position + (Vector3)(Vector2.right * -Movement.FacingDirection * wallBackCheckDistance));
            Gizmos.DrawLine(ledgeCheck.position,
                ledgeCheck.position + (Vector3)(Vector2.right * Movement.FacingDirection * ledgeCheckDistance));
        }

        #endregion
    }
}