using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Player : Ship
    {
        [SerializeField] private float crosshairMaxDistance = 3f;

        [SerializeField] private Transform crosshairTransform;
        [SerializeField] private CameraHandler attachedCameraHandler;
        [SerializeField] private GameObject dashCooldownSlider;

        [SerializeField] private Image dashCooldownSliderFiller;
        [SerializeField] private Image dashCooldownSliderBackground;
        [SerializeField] private RectTransform dashCooldownSliderTransform;

        protected override void StartAction()
        {
            #region DashSlider
            GameObject sliderFiller = dashCooldownSlider.transform.GetChild(0).gameObject;
            dashCooldownSliderBackground = dashCooldownSlider.GetComponent<Image>();
            dashCooldownSliderFiller = sliderFiller.GetComponent<Image>();
            dashCooldownSliderTransform = dashCooldownSlider.GetComponent<RectTransform>();
            #endregion
        }

        private void FixedUpdate()
        {
            attachedCameraHandler.Tick(this, crosshairTransform.position - shipTransform.position, Time.fixedDeltaTime);
        }

        protected override void PostTick()
        {
            Vector2 playerPos = attachedCameraHandler.mainCamera.WorldToScreenPoint(shipTransform.position);
            crosshairTransform.position = Vector3.ClampMagnitude(shipInput.GazeLocationInput, crosshairMaxDistance) + shipTransform.position - Vector3.forward;

            dashCooldownSliderFiller.fillAmount = dashTimer / DashTime;
            dashCooldownSliderBackground.fillAmount = 1 - dashTimer / DashTime;

            dashCooldownSliderTransform.position = playerPos;
            dashCooldownSliderTransform.localScale = Vector3.one / attachedCameraHandler.ScaleFactor;
        }
    }
}
