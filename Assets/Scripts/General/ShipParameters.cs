using UnityEngine;

namespace Game
{
    public class ShipParameters : MonoBehaviour
    {
        [Header("Ship Movement")]
        public float SpeedFactor = 1f;
        public float AccelerationFactor = 1f;

        [Header("Shooter")]
        public int MaxBulletsCount = 5;
        public float ShootInterval = 0.5f;
        public float BulletReloadTime = 5f;
        public float BulletRegenTime = 5f;
        public float BulletRegenCooldownTime = 1f;
        public float SpreedValue = 0.1f;

        [Header("Dash")]
        public int MaxDashCount = 1;
        public float DashInterval = 0.2f;
        public float DashReloadTime = 1f;
        public float DashRegenTime = 1f;
        public float DashRegenCooldownTime = 0.5f;
        public float DashForceFactor = 1f;

        [Header("Blocking")]
        public float BlockTime = 2f;
        public float BlockReloadTime = 2f;

        [Header("Bullet Parametrs")]
        public Color BulletColor = Color.yellow;
        public float BulletRadius = 0.1f;
        public float BulletLaunchSpeed = 7f;
        public float BulletDamage = 34f;
    }
}
