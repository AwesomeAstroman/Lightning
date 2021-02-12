using System.Collections;
using UnityEngine;

namespace AZhelnov.Game.Creature
{
    public class Rotator : MonoBehaviour
    {
        private float newRotationZ;
        private bool turnable = true;
        private readonly float turnTimeout = 0.5f;
        private float turnTimePass;

        [SerializeField] private float maxAngle;
        [SerializeField] private float directionChangeSpeed;
        [SerializeField] private float minSecondsToChangeDirection;
        [SerializeField] private float maxSecondToChangeDirection;

        [SerializeField] private string colliderTagToTurnBack;


        private void Start()
        {
            newRotationZ = transform.eulerAngles.z + Random.Range(-maxAngle, maxAngle);
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, newRotationZ));
            StartCoroutine(AlterDirection());
        }

        IEnumerator AlterDirection()
        {
            while (true)
            {
                newRotationZ = transform.eulerAngles.z + Random.Range(-maxAngle, maxAngle);
                yield return new WaitForSeconds(Random.Range(minSecondsToChangeDirection, maxSecondToChangeDirection));
            }
        }

        private void Update()
        {
            if (!turnable)
            {
                if (turnTimePass < turnTimeout)
                {
                    turnTimePass += Time.deltaTime;
                }
                else
                {
                    turnTimePass = 0.0f;
                    turnable = true;
                }
            }
        }

        private void FixedUpdate()
        {
            transform.rotation = Quaternion.Euler(
                new Vector3(0.0f, 0.0f, Mathf.LerpAngle(
                    transform.eulerAngles.z, newRotationZ, Time.deltaTime * directionChangeSpeed)));
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(colliderTagToTurnBack))
            {
                if (turnable)
                {
                    turnable = false;
                    newRotationZ = transform.eulerAngles.z + 180.0f;
                    transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, newRotationZ));
                }
            }
        }
    }
}
