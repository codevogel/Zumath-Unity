using System.Collections;
using System.Collections.Generic;
using States.Game;
using UnityEngine;
using TMPro;
using Nodes;


public static class ScoreAdd
{
    public static int score;
    static float distanceTravelled;
    static float pathLength;


    public static void Start()
    {
        score = 0;

        pathLength = NodeManager.GetPathLength();
    }

    public static void SetFurthestDistanceTravelled(float distanceTravelled)
    {
        if (distanceTravelled > ScoreAdd.distanceTravelled)
        {
            ScoreAdd.distanceTravelled = distanceTravelled;
        }
    }

    static public void AddScore(int newScore)
    {
        score += newScore;
    }

    static public void AddEndLevelScore()
    {
        float t = 1000 - (distanceTravelled / pathLength * 1000);
        AddScore((int)t);
    }

    static public void AddCheckpointScore()
    {
        float c = 1000;
        AddScore((int)c);
    }
}


