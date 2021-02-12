using System.Collections.Generic;
using UnityEngine;

namespace AZhelnov.Game
{
    [CreateAssetMenu(menuName = "Pools/Damage Numbers Pool")]
    public class DamageNumbersPool : ScriptableObject
    {
        private Stack<DamageNumber> damageNumbers;
        private Transform parent;

        [SerializeField] private DamageNumber prefab;
        [SerializeField] private int amount;


        public void Spawn()
        {
            damageNumbers = new Stack<DamageNumber>();

            if (!parent)
            {
                parent = new GameObject(name).transform;
            }

            while (damageNumbers.Count < amount)
            {
                DamageNumber newDamageNumber = Instantiate(prefab, parent);
                newDamageNumber.gameObject.SetActive(false);
                damageNumbers.Push(newDamageNumber);
            }
        }

        public DamageNumber Take()
        {
            if (damageNumbers == null || damageNumbers.Count == 0)
            {
                Spawn();
            }

            return damageNumbers.Pop();
        }

        internal void Return(DamageNumber damageNumber)
        {
            damageNumber.gameObject.SetActive(false);
            damageNumbers.Push(damageNumber);
        }
    }
}
