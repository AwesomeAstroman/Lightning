using UnityEngine;
using UnityEngine.Events;

namespace AZhelnov.Events
{
    public class EventChannelListener : MonoBehaviour
    {
        [SerializeField] private EventChannel eventChannel;
        public UnityEvent OnEventRaised;


        private void OnEnable()
        {
            if (eventChannel != null)
            {
                eventChannel.OnEventRaised += Respond;
            }
        }

        private void OnDisable()
        {
            if (eventChannel != null)
            {
                eventChannel.OnEventRaised -= Respond;
            }
        }

        private void Respond()
        {
            OnEventRaised?.Invoke();
        }
    }
}
