using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.Player
{
    [CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/ Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move State")]
        public float movementVelocity = 10f;

        [Header("Jump State")]
        public float jumpVelocity = 15f;
        public int amountOfJumps = 1;
        
        [Header("In Air State")]
        public float coyoteTime = 0.2f;
        public float variableJumpHeightMultiplier = 0.5f;

        [Header("Crouch State")]
        public float crouchMovementVelocity = 5f;
        public float crouchColliderHeight = 0.8f;
        public float standColliderHeight = 1.6f;

        [Header("Roll State")]
        public float RollVelocity = 20f;    
        
        [Header("Roll state")]
        public float RollCooldown = 0.5f;

        [Header("Wall Slide State")]
        public float WallSlideVelocity = -3f;
        
        [Header("Ledge Climb State")] 
        public Vector2 startOffset;
        public Vector2 stopOffset;
        
        [Header("Air Dash State")] 
        public float airDashSpeed = 10f;
        public float DistBetweenAfterImages = 0.5f;

        [Header("FX")] public ObjectPoolSO AfterImagesPool;

        /*[Header("Wall Jump State")]
        public float wallJumpVelocity = 20f;
        public float wallJumpTime = 0.4f;
        public Vector2 wallJumpAngle = new Vector2(1, 2);

        [Header("Wall Slide State")]
        public float wallSlideVelocity = 3f;

        [Header("Wall Climb State")]
        public float wallClimbVelocity = 3f;



        [Header("Dash State")]
        public float dashCooldown = 0.5f;
        public float maxHoldTime = 1f;
        public float holdTimeScale = 0.25f;
        public float dashTime = 0.2f;
        public float dashVelocity = 30f;
        public float drag = 10f;
        public float dashEndYMultiplier = 0.2f;
        public float distBetweenAfterImages = 0.5f;

        [Header("Crouch State")]
        public float crouchMovementVelocity = 5f;
        public float crouchColliderHeight = 0.8f;
        public float standColliderHeight = 1.6f;*/
    }
}
