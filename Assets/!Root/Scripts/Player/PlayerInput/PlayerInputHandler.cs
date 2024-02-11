using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Suhdo.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private float inputHoldTime;
        [SerializeField]
        private float doubleClickThreshold = 0.3f;

        private float _jumpInputStartTime;

        private PlayerInput _playerInput;

        public Vector2 RawMovementInput { get; private set; }
        public int NormInputX { get; private set; }
        public int NormInputY { get; private set; }
        public bool JumpInput { get; private set; }
        public bool DoubleJumpInput { get; private set; }
        public bool JumpInputStop { get; private set; }
        public bool RollInput { get; private set; }
        public bool[] AttackInputs { get; private set; }

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();

            int count = Enum.GetValues(typeof(CombatInputs)).Length;
            AttackInputs = new bool[count];
        }

        private void Update()
        {
            CheckJumpInputHoldTime();
        }

        public void OnPrimaryAttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInputs[(int)CombatInputs.Primary] = true;
            }

            if (context.canceled)
            {
                AttackInputs[(int)CombatInputs.Primary] = false;
            }
        }
        
        public void OnSecondaryAttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInputs[(int)CombatInputs.Secondary] = true;
            }

            if (context.canceled)
            {
                AttackInputs[(int)CombatInputs.Secondary] = false;
            }
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();
            NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.y);
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                if (Time.time - _jumpInputStartTime < doubleClickThreshold)
                {
                    // Double click detected
                    Debug.Log("Double click detected");
                    DoubleJumpInput = true;
                }
                else
                {
                    // Single click
                    JumpInput = true;
                    JumpInputStop = false;
                }
                _jumpInputStartTime = Time.time;
            }
            else if (context.canceled)
            {
                JumpInputStop = true;
            }
        }

        public void OnRollInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                RollInput = true;
            }
            else if(context.canceled)
            {
                RollInput = false;
            }
        }
		
		public void UserJumpInput() => JumpInput = false;
		public void UserDoubleJumpInput() => DoubleJumpInput = false;

        public void CheckJumpInputHoldTime()
        {
            if (Time.time >= _jumpInputStartTime + inputHoldTime)
            {
                JumpInput = false;
                DoubleJumpInput = false;
            }
        }
    }
    
    public enum CombatInputs
    {
        Primary,
        Secondary
    }
}