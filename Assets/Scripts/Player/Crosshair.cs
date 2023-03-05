using UnityEngine;

namespace Game
{
    public class Crosshair : MonoBehaviour
    {
        [SerializeField] private Transform cursor;
        [HideInInspector] public Transform crosshairTransform;

        [SerializeField] private float crosshairMaxDistance = 3f;
        private float zOffset;
        private float partsZOffset = 0.1f;

        private Material crosshairMaterial;
        private Color crosshairColor;

        private Transform crosshairPartLU;
        private Transform crosshairPartRU;
        private Transform crosshairPartLD;
        private Transform crosshairPartRD;

        private void OnEnable()
        {
            crosshairTransform = transform;
            zOffset = crosshairTransform.position.z;
            crosshairMaterial = GetComponent<Renderer>().material;
            crosshairColor = crosshairMaterial.color;

            crosshairPartLU = crosshairTransform.GetChild(0);
            crosshairPartRU = crosshairTransform.GetChild(1);
            crosshairPartLD = crosshairTransform.GetChild(2);
            crosshairPartRD = crosshairTransform.GetChild(3);
        }

        public void Tick(Vector3 gazeLocationInput, Rigidbody2D shipRigidbody, float rotationAngle, float ShipSpeedFactor, bool isBulletsOnReload, float delta)
        {
            crosshairTransform.SetPositionAndRotation(Vector3.ClampMagnitude(gazeLocationInput, crosshairMaxDistance) + new Vector3(shipRigidbody.position.x, shipRigidbody.position.y, zOffset), Quaternion.Euler(0, 0, rotationAngle));
            cursor.position = gazeLocationInput + new Vector3(shipRigidbody.position.x, shipRigidbody.position.y, zOffset);
            cursor.localPosition -= new Vector3(0, 0, partsZOffset);

            float offset = shipRigidbody.velocity.magnitude * 0.2f / ShipSpeedFactor;
            crosshairColor.a = Mathf.MoveTowards(crosshairColor.a, _ = isBulletsOnReload ? 0 : 1, delta);
            crosshairMaterial.color = crosshairColor;

            crosshairPartLU.localPosition = new Vector3(-1, 1) * offset + new Vector3(0,0, -partsZOffset);
            crosshairPartRU.localPosition = new Vector3(1, 1) * offset + new Vector3(0, 0, -partsZOffset);
            crosshairPartLD.localPosition = new Vector3(-1, -1) * offset + new Vector3(0, 0, -partsZOffset);
            crosshairPartRD.localPosition = new Vector3(1, -1) * offset + new Vector3(0, 0, -partsZOffset);
        }
    }
}