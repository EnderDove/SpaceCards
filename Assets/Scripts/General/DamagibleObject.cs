using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class DamagibleObject : MonoBehaviour
    {
        public float HealthValue { get; protected set; }

        [SerializeField] private ParticleSystem DeathParticles;

        public virtual void ApplyDamage(float damage)
        {
            if (damage < 0) { throw new System.IndexOutOfRangeException(); }
            HealthValue -= damage;
            if (HealthValue <= 0) { OnHealthEnd(); }
        }

        protected virtual void OnHealthEnd()
        {
            DeathParticles.gameObject.SetActive(true);
            DeathParticles.transform.parent = null;
            DeathParticles.Play();
            gameObject.SetActive(false);
            Invoke(nameof(DeleteObject), 2);
        }

        protected virtual void DeleteObject()
        {
            Destroy(DeathParticles.gameObject);
            Destroy(gameObject);
        }
    }
}
