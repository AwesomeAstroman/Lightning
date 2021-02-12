using UnityEngine;

namespace AZhelnov.Variables
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string description;
#endif
        public float value;


        public void SetValue(float value)
        {
            this.value = value;
        }

        public void SetValue(FloatVariable value)
        {
            this.value = value.value;
        }

        public void ModifyValue(float amount)
        {
            this.value += amount;
        }

        public void ModifyValue(FloatVariable amount)
        {
            this.value += amount.value;
        }
    }
}
