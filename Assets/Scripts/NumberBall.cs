using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public class NumberBall : MonoBehaviour
{
    private int index;
    private int value;
    public PathFollower pathFollower;
    private CircleCollider2D circleCollider2D;

    public NumberBall(int value)
    {
        this.value = value;
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    // Start is called before the first frame update
    void Start()
    {
        pathFollower = GetComponent<PathFollower>();
        circleCollider2D = GetComponentInChildren<CircleCollider2D>();
        GetComponentInChildren<TextMesh>().text = FormatValue();
    }

    private void OnCollisionEnter2D(Collision2D otherCollision)
    {
        NumberBall otherBall = otherCollision.gameObject.GetComponent<NumberBall>();
        if (otherBall != null)
        {
            if (this.index > otherBall.index)
            {
                pathFollower.Reverse();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D otherCollision)
    {
        NumberBall otherBall = otherCollision.gameObject.GetComponent<NumberBall>();
        if (otherBall != null)
        {
            if (this.index > otherBall.index)
            {
                pathFollower.Reverse();
                pathFollower.StopFollowing();
            }
        }
    }

    private string FormatValue()
    {
        if (value < 10)
        {
            return " " + value;
        }
        return value.ToString();
    }
}
