using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{

    public List<NumberBall> numberBalls;

    public Gutter()
    {
        numberBalls = new List<NumberBall>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ContinueMovement();
        }
    }

    private void ContinueMovement()
    {
        foreach (NumberBall ball in numberBalls)
        {
            ball.pathFollower.StartFollowing();
        }
    }

    public bool InsertBall(int index, NumberBall ball)
    {
        if (ball != null)
        {
            ball.SetIndex(index);
            numberBalls.Insert(index, ball);
            return true;
        }
        return false;
    }
}
