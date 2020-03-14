using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;
using Assets.Scripts;

public class NumberNode : MonoBehaviour
{
    private int value;
    public bool moving;
    public float radius = 1f;
    public PathFollower pathFollower;
    public CircleCollider2D collider;
    private NumberNode nodeTouchedInFront, nodeTouchedBehind;

    public NumberNode(int value)
    {
        this.value = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        // Initialize components
        pathFollower = GetComponent<PathFollower>();
        collider = GetComponentInChildren<CircleCollider2D>();
        GetComponentInChildren<RectTransform>().transform.localScale = new Vector3(radius, radius, 1);

        // Set scaling for text renderer
        Transform textRendererTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
        textRendererTransform.transform.localPosition = new Vector3(-0.36f * radius, 0.314f * radius, 1);
        textRendererTransform.transform.localScale = new Vector3(radius / 10f, radius / 10f, 1);

        // Format this numbernodes value into a string to display
        GetComponentInChildren<TextMesh>().text = FormatValue();
    }

    // Moves this node forwards.
    public void Move()
    {
        if (moving)
        {
            pathFollower.GoForwards();
            pathFollower.Follow();
            return;
        }
    }

    // Tries to go backward every time it's called until it's no longer touching otherNode.
    public void ReverseOutOfNode(NumberNode otherNode)
    {
        if (!IsTouching(otherNode))
        {
            moving = false;
        }
        if (moving)
        {
            nodeTouchedInFront = otherNode;
            pathFollower.GoBackwards();
            pathFollower.Follow();
        }
    }

    // Tries to go forward every time it's called until it's no longer touching otherNode.
    public void GoForwardsOutOfNode(NumberNode otherNode)
    {
        if (!IsTouching(otherNode))
        {
            moving = false;
        }
        if (moving)
        {
            nodeTouchedBehind = otherNode;
            pathFollower.GoForwards();
            pathFollower.Follow();
        }
    }

    // Returns true if otherNode is touching this node;
    public bool IsTouching(NumberNode otherNode)
    {
        if (collider.IsTouching(otherNode.collider))
        {
            return true;
        }
        return false;
    }

    // Returns true if otherNode was touched by this node.
    public bool WasTouching(NumberNode otherNode)
    {
        if (nodeTouchedInFront == otherNode)
        {
            return true;
        }
        return false;
    }

    // Start moving the ball again after collision detection.
    public void StartMoving()
    {
        moving = true;
        // Clear touched objects out of memory
        nodeTouchedInFront = null;
        nodeTouchedBehind = null;
    }

    // Formats the integer value into a displayable number string
    private string FormatValue()
    {
        if (value < 10)
        {
            return " " + value;
        }
        return value.ToString();
    }
}
