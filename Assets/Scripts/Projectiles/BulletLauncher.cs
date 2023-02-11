using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class BulletLauncher : MonoBehaviour
    {
        [SerializeField] private Transform ParentForBullets;
        public Bullet bullet;
        private ObjectPool<Bullet> bulletPool;

        [HideInInspector] public Ship attachedShip;
        public float shootTime = 0.1f;

        private float shootTimer = 0;

        private void Start()
        {
            attachedShip = GetComponentInParent<Ship>();
        }

        public void Shoot(bool inp)
        {
            if (shootTimer > shootTime)
            {
                if (inp)
                {
                    bulletPool.Get();
                    shootTimer = 0;
                }

            }
            else
            {
                shootTimer += Time.deltaTime;
            }
        }

        #region Bullet Pool
        private void TakeBulletFromPool(Bullet curentBullet)
        {
            curentBullet.BulletSpriteRenderer.enabled = true;
            curentBullet.Launch();
            curentBullet.BulletTrail.emitting = true;
            curentBullet.BulletTrail.Clear();
        }

        private void ReturnBulletToPool(Bullet curentBullet)
        {
            curentBullet.BulletTrail.emitting = false;
        }

        private Bullet CreateBullet()
        {
            Bullet curentBullet = Instantiate(bullet, transform);
            curentBullet.SetPool(bulletPool);

            curentBullet.BulletObject = curentBullet.gameObject;
            curentBullet.BulletLauncher = this;
            curentBullet.BulletRigidbody = curentBullet.BulletObject.GetComponent<Rigidbody2D>();
            curentBullet.BulletSpriteRenderer = curentBullet.BulletObject.GetComponent<SpriteRenderer>();
            curentBullet.BulletTrail = curentBullet.BulletObject.GetComponent<TrailRenderer>();
            curentBullet.ParentTransform = ParentForBullets;

            return curentBullet;
        }

        private void OnEnable()
        {
            bulletPool = new ObjectPool<Bullet>(CreateBullet, TakeBulletFromPool, ReturnBulletToPool);
        }
        #endregion
    }
}
