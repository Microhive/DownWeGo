using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using static UnityEditor.Progress;

namespace Assets.Scripts
{
    public class DisplayScores : MonoBehaviour
    {
        public TextMeshProUGUI lastScore;
        public TextMeshProUGUI lastTimer;

        public TextMeshProUGUI[] score;
        public TextMeshProUGUI[] timer;

        public void FixedUpdate()
        {
            GameObject objs = GameObject.FindGameObjectWithTag(ScoreTracker.ScoreTag);

            for (int i = 0; i < score.Length; i++)
            {
                score[i].text = "";
                timer[i].text = "";
            }

            var scores = objs.GetComponent<ScoreTracker>().GetHighScores();

            var index = 0;
            foreach (var item in scores)
            {
                score[index].text = string.Format("{0:0.0}", item.depthScore) + "cm";
                timer[index].text = item.dateTime.ToString("yyyy-MM-dd");
                index++;
            }

            var recentScore = objs.GetComponent<ScoreTracker>().GetRecentScore();

            if (recentScore != null)
            {
                lastScore.text = string.Format("{0:0.0}", recentScore.depthScore) + "cm";
                lastTimer.text = recentScore.dateTime.ToString("yyyy-MM-dd");
            }
        }
    }
}
