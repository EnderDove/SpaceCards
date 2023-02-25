using System.Linq;
using TMPro;
using UnityEngine;

namespace Game
{
    public class Player : Ship
    {
        [SerializeField] private Crosshair attachedCrosshair;
        [SerializeField] private Transform cursor;
        public CameraHandler attachedCameraHandler;
        [SerializeField] private TextMeshProUGUI fpsText;
        [SerializeField] private GameSliders dashCooldownSlider;
        [SerializeField] private GameSliders blockCooldownSlider;
        [SerializeField] private GameSliders healthSlider;
        [SerializeField] private GameSliders bulletCountSlider;

        [SerializeField] private ParticleSystem[] trailsPartycleSystems;
        private ParticleSystem.EmissionModule[] shipTrailEmissions;
        private Vector2 lastSpeed;
        private float[] fpsBuffer = new float[100];

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
            dashCooldownSlider?.Tick(this, CurrentDashCount, shipParameters.MaxDashCount, delta);
            healthSlider?.Tick(this, HealthValue, shipParameters.MaxHealthValue, delta);
            blockCooldownSlider?.Tick(this, blockReloadingTimer / shipParameters.BlockReloadTime, 1, delta);
            bulletCountSlider?.Tick(this, CurrentBulletsCount, shipParameters.MaxBulletsCount, delta);
        }

        protected override void PostTick(float delta)
        {
            attachedCrosshair.Tick(shipInput.GazeLocationInput, shipRigidbody, rotationAngle, shipParameters.SpeedFactor, IsBulletsOnReload, delta);
            cursor.position = shipInput.GazeLocationInput + shipTransform.position;

            for (int i = 0; i < shipTrailEmissions.Length; i++)
            {
                shipTrailEmissions[i].enabled = (shipRigidbody.velocity - lastSpeed).magnitude > 0;
            }
            lastSpeed = shipRigidbody.velocity;
            fpsBuffer = fpsBuffer.Skip(fpsBuffer.Length - 1).Take(1).Concat(fpsBuffer.Take(fpsBuffer.Length - 1)).ToArray();
            fpsBuffer[0] = 1 / delta;
            fpsText.text = Mathf.Round(fpsBuffer.Sum() / 100).ToString();
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
