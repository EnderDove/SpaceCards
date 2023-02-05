using UnityEngine;

namespace Game
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float cameraSmoothing = 1f;
        [SerializeField] private float offset = 10f;

        public void HandleCameraMovement(Player attachedPlayer, Vector2 gazeLocation, Transform cameraTransform, float delta)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, attachedPlayer.playerTransform.position + new Vector3(gazeLocation.x/2, gazeLocation.y/2, -offset), delta * cameraSmoothing);
        }
    }
}
