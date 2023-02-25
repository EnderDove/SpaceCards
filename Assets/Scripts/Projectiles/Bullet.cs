using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        public Transform ParentTransform;
        public GameObject BulletObject;
        public Rigidbody2D BulletRigidbody;
        public BulletLauncher BulletLauncher;
        public TrailRenderer BulletTrail;
        public SpriteRenderer BulletSpriteRenderer;
        public ParticleSystem burstParticleSystem;

        private HashSet<Collision2D> collisions = new();

        private Color bulletColor = Color.yellow;
        private float bulletRadius = 0.1f;
        private float bulletLaunchSpeed = 7f;
        private float bulletDamage = 34;
        private float bulletFlightTime;
        private float spreedValue = 0.1f;
        private bool isLaunched = false;

        #region ObjectPool
        private IObjectPool<Bullet> _pool;
        public void SetPool(IObjectPool<Bullet> _bulletPool) => _pool = _bulletPool;

        private void ReturnBullet()
        {
            _pool.Release(this);
        }
        #endregion

        private void FixedUpdate()
        {
            if (isLaunched)
            {
                bulletFlightTime += Time.deltaTime;
                if (bulletFlightTime >= 10f)
                {
                    EndBulletLife();
                }
            }
        }

        public virtual void EndBulletLife()
        {
            if (!isLaunched)
            {
                return;
            }
            isLaunched = false;
            bulletFlightTime = 0;
            BulletRigidbody.simulated = false;
            BulletSpriteRenderer.enabled = false;
            Invoke(nameof(ReturnBullet), BulletTrail.time);
        }

        public void Launch()
        {
            #region Set Bullet Parametrs
            bulletColor = BulletLauncher.attachedShip.shipParameters.BulletColor;
            bulletRadius = BulletLauncher.attachedShip.shipParameters.BulletRadius;
            bulletLaunchSpeed = BulletLauncher.attachedShip.shipParameters.BulletLaunchSpeed;
            bulletDamage = BulletLauncher.attachedShip.shipParameters.BulletDamage;
            spreedValue = BulletLauncher.attachedShip.shipParameters.SpreedValue;

            #endregion
            BulletRigidbody.simulated = true;
            BulletObject.transform.parent = ParentTransform;
            BulletObject.transform.position = BulletLauncher.transform.position;
            BulletObject.transform.localScale = Vector3.one * bulletRadius;
            burstParticleSystem = GetComponent<ParticleSystem>();

            BulletSpriteRenderer.color = bulletColor;
            BulletTrail.material.color = bulletColor;
            burstParticleSystem.startColor = bulletColor;
            BulletTrail.widthMultiplier = bulletRadius;
            Vector2 velocity = new Vector2((BulletLauncher.transform.up * bulletLaunchSpeed).x, (BulletLauncher.transform.up * bulletLaunchSpeed).y) + BulletLauncher.attachedShip.shipRigidbody.velocity / 2;
            velocity += Random.Range(-1f, 1f) * spreedValue * BulletLauncher.attachedShip.shipRigidbody.velocity / BulletLauncher.attachedShip.shipParameters.SpeedFactor * new Vector2(BulletLauncher.attachedShip.shipTransform.right.x, BulletLauncher.attachedShip.shipTransform.right.y);

            BulletRigidbody.velocity = velocity;
            BulletTrail.time = 1 / velocity.magnitude;

            collisions.Clear();
            isLaunched = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                BulletTrail.time = 1 / BulletRigidbody.velocity.magnitude;
                burstParticleSystem.Play();
                return;
            }

            collisions.Add(collision);

            if (collision.gameObject.CompareTag("Ship"))
            {
                if (bulletFlightTime > 0.1f)
                {
                    if (collision.gameObject.TryGetComponent(out DamagibleObject gameObj))
                    {
                        gameObj.ApplyDamage(bulletDamage);
                    }
                    burstParticleSystem.Play();
                    EndBulletLife();
                }
            }
            else
            {
                burstParticleSystem.Play();
                EndBulletLife();
            }
        }

    }
}
