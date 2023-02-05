using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class BulletLauncher : MonoBehaviour
    {
        [SerializeField] private Transform ParentForBullets;
        public Bullet bullet;
        private ObjectPool<Bullet> bulletPool;

        public Player attachedPlayer;

        [SerializeField] private float shootTime = 0.1f;
        private float shootTimer = 0;

        private void OnBulletColision(Collision2D collision ,Bullet bullet)
        {
            bulletPool.Release(bullet);
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
            Debug.Log(bulletPool.CountAll);
        }

        #region Bullet Pool
        private void TakeBulletFromPool(Bullet curentBullet)
        {
            curentBullet.BulletSpriteRenderer.enabled = true;
            curentBullet.Launch();
            curentBullet.BulletParticleSystem.enableEmission = true;
        }

        private void ReturnBulletToPool(Bullet curentBullet)
        {
            curentBullet.BulletSpriteRenderer.enabled = false;
            curentBullet.BulletParticleSystem.enableEmission = false;
            curentBullet.BulletRigidbody.simulated = false;
        }

        private Bullet CreateBullet()
        {
            Bullet curentBullet = Instantiate(bullet, transform);
            curentBullet.SetPool(bulletPool);

            curentBullet.BulletObject = curentBullet.gameObject;
            curentBullet.BulletLauncher = this;
            curentBullet.BulletRigidbody = curentBullet.BulletObject.GetComponent<Rigidbody2D>();
            curentBullet.BulletSpriteRenderer = curentBullet.BulletObject.GetComponent<SpriteRenderer>();
            curentBullet.BulletParticleSystem = curentBullet.BulletObject.GetComponent<ParticleSystem>();
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