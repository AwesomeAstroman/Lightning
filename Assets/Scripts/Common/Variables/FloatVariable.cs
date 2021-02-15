using UnityEngine;

namespace AZhelnov.Variables
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float value;
#if UNITY_EDITOR
        [TextArea] [SerializeField] protected string description;
#endif
        public float Value { get { return value; } }


        public void SetValue(float value)
        {
            this.value = value;
        }

        public void SetValue(FloatVariable floatVariable)
        {
            this.value = floatVariable.Value;
        }

        public void ModifyValue(float amount)
        {
            this.value += amount;
        }

        public void ModifyValue(FloatVariable floatVariable)
        {
            this.value += floatVariable.Value;
        }
    }
}
