using UnityEngine;

namespace AZhelnov.Game.Creature
{
    public class Mover : MonoBehaviour
    {
        private new Rigidbody2D rigidbody;
        private float movementSpeedDifference;
        private float movementSpeed;

        [SerializeField] private float minMovementSpeed;
        [SerializeField] private float maxMovementSpeed;
        [SerializeField] private float movementSpeedChangeSpeed;

        private int maxHealth;
        private HealthController healthController;


        private void Start()
        {
            healthController = GetComponent<HealthController>();
            maxHealth = healthController.MaxHealth;

            movementSpeedDifference = maxMovementSpeed - minMovementSpeed;
            movementSpeed = maxMovementSpeed - (movementSpeedDifference * healthController.Health / maxHealth);

            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            movementSpeed = Mathf.Lerp(
                movementSpeed,
                maxMovementSpeed - (movementSpeedDifference * healthController.Health / maxHealth),
                Time.fixedDeltaTime * movementSpeedChangeSpeed);

            rigidbody.MovePosition(transform.position + transform.up * Time.fixedDeltaTime * movementSpeed);
        }
    }
}
