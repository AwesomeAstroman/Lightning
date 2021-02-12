using UnityEngine;

namespace AZhelnov.Game.Creature
{
    [RequireComponent(typeof(HealthController))]
    public class DamageNumberSpawner : MonoBehaviour
    {
        private HealthController healthController;

        [SerializeField] DamageNumbersPool damageNumbersPool;


        private void Awake()
        {
            healthController = GetComponent<HealthController>();
        }

        private void OnEnable()
        {
            healthController.OnDamageApplied += SpawnDamageNumber;
        }

        private void OnDisable()
        {
            healthController.OnDamageApplied -= SpawnDamageNumber;
        }

        private void SpawnDamageNumber(int amount)
        {
            DamageNumber damageNumber = damageNumbersPool.Take();
            damageNumber.transform.position = transform.position;
            damageNumber.Setup(amount);
            damageNumber.gameObject.SetActive(true);
        }
    }
}