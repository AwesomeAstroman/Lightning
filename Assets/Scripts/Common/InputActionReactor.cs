using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace AZhelnov.Components
{
    public class InputActionReactor : MonoBehaviour
    {
        [SerializeField] private InputAction inputAction;
        [SerializeField] private UnityEvent OnPerformed;


        public void Awake()
        {
            inputAction.performed +=
                ctx =>
            {
                OnPerformed?.Invoke();
            };
        }

        public void OnEnable()
        {
            inputAction.Enable();
        }

        public void OnDisable()
        {
            inputAction.Disable();
        }
    }
}
