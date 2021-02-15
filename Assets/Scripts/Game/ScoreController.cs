﻿using AZhelnov.Variables;
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
            score.ModifyValue(amount);
            score.SetValue(Mathf.Clamp(score.Value, 0, score.Value + 1));
        }
    }
}
