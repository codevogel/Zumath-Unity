using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PathFollower))]
[RequireComponent(typeof(NodeController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class NumberNode : MonoBehaviour
{
    public PathFollower pathFollower;
    public CircleCollider2D circleCollider;
    public NodeController nodeController;
    public NodeState state;

    public int value;
    public const float RADIUS = 1f;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        pathFollower = GetComponent<PathFollower>();
        circleCollider = GetComponent<CircleCollider2D>();
        nodeController = GetComponent<NodeController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        NumberNode otherNode = collision.GetComponent<NumberNode>();
        if (otherNode != null)
        {
<<<<<<< HEAD
            if (! NodeManager.Contains(otherNode))
=======
            int indexThisNode = NodeManager.GetIndex(this);
            int indexOtherNode = NodeManager.GetIndex(otherNode);
            if (NodeManager.GetIndex(otherNode) != -1)
            {
                // if this node comes later in the array than the one it's touching
                if (indexThisNode > indexOtherNode)
                {
                    //pathFollower.StopFollowing();
                }
            }
            else
>>>>>>> f5112203668974e8ac2ed5ebaccfe304b64f461c
            {
                NodeManager.InsertBeforeNode(NodeManager.GetNodes().Find(this), otherNode);
            }
        }
    }

    public bool IsTouching(NumberNode otherNode)
    {
        if (otherNode != null)
        {
            if (circleCollider.IsTouching(otherNode.circleCollider))
            {
                return true;
            }
        }
        return false;
    }

    public void SetValue(int value)
    {
        this.value = value;
    }
    public void SetState(NodeState state)
    {
        this.state = state;
    }
}
