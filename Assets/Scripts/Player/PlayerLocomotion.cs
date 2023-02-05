using UnityEngine;

namespace Game
{
    public class PlayerLocomotion : MonoBehaviour
    {
        [SerializeField] private Transform crosshairTransform;
        [SerializeField] private float speed = 5;
        [SerializeField] private float DashTime = 2;

        private float dashTimer = 0;

        private float angleToCrosshair;

        public void HandlePlayerMovement(Vector2 movementInput, Vector3 crosshairPosition, Transform playerTransform, Rigidbody2D playerRigidbody)
        {
            crosshairTransform.position = crosshairPosition + playerTransform.position;

            playerRigidbody.velocity = Vector2.MoveTowards(playerRigidbody.velocity, movementInput * speed , 0.1f);
            Vector2 toCrosshair = new(crosshairPosition.x, crosshairPosition.y);
            float _lastAngle = angleToCrosshair;
            angleToCrosshair = Vector2.Angle(toCrosshair, Vector2.up);
            if (Vector2.Angle(toCrosshair, Vector2.right) <= 90)
            {
                angleToCrosshair = -angleToCrosshair + 360;
            }
            if (Mathf.Abs(_lastAngle - angleToCrosshair) >= 300) { _lastAngle = angleToCrosshair; }
            angleToCrosshair = Mathf.MoveTowards(_lastAngle, angleToCrosshair, 720 * Time.deltaTime);
            playerTransform.rotation = Quaternion.Euler(0, 0, angleToCrosshair);
        }

        public void HandleDash(bool dashInput, Vector2 movementInput, Rigidbody2D playerRigidbody)
        {
            if (dashTimer > DashTime)
            {
                if (dashInput && movementInput.magnitude > 0)
                {
                    playerRigidbody.position += movementInput * 2;
                    playerRigidbody.velocity = movementInput * speed;
                    dashTimer = 0;
                }
            }
            else
            {
                dashTimer += Time.deltaTime;
            }
        }
    }
}