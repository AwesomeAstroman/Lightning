using AZhelnov.Variables;
using UnityEngine;

namespace AZhelnov.Game
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private IntVariable score;


        private void Start()
        {
            score.SetValue(0);
        }

        public void Add(int amount)
        {
            int newScore = score.Value + amount;
            newScore = Mathf.Clamp(newScore, 0, newScore + 1);
            score.SetValue(newScore);
        }
    }
}
