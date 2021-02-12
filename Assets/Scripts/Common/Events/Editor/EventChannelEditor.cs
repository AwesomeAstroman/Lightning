using UnityEditor;
using UnityEngine;

namespace AZhelnov.Events
{
    [CustomEditor(typeof(EventChannel))]
    public class EventChannelEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUI.enabled = Application.isPlaying;
            EventChannel eventChannel = (EventChannel)target;

            if (GUILayout.Button("Raise Event"))
            {
                eventChannel.RaiseEvent();
            }
        }
    }
}
