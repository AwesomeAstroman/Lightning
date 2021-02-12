using System;
using UnityEngine;

namespace AZhelnov.Game
{
    public class TriggerDamager : MonoBehaviour
    {
        [SerializeField] private int minDamage;
        [SerializeField] private int maxDamage;

        public static event Action<GameObject, int> OnDamageInflicted = delegate { };


        private void OnTriggerStay2D(Collider2D collision)
        {
            OnDamageInflicted?.Invoke(collision.transform.gameObject, UnityEngine.Random.Range(minDamage, maxDamage + 1));
        }
    }
}
