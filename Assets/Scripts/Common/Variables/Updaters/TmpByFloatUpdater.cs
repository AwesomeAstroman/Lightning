using TMPro;
using UnityEngine;

namespace AZhelnov.Variables
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TmpByFloatUpdater : MonoBehaviour
    {
        private TextMeshProUGUI textMeshPro;

        [SerializeField] private FloatVariable variable;
        [SerializeField] private string format = "Value: {0:2}";
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
            textMeshPro.SetText(format, variable.Value % 1000);
        }
    }
}
