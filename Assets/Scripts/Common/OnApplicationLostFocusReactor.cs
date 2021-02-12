using UnityEngine;
using UnityEngine.Events;

namespace AZhelnov.Components
{
    public class OnApplicationLostFocusReactor : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnReacted;


        private void OnApplicationFocus(bool focus)
        {
            if (!focus)
            {
                OnReacted?.Invoke();
            }
        }
    }
}
