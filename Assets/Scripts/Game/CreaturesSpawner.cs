using UnityEngine;

namespace AZhelnov.Game
{
    public class CreaturesSpawner : MonoBehaviour
    {
        private Vector2 leftBottomCorner;
        private Vector2 rightTopCorner;

        [SerializeField] private GameObject creaturePrefab;
        [SerializeField] private float edgeOffset;
        [SerializeField] int count;


        private void Start()
        {
            Camera camera = Camera.main;

            leftBottomCorner = camera.ViewportToWorldPoint(new Vector3(-edgeOffset, -edgeOffset, camera.nearClipPlane));
            rightTopCorner = camera.ViewportToWorldPoint(new Vector3(1.0f + edgeOffset, 1.0f + edgeOffset, camera.nearClipPlane));

            for (int i = 0; i < count; i++)
            {
                GameObject newCreature = Instantiate(creaturePrefab);

                newCreature.transform.position = new Vector3(
                           Random.Range(leftBottomCorner.x, rightTopCorner.x),
                           Random.Range(leftBottomCorner.y, rightTopCorner.y),
                           transform.position.z);
            }
        }
    }
}
