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

    void Awake()
    {
        pathCreator = GameObject.FindGameObjectWithTag("Gutter").GetComponent<PathCreator>();
        pathStart = pathCreator.path.GetPoint(0);
    }

    void Update()
    {
        // Spawn a ball every 2 frames.
        if (Time.frameCount % 120 == 0)
        {
            NumberNode newNode = Instantiate(numberBall, pathStart, Quaternion.identity, parentTransform).GetComponent<NumberNode>();
            NodeManager.AddNode(newNode);
            newNode.Init();
            newNode.inGutter = true;
            newNode.SetValue(Random.Range(0, 50));
            newNode.pathFollower.FollowForwards();
            newNode.pathFollower.StartFollowing();
        }
    }

}
