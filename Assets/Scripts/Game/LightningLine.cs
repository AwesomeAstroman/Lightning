using UnityEngine;

namespace AZhelnov.Game
{
    [RequireComponent(typeof(LineRenderer))]
    public class LightningLine : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private float variationValue;
        private Vector3[] points;
        private readonly int pointsCount = 5;

        [SerializeField] private Transform transform1;
        [SerializeField] private Transform transform2;
        [SerializeField] private float stability = 1.0f;


        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            points = new Vector3[pointsCount];
            lineRenderer.positionCount = pointsCount;
        }

        private void Update()
        {
            points[0] = transform1.position;
            points[1] = GetCenter(points[0], points[2]);
            points[2] = GetCenter(points[0], points[4]);
            points[3] = GetCenter(points[2], points[4]);
            points[4] = transform2.position;

            float distance = Vector3.Distance(transform1.position, transform2.position) / points.Length;

            variationValue = distance / (pointsCount * stability);

            for (int i = 1; i < points.Length - 1; i++)
            {
                points[i].x += Random.Range(-variationValue, variationValue);
                points[i].y += Random.Range(-variationValue, variationValue);
                points[i].z += Random.Range(-variationValue, variationValue);
            }

            lineRenderer.SetPositions(points);
        }

        private Vector3 GetCenter(Vector3 a, Vector3 b)
        {
            return (a + b) / 2;
        }
    }
}
