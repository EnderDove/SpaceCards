using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class DamagibleObject : MonoBehaviour
    {
        private float healthValue;
        [SerializeField] protected float maxHealthValue = 100;

        public float HealthValue => healthValue;
        public float MaxHealthValue => maxHealthValue;

        [SerializeField] private GameObject Explosion;
        private GameObject explosionInstance;

        private void OnEnable()
        {
            healthValue = maxHealthValue;
        }

        public virtual void ApplyDamage(float damage)
        {
            if (damage < 0) { throw new System.IndexOutOfRangeException(); }
            healthValue -= damage;
            if (healthValue <= 0) { OnHealthEnd(); }
        }

        protected virtual void OnHealthEnd()
        {
            explosionInstance = Instantiate(Explosion, null);
            explosionInstance.transform.position = transform.position;
            explosionInstance.SetActive(true);
            explosionInstance.GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);
            Invoke(nameof(DeleteObject), 2);
        }

        protected virtual void DeleteObject()
        {
            Destroy(explosionInstance);
            Destroy(gameObject);
        }
    }
}
