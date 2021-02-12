using UnityEngine;

namespace AZhelnov.Variables
{
    [CreateAssetMenu]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string description;
#endif
        public int value;


        public void SetValue(int value)
        {
            this.value = value;
        }

        public void SetValue(IntVariable value)
        {
            this.value = value.value;
        }

        public void ModifyValue(int amount)
        {
            this.value += amount;
        }

        public void ModifyValue(IntVariable amount)
        {
            this.value += amount.value;
        }
    }
}
