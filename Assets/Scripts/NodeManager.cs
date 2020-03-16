using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NodeManager
{

    public static List<NumberNode> nodeList = new List<NumberNode>();
    public static List<NumberNode> frontNodes;
    public static List<NumberNode> hindNodes;
    public static NumberNode insertedNode;

    public static bool inserting, frontDispersing, hindDispersing;


    // Returns -1 if node is not in nodeList.
    public static int GetIndex(NumberNode node)
    {
        return nodeList.IndexOf(node);
    }

    public static void InsertNode(int index, NumberNode node)
    {
        nodeList.Insert(index, node);
    }

    public static void InsertNodeAtDistance(int index, NumberNode node, float distanceTravelled)
    {
        insertedNode = node;
        node.inGutter = true;
        InsertNode(index, node);
        nodeList[index].pathFollower.SetDistanceTravelled(distanceTravelled);
        node.pathFollower.StartFollowing();
        node.gameObject.transform.position = node.pathFollower.pathCreator.path.GetPointAtDistance(distanceTravelled);
    }

    public static void AddNode(NumberNode node)
    {
        nodeList.Add(node);
    }

    public static void Update()
    {
        MoveNodes();
    }

    public static void MoveNodes()
    {
        foreach (NumberNode node in nodeList)
        {
            node.pathFollower.Follow();
        }
    }

    public static void StopNodes()
    {
        foreach (NumberNode node in nodeList)
        {
            node.pathFollower.StopFollowing();
        }
    }
}
