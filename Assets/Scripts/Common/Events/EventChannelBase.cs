using UnityEngine;

namespace AZhelnov.Events
{
    public class EventChannelBase : ScriptableObject
    {
        [TextArea] [SerializeField] private string description;
    }
}
