using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public List<Score> scores = new List<Score>();

    public List<Score> GetScores() { return scores; }

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
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Score");

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
