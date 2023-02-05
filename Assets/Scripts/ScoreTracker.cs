using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public List<Score> scores = new List<Score>();
    public static string ScoreTag = "Score";

    public List<Score> GetHighScores()
    {
        return scores.OrderByDescending(x => x.depthScore).Take(5).ToList();
    }

    public Score GetRecentScore()
    {
        return scores.OrderByDescending(x => x.dateTime).Take(1).FirstOrDefault();
    }

    public void AddScore(float depth)
    {
        this.scores.Add(new Score
        {
            dateTime = DateTime.Now,
            depthScore = depth
        });
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(ScoreTag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public class Score
    {
        public float depthScore;
        public DateTime dateTime;
    }
}
