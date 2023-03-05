using System.Linq;
using TMPro;
using UnityEngine;

namespace Game
{
    public class Player : Ship
    {
        [SerializeField] private Crosshair attachedCrosshair;
        public CameraHandler attachedCameraHandler;
        [SerializeField] private GameSliders dashCooldownSlider;
        [SerializeField] private GameSliders blockCooldownSlider;
        [SerializeField] private GameSliders healthSlider;
        [SerializeField] private GameSliders bulletCountSlider;

        [SerializeField] private ParticleSystem[] trailsPartycleSystems;
        private ParticleSystem.EmissionModule[] shipTrailEmissions;
        private Vector2 lastSpeed;

        protected override void StartAction()
        {
            Cursor.visible = false;
            shipTrailEmissions = new ParticleSystem.EmissionModule[trailsPartycleSystems.Length];
            for (int x = 0; x < trailsPartycleSystems.Length; x++)
            {
                shipTrailEmissions[x] = trailsPartycleSystems[x].emission;
            }
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;

            attachedCameraHandler.Tick(this, attachedCrosshair.crosshairTransform.position - shipTransform.position, Time.fixedDeltaTime);
            dashCooldownSlider.Tick(this, CurrentDashCount, shipParameters.MaxDashCount, delta);
            blockCooldownSlider.Tick(this, blockReloadingTimer / shipParameters.BlockReloadTime, 1, delta);
            bulletCountSlider.Tick(this, CurrentBulletsCount, shipParameters.MaxBulletsCount, delta);
            healthSlider.Tick(this, HealthValue, MaxHealthValue, Time.deltaTime);
        }

        protected override void PostTick(float delta)
        {
            attachedCrosshair.Tick(shipInput.GazeLocationInput, shipRigidbody, RotationAngle, shipParameters.SpeedFactor, IsBulletsOnReload, delta);

            for (int i = 0; i < shipTrailEmissions.Length; i++)
            {
                shipTrailEmissions[i].enabled = (shipRigidbody.velocity - lastSpeed).magnitude > 0.1f;
            }
        }

        private void OnDisable()
        {
            attachedCrosshair.gameObject.SetActive(false);
            dashCooldownSlider.gameObject.SetActive(false);
            blockCooldownSlider.gameObject.SetActive(false);
            healthSlider.gameObject.SetActive(false);
            bulletCountSlider.gameObject.SetActive(false);
        }
    }
}
