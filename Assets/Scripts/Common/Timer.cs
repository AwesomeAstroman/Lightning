using AZhelnov.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace AZhelnov.Game
{
    public class Timer : MonoBehaviour
    {
        private bool update = true;
        
        [SerializeField] private FloatVariable remainingTime;
        [SerializeField] private float seconds;
        [SerializeField] private UnityEvent OnTimeOut;


        private void Start()
        {
            remainingTime.SetValue(seconds);
        }

        void Update()
        {
            if (update)
            {
                remainingTime.SetValue(Mathf.Clamp(remainingTime.Value - Time.deltaTime, 0, seconds));

                if (remainingTime.Value == 0)
                {
                    OnTimeOut?.Invoke();
                }
            }
        }

        public void Pause()
        {
            update = false;
        }

        public void Resume()
        {
            update = true;
        }
    }
}
