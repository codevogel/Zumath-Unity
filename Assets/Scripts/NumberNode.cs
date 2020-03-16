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
    private CircleCollider2D circleCollider;
    public NodeController nodeController;
    public static GameObject preFab;

    public bool inGutter;

    public int value;
    public float radius = 1f;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        preFab = Resources.Load("Prefabs/NumberNode") as GameObject;
        pathFollower = GetComponent<PathFollower>();
        circleCollider = GetComponent<CircleCollider2D>();
        nodeController = GetComponent<NodeController>();
        inGutter = false;
    }

    
    void OnTriggerEnter2D(Collider2D other)  
    {
        NumberNode otherNode = other.gameObject.GetComponent<NumberNode>();

        if (otherNode != null)
        {
            int indexThisNode = NodeManager.GetIndex(this);
            int indexOtherNode = NodeManager.GetIndex(otherNode);
            if (NodeManager.GetIndex(otherNode) != -1)
            {
                // if this node comes later in the array than the one it's touching
                if (indexThisNode > indexOtherNode)
                {
                    pathFollower.StopFollowing();
                }
            }
            else
            {
                NodeManager.InsertNodeAtDistance(indexThisNode, otherNode, this.pathFollower.distanceTravelled);
            }
        }
    }


    public NumberNode(int value)
    {
        this.value = value;
    }

    public void SetValue(int value)
    {
        this.value = value;
    }
}
