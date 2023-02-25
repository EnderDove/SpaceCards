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
        private ParticleSystem shootParticles;
        private Light shootLight;

        private float shootTimer = 0;

        private void Start()
        {
            attachedShip = GetComponentInParent<Ship>();
            shootParticles = GetComponentInChildren<ParticleSystem>();
            shootLight = GetComponentInChildren<Light>();
            shootLight.enabled = false;
        }

        public void Shoot(Ship ship, bool inp)
        {
            if (shootTimer > attachedShip.shipParameters.ShootInterval)
            {
                if (inp && !ship.IsBulletsOnReload)
                {
                    bulletPool.Get();
                    ship.CurrentBulletsCount = Mathf.Floor(ship.CurrentBulletsCount - 1);
                    ship.bulletRegenCooldownTimer = 0;
                    shootTimer = 0;
                    shootParticles.Play();
                    shootLight.color = attachedShip.shipParameters.BulletColor;
                    shootLight.enabled = true;
                }

            }
            else
            {
                shootTimer += Time.deltaTime;
                if (shootTimer > Mathf.Min(0.1f, attachedShip.shipParameters.ShootInterval))
                {
                    shootLight.enabled = false;
                }
            }
        }

        #region Bullet Pool
        private void TakeBulletFromPool(Bullet curentBullet)
        {
            curentBullet.gameObject.SetActive(true);
            curentBullet.BulletSpriteRenderer.enabled = true;
            curentBullet.Launch();
            curentBullet.BulletTrail.emitting = true;
            curentBullet.BulletTrail.Clear();
        }

        private void ReturnBulletToPool(Bullet curentBullet)
        {
            curentBullet.BulletTrail.emitting = false;
            curentBullet.gameObject.SetActive(false);
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
