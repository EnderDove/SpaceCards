using UnityEngine;

namespace Game
{
    public class Crosshair : MonoBehaviour
    {
        [SerializeField] private float crosshairMaxDistance = 3f;
        [HideInInspector] public Transform crosshairTransform;
        private Material crosshairMaterial;
        private Color crosshairColor;

        private Transform crosshairPartLU;
        private Transform crosshairPartRU;
        private Transform crosshairPartLD;
        private Transform crosshairPartRD;

        private void OnEnable()
        {
            crosshairTransform = transform;
            crosshairMaterial = GetComponent<Renderer>().material;
            crosshairColor = crosshairMaterial.color;

            crosshairPartLU = crosshairTransform.GetChild(0);
            crosshairPartRU = crosshairTransform.GetChild(1);
            crosshairPartLD = crosshairTransform.GetChild(2);
            crosshairPartRD = crosshairTransform.GetChild(3);
        }

        public void Tick(Vector3 gazeLocationInput, Rigidbody2D shipRigidbody, float rotationAngle, float ShipSpeedFactor, bool isBulletsOnReload, float delta)
        {
            crosshairTransform.SetPositionAndRotation(Vector3.ClampMagnitude(gazeLocationInput, crosshairMaxDistance) + new Vector3(shipRigidbody.position.x, shipRigidbody.position.y, -1), Quaternion.Euler(0, 0, rotationAngle));

            float offset = shipRigidbody.velocity.magnitude * 0.2f / ShipSpeedFactor;
            crosshairColor.a = Mathf.MoveTowards(crosshairColor.a, _ = isBulletsOnReload ? 0 : 1, delta);
            crosshairMaterial.color = crosshairColor;

            crosshairPartLU.localPosition = new Vector2(-1, 1) * offset;
            crosshairPartRU.localPosition = new Vector2(1, 1) * offset;
            crosshairPartLD.localPosition = new Vector2(-1, -1) * offset;
            crosshairPartRD.localPosition = new Vector2(1, -1) * offset;
        }
    }
}