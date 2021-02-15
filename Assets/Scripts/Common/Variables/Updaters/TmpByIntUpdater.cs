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
            if (update && variable.Value != previousValue)
            {
                UpdateText();
            }
        }

        private void UpdateText()
        {
            textMeshPro.SetText(format, variable.Value);
            previousValue = variable.Value;
        }
    }
}
