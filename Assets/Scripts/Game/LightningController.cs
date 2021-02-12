using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace AZhelnov.Game
{
    public class LightningController : MonoBehaviour
    {
        private new Camera camera;
        private float maxDistance;
        private ParticleSystem.EmissionModule emission1;
        private ParticleSystem.EmissionModule emission2;

        [SerializeField] private GameObject point1;
        [SerializeField] private new Collider2D collider;
        [SerializeField] private ParticleSystem particleSystem1;
        [SerializeField] private GameObject point2;
        [SerializeField] private ParticleSystem particleSystem2;

        [SerializeField] private int singlePointEmissionRate;
        [SerializeField] private int multiPointEmissionRate;

        [SerializeField] private int minDamage;
        [SerializeField] private int maxDamage;

        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float minLineWidth;
        [SerializeField] private float maxLineWidth;

        public static event Action<GameObject, int> OnDamageInflicted = delegate { };


        private void Awake()
        {
            EnhancedTouchSupport.Enable();
        }

        private void Start()
        {
            camera = Camera.main;
            emission1 = particleSystem1.emission;
            emission2 = particleSystem2.emission;

            maxDistance = (camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, camera.nearClipPlane))
                - camera.ViewportToWorldPoint(new Vector3(1.0f, 1.0f, camera.nearClipPlane))).magnitude;
        }

        private void FixedUpdate()
        {
            switch (Touch.activeFingers.Count)
            {
                case 0:
                    {
                        point1.SetActive(false);
                        point2.SetActive(false);
                        lineRenderer.enabled = false;
                    }
                    break;

                case 1:
                    {
                        SetLightning(0, point1, emission1, singlePointEmissionRate);
                        point2.SetActive(false);
                        lineRenderer.enabled = false;
                        collider.enabled = true;
                    }
                    break;

                case 2:
                    {
                        SetLightning(0, point1, emission1, multiPointEmissionRate);
                        SetLightning(1, point2, emission2, multiPointEmissionRate);
                        lineRenderer.enabled = true;
                        collider.enabled = false;

                        RaycastHit2D[] hits;
                        hits = Physics2D.RaycastAll(
                            point1.transform.position,
                            point2.transform.position - point1.transform.position,
                            (point1.transform.position - point2.transform.position).magnitude);

                        int damage = Mathf.RoundToInt((maxDamage - minDamage) * (maxDistance - (point1.transform.position - point2.transform.position).magnitude) / maxDistance);

                        lineRenderer.widthMultiplier = (maxLineWidth - minLineWidth) * (maxDistance - (point1.transform.position - point2.transform.position).magnitude) / maxDistance;

                        foreach (var hit in hits)
                        {
                            OnDamageInflicted?.Invoke(hit.transform.gameObject, damage);
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void SetLightning(int fingerIndex, GameObject lightningObject, ParticleSystem.EmissionModule emission, int emissionRate)
        {
            Touch activeTouch = Touch.activeFingers[fingerIndex].currentTouch;
            lightningObject.SetActive(true);
            Vector3 worldPosition = camera.ScreenToWorldPoint(activeTouch.screenPosition);
            worldPosition.z = 0.0f;
            lightningObject.transform.position = worldPosition;
            emission.rateOverTime = emissionRate;
        }
    }
}
