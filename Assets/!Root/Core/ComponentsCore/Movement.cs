using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo
{
    public class Movement : CoreComponent
    {
        public Rigidbody2D RB { get; private set; }
        public int FacingDirection { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        public bool CanSetVelocity { get; set; }
        
        private Vector2 _workSpaceVector;

        protected override void OnValidate()
        {
            base.OnValidate();
            FacingDirection = 1;
        }

        protected override void Awake()
        {
            base.Awake();
            FacingDirection = 1;
            CanSetVelocity = true;
            if((RB = GetComponentInParent<Rigidbody2D>()) == null) 
                Debug.LogError("Required Rigidbody2D in parent");
        }

        public override void LogicUpdate()
        {
            CurrentVelocity = RB.velocity;
        }

        #region Set Functions

        public void SetVelocityZero()
        {
            _workSpaceVector = Vector2.zero;
            SetFinalVelocity();
        }

        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            _workSpaceVector.Set(angle.x * velocity * direction, angle.y *velocity);
            SetFinalVelocity();
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            _workSpaceVector = direction * velocity;
            SetFinalVelocity();
        }

        public void SetVelocityX(float velocity, int direction)
        {
            _workSpaceVector.Set(velocity * direction, CurrentVelocity.y);
            SetFinalVelocity();
        }
        
        public void SetVelocityX(float velocity)
        {
            _workSpaceVector.Set(velocity * FacingDirection, CurrentVelocity.y);
            SetFinalVelocity();
        }

        public void SetVelocityY(float velocity)
        {
            _workSpaceVector.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();
        }

        private void SetFinalVelocity()
        {
            if (CanSetVelocity)
            {
                RB.velocity = _workSpaceVector;
                CurrentVelocity = _workSpaceVector;
            }
        }

        #endregion
        
        public void CheckIfShouldFlip(int xInput)
        {
            if(xInput != 0 && xInput != FacingDirection)
                Flip();
        }

        public void Flip()
        {
            FacingDirection *= -1;
            RB.transform.Rotate(0, 180, 0);
        }
    }
}
