using UnityEngine;
using PathCreation;
using References;
using Nodes;
using States.Node;
using System;



public class NodeSpawner : MonoBehaviour
{

    public GameObject numberBall;
    public Transform parentTransform;
    private PathCreator pathCreator;
    private Vector3 pathStart;

    public int nodesToSpawn;

    void Awake()
    {
        pathCreator = GameObject.FindGameObjectWithTag(Tags.GUTTER).GetComponent<PathCreator>();
        this.gameObject.tag = Tags.NODE_SPAWNER;
    }


    private void Start()
    {
        float distanceTravelled = NumberNode.RADIUS * nodesToSpawn - NumberNode.RADIUS;
        for (int i = nodesToSpawn; i > 0; i--)
        {
            SpawnNodeAtDistance(distanceTravelled);
            distanceTravelled -= NumberNode.RADIUS;
        }
    }

    private void SpawnNodeAtDistance(float distanceTravelled)
    {
        Vector3 pointOnPath = pathCreator.path.GetPointAtDistance(distanceTravelled);
        NumberNode newNode = Instantiate(numberBall, pointOnPath, Quaternion.identity, parentTransform).GetComponent<NumberNode>();
        newNode.Init();
        newNode.pathFollower.SetDistanceTravelled(distanceTravelled);
        newNode.SetState(NodeState.FORWARD);
        NodeManager.AddNode(newNode);
    }
}
