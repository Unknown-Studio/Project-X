using Sirenix.OdinInspector;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class CollisionSenses : CoreComponent
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

        public bool WallFront => Physics2D.Raycast(wallCheck.position, Vector2.right * _core.Movement.FacingDirection,
            wallCheckDistance, whatIsGround);

        public bool WallBack => Physics2D.Raycast(wallCheck.position, Vector2.right * -_core.Movement.FacingDirection,
            wallCheckDistance, whatIsGround);

        #endregion
    }
}