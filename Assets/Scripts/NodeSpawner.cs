using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class NodeSpawner : MonoBehaviour
{

    public GameObject numberBall;
    public Transform parentTransform;
    private PathCreator pathCreator;
    private Vector3 pathStart;
    private float timeStamp = 0;
    private float cooldown = 1f; // in seconds


    void Awake()
    {
        pathCreator = GameObject.FindGameObjectWithTag("Gutter").GetComponent<PathCreator>();
        pathStart = pathCreator.path.GetPoint(0);
    }

    void Update()
    {
        if (timeStamp < Time.time)
        {
            LayerMask nodeMask = LayerMask.GetMask("NodeLayer");
            if (! Physics2D.OverlapCircle(transform.position, NumberNode.RADIUS, nodeMask))
            {
                NumberNode newNode = Instantiate(numberBall, pathStart, Quaternion.identity, parentTransform).GetComponent<NumberNode>();
                NodeManager.AddNode(newNode);
                newNode.SetState(NodeState.FORWARD);
                newNode.Init();
                newNode.SetValue(Random.Range(0, 50));
                timeStamp = Time.time + cooldown;
            }
        }
    }

}
