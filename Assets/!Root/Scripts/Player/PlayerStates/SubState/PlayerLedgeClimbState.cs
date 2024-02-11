using System.ComponentModel;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerLedgeClimbState : PlayerState
    {
        private Vector2 _detectedPos;
        private Vector2 _cornerPos;
        private Vector2 _startPos;
        private Vector2 _stopPos;
        private Vector2 _workSpaceVector;

        private int _xInput;
        private int _yInput;

        private bool _isHanging;
        private bool _isClimbing;
        private bool _isTouchingCeiling;
        
        public PlayerLedgeClimbState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data)
            : base(stateMachine, entity, animBoolName, data)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            
            Movement.SetVelocityZero();
            _detectedPos = player.transform.position;
            _cornerPos = DetermineCornerPosition();
            _isHanging = true;
            
            _startPos.Set(_cornerPos.x - (Movement.FacingDirection * playerData.startOffset.x),
                _cornerPos.y - playerData.startOffset.y);
            _stopPos.Set(_cornerPos.x + (Movement.FacingDirection * playerData.stopOffset.x),
                _cornerPos.y + playerData.stopOffset.y);
            
            player.transform.position = _startPos;

        }
        
        public override void DoChecks()
        {
            base.DoChecks();

            _xInput = player.InputHandler.NormInputX;
            _yInput = player.InputHandler.NormInputY;
        }

        public override void Exit()
        {
            base.Exit();

            _isHanging = false;

            if (!_isClimbing) return;
            if(_isTouchingCeiling)
                player.SetColliderHeight(playerData.crouchColliderHeight);
            player.transform.position = _stopPos;
            _isClimbing = false;

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationFinished)
            {
                if (_isTouchingCeiling)
                {
                    Debug.Log("touching ceiling");
                    player.SetColliderHeight(playerData.crouchColliderHeight);
                    stateMachine.ChangeState(player.CrouchIdleState);
                }
                else
                {
                    stateMachine.ChangeState(player.IdleState);
                }

                return;
            }
            
            if (_xInput == Movement.FacingDirection && _isHanging && !_isClimbing)
            {
                CheckForSpace();
                _isClimbing = true;
                player.Anim.SetBool("climbLedge", true);
            }
            else if (_yInput == -1 && _isHanging && !_isClimbing)
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            Movement.SetVelocityZero();
            player.transform.position = _startPos;
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();

            player.Anim.SetBool("climbLedge", false);
        }
        
        private void CheckForSpace()
        {
            _isTouchingCeiling =
                Physics2D.Raycast(
                    _cornerPos + (Vector2.up * 0.015f) + (Vector2.right * 0.015f * Movement.FacingDirection),
                    Vector2.up, playerData.standColliderHeight, CollisionSenses.WhatIsGround);
        }
        
        private Vector2 DetermineCornerPosition()
        {
            RaycastHit2D xHit = Physics2D.Raycast(CollisionSenses.WallCheck.position, Vector2.right * Movement.FacingDirection,
                CollisionSenses.WallFrontCheckDistance, CollisionSenses.WhatIsGround);
            float xDist = xHit.distance;
            _workSpaceVector.Set((xDist + 0.015f) * Movement.FacingDirection, 0f);
            
            RaycastHit2D yHit = Physics2D.Raycast(CollisionSenses.LedgeCheck.position + (Vector3)(_workSpaceVector),
                Vector2.down,
                CollisionSenses.LedgeCheck.position.y - CollisionSenses.WallCheck.position.y + 0.015f,
                CollisionSenses.WhatIsGround);
            float yDist = yHit.distance;
            
            _workSpaceVector.Set(CollisionSenses.WallCheck.position.x + (xDist * Movement.FacingDirection),
                CollisionSenses.LedgeCheck.position.y - yDist);

            return _workSpaceVector;
        }
    }
}
