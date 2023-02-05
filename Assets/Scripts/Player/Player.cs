using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {

        [HideInInspector] public Transform playerTransform;
        [HideInInspector] public Rigidbody2D playerRigidbody;

        private ShipInput attachedInputHandler;
        private PlayerLocomotion attachedPlayerLocomotion;
        private BulletLauncher[] bulletLaunchers;
        [SerializeField] private CameraHandler attachedCameraHandler;

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerTransform = GetComponent<Transform>();
            attachedInputHandler = GetComponent<ShipInput>();
            attachedPlayerLocomotion = GetComponent<PlayerLocomotion>();
            bulletLaunchers = GetComponentsInChildren<BulletLauncher>();

        }

        private void Update()
        {
            attachedInputHandler.TickInput();
            attachedPlayerLocomotion.HandlePlayerMovement(attachedInputHandler.MovementInput, attachedInputHandler.GazeLocationInput, playerTransform, playerRigidbody);
            attachedPlayerLocomotion.HandleDash(attachedInputHandler.DashInput, attachedInputHandler.MovementInput, playerRigidbody);
            foreach (BulletLauncher bulletLauncher in bulletLaunchers)
                bulletLauncher.Shoot(attachedInputHandler.ShootInput);
        }

        private void FixedUpdate()
        {
            attachedCameraHandler.Tick(this, attachedInputHandler.GazeLocationInput, Time.fixedDeltaTime);

        }
    }
}
