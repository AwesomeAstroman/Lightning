using TMPro;
using UnityEngine;

namespace AZhelnov.Game
{
    [RequireComponent(typeof(TextMeshPro))]
    public class DamageNumber : MonoBehaviour
    {
        private TextMeshPro textMeshPro;
        private Color textColor;
        private Color initialTextColor;
        private float timePass;
        private float scaleSpeed;
        private float riseSpeed;

        private static int sortingOrder;

        [SerializeField] private float visibleTime;
        [SerializeField] private float risingTime;
        [SerializeField] private float disappearSpeed;
        [SerializeField] private float maxRiseSpeed;
        [SerializeField] private float minScale;
        [SerializeField] private float maxScale;
        [SerializeField] private float maxScaleSpeed;
        [SerializeField] DamageNumbersPool damageNumbersPool;


        private void Awake()
        {
            textMeshPro = GetComponent<TextMeshPro>();
            textColor = textMeshPro.color;
            initialTextColor = textColor;
        }

        public void Setup(int damage)
        {
            timePass = 0.0f;

            textMeshPro.SetText(damage.ToString());

            textColor = initialTextColor;
            textMeshPro.color = textColor;

            transform.rotation = Quaternion.identity;
            transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(-20.0f, 20.0f)));
            
            scaleSpeed = Random.Range(1.0f, maxScaleSpeed);
            riseSpeed = Random.Range(1.0f, maxRiseSpeed);
            transform.localScale = Vector3.one * minScale;
            
            sortingOrder++;
            textMeshPro.sortingOrder = sortingOrder;
        }

        private void Update()
        {
            transform.position += new Vector3(0.0f, riseSpeed) * Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * maxScale, Time.deltaTime * scaleSpeed);

            timePass += Time.deltaTime;
            if (timePass > risingTime)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * scaleSpeed);
            }

            if (timePass > visibleTime)
            {
                textColor.a -= Time.deltaTime * disappearSpeed;
                textMeshPro.color = textColor;
                if (textColor.a < 0)
                {
                    damageNumbersPool.Return(this);
                }
            }
        }
    }
}
