using UnityEngine;
using UnityEngine.Events;

namespace AZhelnov.Events
{
    [CreateAssetMenu(menuName = "Events/Event Channel")]
    public class EventChannel : EventChannelBase
    {
        public UnityAction OnEventRaised;


        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();
        }
    }
}
