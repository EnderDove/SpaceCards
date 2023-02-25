using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameSliders : MonoBehaviour
    {
        public bool isAttachedToShip;
        private Image backgroundImage;
        private Image fillerImage;
        private Image filler2Image;
        private RectTransform sliderRectTransform;
        private Vector3 defaultScale;
        private Vector3 defaultPosition;

        private void OnEnable()
        {
            sliderRectTransform = GetComponent<RectTransform>();
            defaultScale = sliderRectTransform.localScale;
            defaultPosition = sliderRectTransform.localPosition;
            GameObject sliderFiller = sliderRectTransform.GetChild(1).gameObject;
            GameObject sliderFiller2 = sliderRectTransform.GetChild(0).gameObject;
            backgroundImage = GetComponent<Image>();
            fillerImage = sliderFiller.GetComponent<Image>();
            filler2Image = sliderFiller2.GetComponent<Image>();
        }

        public void Tick(Player player, float value, float maxValue, float delta)
        {
            float temporalValue = value / maxValue;
            fillerImage.fillAmount = Mathf.Floor(value) / maxValue;
            filler2Image.fillAmount = temporalValue;
            backgroundImage.fillAmount = 1 - temporalValue;

            if (isAttachedToShip)
            {
                Vector2 playerPosOnScreen = player.attachedCameraHandler.mainCamera.WorldToScreenPoint(player.shipTransform.position);
                sliderRectTransform.localScale = defaultScale / player.attachedCameraHandler.ScaleFactor;
                sliderRectTransform.position = playerPosOnScreen;
                sliderRectTransform.localPosition += defaultPosition / player.attachedCameraHandler.ScaleFactor;
            }
        }
    }
}