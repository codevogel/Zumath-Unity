using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NodeManager
{

    // Nodes are placed in this list like they are placed in the path.
    // The first node encountered when you go from the start of the path to the end of the path,
    // is the first node in this list.
    // The final node encountered is the final node in this list.
    private static LinkedList<NumberNode> nodes = new LinkedList<NumberNode>();

    private static NumberNode newlyInsertedNode = null;

    private static bool dispersing, dispersingLeft, dispersingRight;

    public static LinkedList<NumberNode> GetNodes()
    {
        return nodes;
    }

    // Newly added nodes are placed in the front of the list, 
    // so nodes in the list are ordered like they are on the path 
    // (from start to end)
    public static void AddNode(NumberNode node)
    {
        nodes.AddFirst(node);
    }

    public static bool Contains(NumberNode node)
    {
        if (nodes.Contains(node))
        {
            return true;
        }
        return false;
    }

    public static void InsertAfterNode(LinkedListNode<NumberNode> listNode, NumberNode nodeToInsert)
    {
        NumberNode nodeHere = listNode.Value;
        newlyInsertedNode = nodeToInsert;
        newlyInsertedNode.SetState(NodeState.FORWARD);
        float distTravelled = nodeHere.pathFollower.distanceTravelled + NumberNode.RADIUS / 2f;
        newlyInsertedNode.pathFollower.SetDistanceTravelled(distTravelled);
        newlyInsertedNode.transform.position = nodeToInsert.pathFollower.pathCreator.path.GetPointAtDistance(distTravelled);
        nodes.AddAfter(listNode, newlyInsertedNode);
    }

    public static void Update()
    {
        if (nodes.Count > 0)
        {
            MoveNode(nodes.First);
        }
    }

    public static void MoveNode(LinkedListNode<NumberNode> listNode)
    {
        NumberNode node = listNode.Value;
        node.pathFollower.Follow();

        LinkedListNode<NumberNode> nextListNode;
        switch (node.state)
        {
            case NodeState.FORWARD:
                nextListNode = listNode.Next;
                if (nextListNode != null)
                {
                    NumberNode nextNode = nextListNode.Value;
                    if (node.IsTouching(nextNode))
                    {
                        MoveNode(nextListNode);
                    }
                }
                return;
            case NodeState.BACKWARD:
                LinkedListNode<NumberNode> prevListNode = listNode.Next;
                if (prevListNode != null)
                {
                    NumberNode prevNode = prevListNode.Value;

                    // Move next node backwards only if we're still touching the previous node.
                    if (node.IsTouching(prevNode))
                    {
                        nextListNode = listNode.Previous;
                        if (nextListNode != null)
                        {
                            NumberNode nextNode = nextListNode.Value;
                            if (node.IsTouching(nextNode))
                            {
                                MoveNode(nextListNode);
                            }
                        }
                    }
                }
                return;

        }

    }



}
