using System.Collections;
using System.Collections.Generic;
using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class EnemyMovement : EnemyCoreComponent
    {
        public Rigidbody2D RB { get; private set; }
        public int FacingDirection { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }

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
            if((RB = GetComponentInParent<Rigidbody2D>()) == null) 
                Debug.LogError("Required Rigidbody2D in parent");
        }

        public void LogicUpdate()
        {
            CurrentVelocity = RB.velocity;
        }

        #region Set Functions

        public void SetVelocityZero()
        {
            RB.velocity = Vector2.zero;
            CurrentVelocity = Vector2.zero;
        }

        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            _workSpaceVector.Set(angle.x * velocity * direction, angle.y *velocity);
            RB.velocity = _workSpaceVector;
            CurrentVelocity = _workSpaceVector;
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            _workSpaceVector = direction * velocity;
            RB.velocity = _workSpaceVector;
            CurrentVelocity = _workSpaceVector;
        }

        public void SetVelocityX(float velocity)
        {
            _workSpaceVector.Set(velocity, CurrentVelocity.y);
            RB.velocity = _workSpaceVector;
            CurrentVelocity = _workSpaceVector;
        }

        public void SetVelocityY(float velocity)
        {
            _workSpaceVector.Set(CurrentVelocity.x, velocity);
            RB.velocity = _workSpaceVector;
            CurrentVelocity = _workSpaceVector;
        }

        #endregion

        public void CheckIfShouldFlip(int xInput)
        {
            if(xInput != 0 && xInput != FacingDirection)
                Flip();
        }

        private void Flip()
        {
            FacingDirection *= -1;
            RB.transform.Rotate(0, 180, 0);
        }
    }
}

