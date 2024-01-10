using UnityEngine;
using UnityEngine.InputSystem;

namespace Suhdo.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private float inputHoldTime;

        private float _jumpInputStartTime;

        private PlayerInput _playerInput;

        public Vector2 RawMovementInput { get; private set; }
        public int NormInputX { get; private set; }
        public int NormInputY { get; private set; }
        public bool JumpInput { get; private set; }
        public bool JumpInputStop { get; private set; }
        public bool RollInput { get; private set; }
        public bool RollInputStop { get; private set; } 

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            CheckJumpInputHoldTime();
            CheckRollInputHoldTime();
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
                JumpInput = true;
                JumpInputStop = false;
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
                RollInputStop = false;
            }
            else
            {
                RollInputStop = true;
            }
        }
		
		public void UserJumpInput() => JumpInput = false;

		public void UserRollInput() => RollInput = false;

        public void CheckJumpInputHoldTime()
        {
            if (Time.time >= _jumpInputStartTime + inputHoldTime)
                JumpInput = false;
        }

        public void CheckRollInputHoldTime()
        {
            if (Time.time >= _jumpInputStartTime + inputHoldTime)
                RollInput = false;
        }
    }
}