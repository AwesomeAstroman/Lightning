using System;
using UnityEngine;
using UnityEngine.Events;

namespace AZhelnov.Game.Creature
{
    public class HealthController : MonoBehaviour
    {
        private int health;

        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent OnDeath;

        public int Health { get { return health; } }
        public int MaxHealth { get { return maxHealth; } }

        public event Action<int> OnDamageApplied = delegate { };


        private void Awake()
        {
            health = maxHealth;
        }

        private void OnEnable()
        {
            LightningController.OnDamageInflicted += ApplyDamage;
            TriggerDamager.OnDamageInflicted += ApplyDamage;
        }

        private void OnDisable()
        {
            LightningController.OnDamageInflicted -= ApplyDamage;
            TriggerDamager.OnDamageInflicted -= ApplyDamage;
        }

        private void ApplyDamage(GameObject gameObject, int amount)
        {
            if (gameObject == this.gameObject)
            {
                health -= amount;
                OnDamageApplied?.Invoke(amount);

                if (health <= 0)
                {
                    OnDeath?.Invoke();
                    Destroy(gameObject);
                }
            }
        }
    }
}
