using UnityEngine;

namespace Game
{
    public class CameraHandler : MonoBehaviour
    {
        public Camera mainCamera;
        protected Transform cameraTransform;

        [SerializeField] private float defaultCameraOffset = 10f;
        [SerializeField] private float cameraSmoothing = 0.5f;
        public float ScaleFactor { get; private set; } = 1;

        private void Start()
        {
            cameraTransform = transform;
            mainCamera = GetComponentInChildren<Camera>();
        }

        public void Tick(Player attachedPlayer, Vector2 crosshairPosition, float delta)
        {
            HandleCameraMovement(attachedPlayer, crosshairPosition, delta);
        }

        public void HandleCameraMovement(Player attachedPlayer, Vector2 crosshairPosition, float delta)
        {
            ScaleFactor = Mathf.Lerp(ScaleFactor, 1 + (attachedPlayer.shipInput.MovementInput * 0.5f).magnitude, delta * 0.1f);
            mainCamera.orthographicSize = 5 * ScaleFactor;
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, attachedPlayer.shipTransform.position + new Vector3(crosshairPosition.x / 2, crosshairPosition.y / 2, -defaultCameraOffset), delta / cameraSmoothing);
        }
    }
}