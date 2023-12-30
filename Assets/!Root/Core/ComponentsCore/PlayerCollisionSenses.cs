using Sirenix.OdinInspector;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class PlayerCollisionSenses : PlayerCoreComponent
    {
        [SerializeField] private LayerMask whatIsGround;

        [FoldoutGroup("Ground Check", expanded: false)] [SerializeField]
        private Transform groundCheck;

        [FoldoutGroup("Ground Check")] [SerializeField]
        private float groundCheckRadius;

        [FoldoutGroup("Wall Check", expanded: false)] [SerializeField]
        private Transform wallCheck;

        [FoldoutGroup("Wall Check")] [SerializeField]
        private float wallCheckDistance;

        #region Public variables

        public LayerMask WhatIsGround => whatIsGround;

        public Transform GroundCheck
        {
            get => groundCheck;
            private set => groundCheck = value;
        }

        public Transform WallCheck
        {
            get => wallCheck;
            private set => wallCheck = value;
        }

        public bool Ground => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        public bool WallFront => Physics2D.Raycast(wallCheck.position, Vector2.right * PlayerCore.PlayerMovement.FacingDirection,
            wallCheckDistance, whatIsGround);

        public bool WallBack => Physics2D.Raycast(wallCheck.position, Vector2.right * -PlayerCore.PlayerMovement.FacingDirection,
            wallCheckDistance, whatIsGround);

        #endregion

        #region Gizmos

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            Gizmos.DrawLine(wallCheck.position,
                wallCheck.position + (Vector3)(Vector2.right * PlayerCore.PlayerMovement.FacingDirection * wallCheckDistance));
            Gizmos.DrawLine(wallCheck.position,
                wallCheck.position + (Vector3)(Vector2.right * -PlayerCore.PlayerMovement.FacingDirection * wallCheckDistance));
        }

        #endregion
    }
}