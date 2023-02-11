using UnityEngine;

namespace Game
{
    public abstract class Ship : MonoBehaviour
    {
        [HideInInspector] public GameObject ship;
        [HideInInspector] public Transform shipTransform;
        [HideInInspector] public Rigidbody2D shipRigidbody;

        [HideInInspector] public ShipInput shipInput;
        [HideInInspector] public BulletLauncher[] bulletLaunchers;

        public float shipHealthValue = 100;
        public float shipSpeedFactor = 1;
        public float shipAccelerationFactor = 1;
        public float DashTime = 1;

        protected readonly float defaultShipSpeed = 5;
        protected readonly float defaultShipAcceleration = 5;
        protected float dashTimer = 1;
        protected float rotationAngle;

        private void Start()
        {
            shipRigidbody = GetComponent<Rigidbody2D>();
            shipTransform = GetComponent<Transform>();
            shipInput = GetComponent<ShipInput>();
            bulletLaunchers = GetComponentsInChildren<BulletLauncher>();
            StartAction();
        }

        protected virtual void HandleLocomotion(Vector2 movementInput, Vector2 gazeLocationInput, float delta)
        {
            movementInput.Normalize();
            gazeLocationInput.Normalize();

            shipRigidbody.velocity = Vector2.MoveTowards(shipRigidbody.velocity, defaultShipSpeed * shipSpeedFactor * movementInput, delta * defaultShipAcceleration * shipAccelerationFactor);
            Vector2 vectorToGaze = new(gazeLocationInput.x, gazeLocationInput.y);
            float _lastAngle = rotationAngle;
            rotationAngle = Vector2.Angle(vectorToGaze, Vector2.up);
            if (Vector2.Angle(vectorToGaze, Vector2.right) <= 90)
            {
                rotationAngle = -rotationAngle + 360;
            }
            rotationAngle = Mathf.MoveTowardsAngle(_lastAngle, rotationAngle, 720 * Time.deltaTime);
            shipTransform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        }

        protected virtual void HandleDash(bool dashInput, Vector2 movementInput)
        {
            if (dashTimer > DashTime)
            {
                if (dashInput && movementInput.magnitude > 0)
                {
                    shipRigidbody.position += movementInput * 2;
                    shipRigidbody.velocity = movementInput * defaultShipSpeed;
                    dashTimer = 0;
                }
            }
            else
            {
                dashTimer += Time.deltaTime;
            }
        }

        protected virtual void HandleBlocking(bool blockingInput)
        {

        }

        protected virtual void HandleDeath()
        {

        }

        protected virtual void PostTick() { }
        protected virtual void PreTick() { }
        protected virtual void StartAction() { }

        private void Update()
        {
            float delta = Time.deltaTime;

            PreTick();
            shipInput.TickInput();
            HandleLocomotion(shipInput.MovementInput, shipInput.GazeLocationInput, delta);
            HandleDash(shipInput.DashInput, shipInput.MovementInput);
            HandleBlocking(shipInput.BlockingInput);
            foreach (BulletLauncher bulletLauncher in bulletLaunchers)
                bulletLauncher.Shoot(shipInput.ShootInput);
            PostTick();
        }
    }
}
