using UnityEngine;

namespace AZhelnov.Game
{
    public class DamageNumbersPoolSpawner : MonoBehaviour
    {
        [SerializeField] private DamageNumbersPool damageNumbersPool;


        void Awake()
        {
            damageNumbersPool.Spawn();
        }
    }
}
