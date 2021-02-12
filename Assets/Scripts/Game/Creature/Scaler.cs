using UnityEngine;

namespace AZhelnov.Game.Creature
{
    public class Scaler : MonoBehaviour
    {
        private float scaleDifference;
        private int maxHealth;

        [SerializeField] private float minScale;
        [SerializeField] private float maxScale;
        [SerializeField] private float scaleChangeSpeed;
        [SerializeField] private float maxScaleModyfier;

        private HealthController healthController;


        private void Start()
        {
            healthController = GetComponent<HealthController>();
            maxHealth = healthController.MaxHealth;
            maxScale += Random.Range(0.0f, maxScaleModyfier);
            scaleDifference = maxScale - minScale;
            transform.localScale = Vector3.one * ((scaleDifference * healthController.Health / maxHealth) + minScale);
        }

        private void Update()
        {
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                Vector3.one * ((scaleDifference * healthController.Health / maxHealth) + minScale),
                Time.deltaTime * scaleChangeSpeed);
        }
    }
}
