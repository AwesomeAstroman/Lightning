using UnityEngine;

namespace AZhelnov.Variables
{
    [CreateAssetMenu]
    public class IntVariable : ScriptableObject
    {
        [SerializeField] private int value;
#if UNITY_EDITOR
        [Multiline]
        public string description;
#endif
        public int Value { get { return value; } }


        public void SetValue(int value)
        {
            this.value = value;
        }

        public void SetValue(IntVariable intVariable)
        {
            this.value = intVariable.Value;
        }

        public void ModifyValue(int amount)
        {
            this.value += amount;
        }

        public void ModifyValue(IntVariable intVariable)
        {
            this.value += intVariable.Value;
        }
    }
}
