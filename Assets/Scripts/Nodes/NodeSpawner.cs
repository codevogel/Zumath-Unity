using UnityEngine;
using PathCreation;
using References;
using Nodes;
using States.Node;
using System;
using States.Game;

// This script is responsible for spawning the nodes that should fill the gutter at the start of the game and should only be used once
public class NodeSpawner : MonoBehaviour
{
    public GameObject numberBall;
    public Transform parentTransform;
    private PathCreator pathCreator;

    public const int NODES_TO_SPAWN = 25;
    public const int INIT_DISTANCE = 20;

    void Awake()
    {
        pathCreator = GameObject.FindGameObjectWithTag(Tags.GUTTER).GetComponent<PathCreator>();
        SpawnNodes();
    }

    // Spawn the nodes
    // Called when a new game starts
    public void SpawnNodes()
    {
        // .75f is scale of object
        float distanceTravelled = NumberNode.DIAMETER * 0.75f * NODES_TO_SPAWN - NumberNode.DIAMETER + INIT_DISTANCE;
        for (int i = NODES_TO_SPAWN; i > 0; i--)
        {
            SpawnNodeAtDistance(distanceTravelled);
            distanceTravelled -= NumberNode.DIAMETER;
        }
    }

    private void SpawnNodeAtDistance(float distanceTravelled)
    {
        // Get the coordinates of the point at the distance travelled
        Vector3 pointOnPath = pathCreator.path.GetPointAtDistance(distanceTravelled);
        // Spawn a new node under the parent transform at those coordinates
        NumberNode newNode = Instantiate(numberBall, pointOnPath, Quaternion.identity, parentTransform).GetComponent<NumberNode>();
        newNode.Init();
        // Set the pathfollower's distance travelled acoordingly
        newNode.pathFollower.SetDistanceTravelled(distanceTravelled);
        // Set the node state to be in the gutter
        newNode.SetState(NodeState.GUTTER);
        // Disable the node's motor as the pathfollower takes care of movement in the gutter
        newNode.nodeMotor.enabled = false;
        newNode.SetColorToValue();
        // Add the node to the node manager
        NodeManager.AddNode(newNode);
    }
}
