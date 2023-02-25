using UnityEngine;

namespace Game
{
    [RequireComponent(typeof (ShipInput))]
    [RequireComponent(typeof (ShipParameters))]
    public abstract class Ship : DamagibleObject
    {
        public float CurrentBulletsCount;
        public float CurrentDashCount;

        [HideInInspector] public GameObject ship;
        [HideInInspector] public Transform shipTransform;
        [HideInInspector] public Rigidbody2D shipRigidbody;

        [HideInInspector] public ShipInput shipInput;
        [HideInInspector] public BulletLauncher[] bulletLaunchers;
        [HideInInspector] public ShipParameters shipParameters;

        [Header("Flags")]
        public bool IsBlocking = false;
        public bool IsBulletsOnReload = false;
        public bool IsDashOnReload = false;

        private bool HasBulletLaunchers = true;

        protected readonly float defaultShipSpeed = 5;
        protected readonly float defaultShipAcceleration = 10;
        protected readonly float defaultDashForce = 2;

        [HideInInspector] public float dashReloadingTimer = 0;
        [HideInInspector] public float dashRegenCooldownTimer = 0;
        [HideInInspector] public float dashCooldownTimer = 0;

        [HideInInspector] public float blockReloadingTimer = 2;

        [HideInInspector] public float bulletsReloadingTimer = 0;
        [HideInInspector] public float bulletRegenCooldownTimer = 0;

        protected float rotationAngle;

        private void Start()
        {
            shipRigidbody = GetComponent<Rigidbody2D>();
            shipTransform = GetComponent<Transform>();
            shipInput = GetComponent<ShipInput>();
            bulletLaunchers = GetComponentsInChildren<BulletLauncher>();

            HasBulletLaunchers = (bulletLaunchers.Length > 0);

            shipParameters = GetComponent<ShipParameters>();
            HealthValue = shipParameters.MaxHealthValue;
            CurrentBulletsCount = shipParameters.MaxBulletsCount;
            CurrentDashCount = shipParameters.MaxDashCount;
            StartAction();
        }

        private void Update()
        {
            float delta = Time.deltaTime;

            PreTick(delta);
            shipInput.TickInput();
            HandleLocomotion(shipInput.MovementInput, shipInput.GazeLocationInput, delta);
            HandleDash(delta, shipInput.DashInput, shipInput.MovementInput);
            HandleBlocking(shipInput.BlockingInput);
            HandleShooting(delta);
            PostTick(delta);
        }

        protected virtual void HandleLocomotion(Vector2 movementInput, Vector2 gazeLocationInput, float delta)
        {
            movementInput = Vector2.ClampMagnitude(movementInput, 1);
            gazeLocationInput.Normalize();

            shipRigidbody.velocity = Vector2.MoveTowards(shipRigidbody.velocity, defaultShipSpeed * shipParameters.SpeedFactor * movementInput, delta * defaultShipAcceleration * shipParameters.AccelerationFactor);
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

        protected virtual void HandleDash(float delta, bool dashInput, Vector2 movementInput)
        {
            CalculateCurrentValueFromReload(delta, ref IsDashOnReload, ref dashReloadingTimer, ref CurrentDashCount, shipParameters.MaxDashCount, shipParameters.DashReloadTime);

            if (dashCooldownTimer >= shipParameters.DashInterval)
            {
                if (dashInput && movementInput.magnitude > 0 && !IsDashOnReload)
                {
                    shipRigidbody.velocity = defaultDashForce * shipParameters.DashForceFactor * defaultShipSpeed * movementInput;
                    CurrentDashCount = Mathf.Floor(CurrentDashCount - 1);
                    dashCooldownTimer = 0;
                    dashRegenCooldownTimer = 0;
                    IsDashOnReload = NeedReload(CurrentDashCount);
                    if (IsDashOnReload) { dashReloadingTimer = 0; }
                }
            }
            else
            {
                dashCooldownTimer += delta;
            }

            CalculateCurrentValueFromRegen(IsDashOnReload, delta, ref CurrentDashCount, ref dashRegenCooldownTimer, shipParameters.MaxDashCount, shipParameters.DashRegenTime, shipParameters.DashRegenCooldownTime);
        }

        protected virtual void HandleBlocking(bool blockingInput)
        {
            if (!IsBlocking)
            {
                if (blockReloadingTimer < shipParameters.BlockReloadTime)
                {
                    blockReloadingTimer += Time.deltaTime;
                }

                if (blockingInput && blockReloadingTimer >= shipParameters.BlockReloadTime)
                {
                    IsBlocking = true;
                }
            }
            else
            {
                if (blockReloadingTimer >= 0)
                {
                    blockReloadingTimer -= Time.deltaTime / shipParameters.BlockTime;
                }
                else
                {
                    IsBlocking = false;
                }
            }
        }

        public override void ApplyDamage(float damage)
        {
            if (!IsBlocking)
            {
                base.ApplyDamage(damage);
            }
        }

        protected void HandleShooting(float delta)
        {
            CalculateCurrentValueFromReload(delta, ref IsBulletsOnReload, ref bulletsReloadingTimer, ref CurrentBulletsCount, shipParameters.MaxBulletsCount, shipParameters.BulletReloadTime);

            if (HasBulletLaunchers)
            {
                foreach (BulletLauncher bulletLauncher in bulletLaunchers)
                {
                    bulletLauncher.Shoot(this, shipInput.ShootInput);
                    IsBulletsOnReload = NeedReload(CurrentBulletsCount) || IsBulletsOnReload;
                }
            }

            CalculateCurrentValueFromRegen(IsBulletsOnReload, delta, ref CurrentBulletsCount, ref bulletRegenCooldownTimer, shipParameters.MaxBulletsCount, shipParameters.BulletRegenTime, shipParameters.BulletRegenCooldownTime);
        }

        protected virtual void PostTick(float delta) { return; }
        protected virtual void PreTick(float delta) { return; }
        protected virtual void StartAction() { return; }

        private void CalculateCurrentValueFromRegen(bool isOnReload, float delta, ref float currentValue, ref float regenCooldownTimer, int maxValue, float regenTime, float regenCooldownTime)
        {
            if (isOnReload)
            {
                regenCooldownTimer = 0;
                return;
            }

            if (regenCooldownTimer >= regenCooldownTime)
            {
                if (currentValue < maxValue)
                {
                    currentValue += delta * maxValue / regenTime;
                }
                else
                {
                    currentValue = maxValue;
                }
            }
            else
            {
                regenCooldownTimer += delta;
            }
        }

        private void CalculateCurrentValueFromReload(float delta, ref bool isOnReload, ref float reloadTimer, ref float currentValue, int maxValue, float reloadTime)
        {
            if (isOnReload)
            {
                reloadTimer += delta;
                currentValue = (maxValue * reloadTimer / reloadTime);

                if (reloadTimer > reloadTime)
                {
                    isOnReload = false;
                    reloadTimer = 0;
                    currentValue = maxValue;
                }
                return;
            }
        }

        private bool NeedReload(float currentValue) => currentValue <= 0;
    }
}
