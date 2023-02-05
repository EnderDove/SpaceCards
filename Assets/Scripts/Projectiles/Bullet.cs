using System;
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
        public ParticleSystem BulletParticleSystem;
        public SpriteRenderer BulletSpriteRenderer;

        private Collision2D[] collisions;

        private Color bulletColor = Color.yellow;
        private float bulletRadius = 0.1f;
        private float bulletLaunchSpeed = 7f;
        private float bulletDamage = 34f;
        private float bulletFlightTime;
        private bool isLaunched = false;


        private Action<Collision2D, Bullet> onCollisionEnterAction;

        #region ObjectPool
        private IObjectPool<Bullet> _pool;
        public void SetPool(IObjectPool<Bullet> _bulletPool) => _pool = _bulletPool;
        #endregion

        private void Update()
        {
            if (isLaunched)
            {
                bulletFlightTime += Time.deltaTime;
                if (bulletFlightTime >= 10f)
                {
                    _pool.Release(this);
                    isLaunched = false;
                    bulletFlightTime = 0;
                }
            }
        }

        public void Bullet—hangeParams(Color _bulletColor, float _bulletRadius, float _bulletLaunchSpeed, float _bulletDamage, Action<Collision2D, Bullet> _onCollisionEnterAction)
        {
            bulletColor = _bulletColor;
            bulletRadius = _bulletRadius;
            bulletLaunchSpeed = _bulletLaunchSpeed;
            bulletDamage = _bulletDamage;
            onCollisionEnterAction = _onCollisionEnterAction;
        }

        public void Launch()
        {
            BulletRigidbody.simulated = true;
            BulletObject.transform.parent = ParentTransform;
            BulletObject.transform.position = BulletLauncher.transform.position;
            BulletObject.transform.localScale = Vector3.one * bulletRadius;

            BulletSpriteRenderer.color = bulletColor;
            BulletParticleSystem.startColor = bulletColor;
            BulletRigidbody.velocity = new Vector2((BulletLauncher.transform.up * bulletLaunchSpeed).x, (BulletLauncher.transform.up * bulletLaunchSpeed).y) + BulletLauncher.attachedPlayer.playerRigidbody.velocity;

            isLaunched = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Bullet bullet))
            {
                return;
            }
            if (bulletFlightTime > 0)
            {
                _pool.Release(this);
                isLaunched = false;
                bulletFlightTime = 0;
                onCollisionEnterAction?.Invoke(collision, this);
            }
        }

    }
}
