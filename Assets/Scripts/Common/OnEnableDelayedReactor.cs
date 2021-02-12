using UnityEngine;
using UnityEngine.Events;

namespace AZhelnov.Components
{
    public class OnEnableDelayedReactor : MonoBehaviour
    {
        [SerializeField] private float seconds = 0.5f;
        [SerializeField] private UnityEvent OnReacted;


        private void OnEnable()
        {
            Invoke(nameof(React), seconds);
        }

        private void React()
        {
            OnReacted?.Invoke();
        }
    }
}
