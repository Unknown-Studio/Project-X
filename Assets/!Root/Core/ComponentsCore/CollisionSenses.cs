using Sirenix.OdinInspector;
using Suhdo.Generics;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class CollisionSenses : BaseCollisionSenses
    {
        [SerializeField] private bool baseCharacter = true;
        [SerializeField] private bool player;
        [SerializeField] private bool enemy;
        
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
        
        [ShowIfGroup("enemy")]
        [FoldoutGroup("enemy/Player Check", expanded: false), ShowIfGroup("enemy")] [SerializeField]
        private Transform attackPlayerPostion;
        [FoldoutGroup("enemy/Player Check")] [SerializeField]
        private float attackRadius;
        [FoldoutGroup("enemy/Player Check")] [Space(10)][SerializeField]
        private Transform playerCheck;
        [FoldoutGroup("enemy/Player Check")] [SerializeField]
        private float maxAgroDistance;
        [FoldoutGroup("enemy/Player Check")] [SerializeField]
        private float minAgroDistance;
        [FoldoutGroup("enemy/Player Check")] [SerializeField]
        private float closeRangeActionDistance;
        [FoldoutGroup("enemy/Player Check")] [SerializeField]
        private LayerMask whatIsPlayer;

        #region Public variables

        public override LayerMask WhatIsGround => whatIsGround;

        public override float WallFrontCheckDistance => wallFrontCheckDistance;
        public override float LedgeCheckDistance { get; }

        public LayerMask WhatIsPlayer => whatIsPlayer;

        public override Transform GroundCheck => GenericNotImplementedError<Transform>.TryGet(groundCheck, Core.transform.parent.name);

        public override Transform WallCheck => GenericNotImplementedError<Transform>.TryGet(wallCheck, Core.transform.parent.name);

        public override Transform CeilingCheck => GenericNotImplementedError<Transform>.TryGet(ceilingCheck, Core.transform.parent.name);
        public override Transform LedgeCheck { get; }

        public Transform AttackPlayerPosition
        {
            get => GenericNotImplementedError<Transform>.TryGet(attackPlayerPostion, Core.transform.parent.name);
            private set => attackPlayerPostion = value;
        }
        
        public float AttackRadius => attackRadius;

        public override bool Ground => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        public override bool Ceiling => Physics2D.OverlapCircle(ceilingCheck.position, ceilingCheckRadius, whatIsGround);
        
        public override bool WallFront => Physics2D.Raycast(wallCheck.position, Vector2.right * Movement.FacingDirection,
            wallFrontCheckDistance, whatIsGround);

        public override bool WallBack => Physics2D.Raycast(wallCheck.position, Vector2.right * -Movement.FacingDirection,
            wallBackCheckDistance, whatIsGround);
        
        public override bool Ledge => Physics2D.Raycast(ledgeCheck.position, Vector2.down,
            ledgeCheckDistance, whatIsGround);
        
        public bool PlayerInMaxAgroRange => Physics2D.Raycast(playerCheck.position,
            Vector2.right * Movement.FacingDirection,
            maxAgroDistance, whatIsPlayer);
	
        public bool PlayerInMinAgroRange => Physics2D.Raycast(playerCheck.position,
            Vector2.right * Movement.FacingDirection,
            minAgroDistance, whatIsPlayer);

        public bool PlayerInCloseRangeAction => Physics2D.Raycast(playerCheck.position,
            Vector2.right * Movement.FacingDirection,
            closeRangeActionDistance, whatIsPlayer);

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
            Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * ledgeCheckDistance));

            if (enemy)
            {
                Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * Movement.FacingDirection * closeRangeActionDistance), .2f);
                Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * Movement.FacingDirection * minAgroDistance), .2f);
                Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * Movement.FacingDirection * maxAgroDistance), .2f);
                Gizmos.DrawWireSphere(attackPlayerPostion.position, attackRadius);
            }
        }

        #endregion
    }
}