using UnityEngine;

namespace AZhelnov.Game
{
    public class ScreenEdgeCollidersGenerator : MonoBehaviour
    {
        private new Camera camera;
        private Vector2 leftBottomCorner;
        private Vector2 rightTopCorner;

        [SerializeField] private float edgeOffset;
        [SerializeField] private new string tag;


        private void Start()
        {
            camera = Camera.main;

            leftBottomCorner = camera.ViewportToWorldPoint(new Vector3(-edgeOffset, -edgeOffset, camera.nearClipPlane));
            rightTopCorner = camera.ViewportToWorldPoint(new Vector3(1.0f + edgeOffset, 1.0f + edgeOffset, camera.nearClipPlane));

            CreateEdgeCollider("Top Edge Collider",
                new Vector2(leftBottomCorner.x, rightTopCorner.y),
                new Vector2(rightTopCorner.x, rightTopCorner.y));

            CreateEdgeCollider("Bottom Edge Collider",
                new Vector2(leftBottomCorner.x, leftBottomCorner.y),
                new Vector2(rightTopCorner.x, leftBottomCorner.y));

            CreateEdgeCollider("Left Edge Collider",
                new Vector2(leftBottomCorner.x, leftBottomCorner.y),
                new Vector2(leftBottomCorner.x, rightTopCorner.y));

            CreateEdgeCollider("Right Edge Collider",
                new Vector2(rightTopCorner.x, rightTopCorner.y),
                new Vector2(rightTopCorner.x, leftBottomCorner.y));
        }

        private void CreateEdgeCollider(string name, Vector2 point0, Vector2 point1)
        {
            EdgeCollider2D edgeColliderGameObject = new GameObject(name).AddComponent<EdgeCollider2D>();
            edgeColliderGameObject.transform.parent = transform;
            edgeColliderGameObject.tag = tag;
            Vector2[] colliderPoints = edgeColliderGameObject.points;
            colliderPoints[0] = point0;
            colliderPoints[1] = point1;
            edgeColliderGameObject.points = colliderPoints;
        }
    }
}
