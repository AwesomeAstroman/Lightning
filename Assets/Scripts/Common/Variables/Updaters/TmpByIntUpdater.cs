using TMPro;
using UnityEngine;

namespace AZhelnov.Variables
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TmpByIntUpdater : MonoBehaviour
    {
        private TextMeshProUGUI textMeshPro;
        private int previousValue;

        [SerializeField] private IntVariable variable;
        [SerializeField] private string format = "Value: {0}";
        [SerializeField] private bool update = true;


        private void Start()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
            UpdateText();
        }

        private void Update()
        {
            if (update)
            {
                UpdateText();
            }
        }

        private void UpdateText()
        {
            if (variable.value != previousValue)
            {
                textMeshPro.SetText(format, variable.value);
                previousValue = variable.value;
            }
        }
    }
}
