using UnityEngine;
using UnityEngine.InputSystem;


namespace Game
{
    public class InputHandler : ShipInput
    {
        private PlayerInput inputActions;
        private Player attachedPlayer;

        [Header("Settings")]
        [SerializeField] private InputControlScheme controlScheme;

        private Vector2 crosshairInput;

        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerInput();
                attachedPlayer = GetComponent<Player>();
                inputActions.Movement.Movement.performed += _movement => MovementInput = _movement.ReadValue<Vector2>();
                inputActions.Movement.Crosshair.performed += _crosshair => crosshairInput = _crosshair.ReadValue<Vector2>();
                controlScheme = inputActions.KeyboardMouseScheme;
            }
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public override void TickInput()
        {
            HandleMouseBottonsInput();
            CalculateGazeLocation();
            HandleDashInput();
        }

        public void OnControlSchemeChenged()
        {
            if (controlScheme == inputActions.KeyboardMouseScheme)
                controlScheme = inputActions.GamepadScheme;
            else
            {
                controlScheme = inputActions.KeyboardMouseScheme;
            }
        }

        #region HandleInputs
        private void HandleMouseBottonsInput()
        {
            BlockingInput = inputActions.Actions.RightMB.phase == InputActionPhase.Performed;
            ShootInput = inputActions.Actions.LeftMb.phase == InputActionPhase.Performed;
        }

        private void HandleDashInput()
        {
            DashInput = inputActions.Actions.Dash.phase == InputActionPhase.Performed;
        }

        private void CalculateGazeLocation()
        {
            if (controlScheme == inputActions.KeyboardMouseScheme)
            {
                GazeLocationInput = Camera.main.ScreenToWorldPoint(crosshairInput);
                GazeLocationInput -= new Vector3(0, 0, GazeLocationInput.z);
                GazeLocationInput -= attachedPlayer.shipTransform.position;
                GazeLocationInput = new Vector3(GazeLocationInput.x, GazeLocationInput.y, 0);
            }

            if (controlScheme == inputActions.GamepadScheme)
            {

            }
        }
        #endregion
    }
}