using Assets.Scripts;
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

    public static void InsertAtPlaceOf(LinkedListNode<NumberNode> nodeInGutter, NumberNode node)
    {
        newlyInsertedNode = node;
        dispersing = true;

        float distTravelled = nodeInGutter.Value.pathFollower.distanceTravelled - NumberNode.RADIUS / 2f;
        newlyInsertedNode.pathFollower.SetDistanceTravelled(distTravelled);
        newlyInsertedNode.transform.position = nodeInGutter.Value.pathFollower.pathCreator.path.GetPointAtDistance(distTravelled);

        //TODO: weghalen dat dit nodig is (projectile state zorgt voor de nodecontroller)
        node.SetState(NodeState.STANDSTILL);

        nodes.AddBefore(nodeInGutter, newlyInsertedNode);
    }

    public static bool Contains(NumberNode node)
    {
        if (nodes.Contains(node))
        {
            return true;
        }
        return false;
    }

    public static void Update()
    {
        if (dispersing)
        {
            LinkedListNode<NumberNode> insertedNode = nodes.Find(newlyInsertedNode);
            LinkedListNode<NumberNode> nextNode = insertedNode.Next;
            LinkedListNode<NumberNode> prevNode = insertedNode.Previous;
            bool touching = false;

            // if node in front exists
            if (nextNode != null)
            {
                // if inserted node is touching the next node
                if (insertedNode.Value.IsTouching(nextNode.Value))
                {
                    touching = true;
                    MoveNode(MoveType.FORWARD, nextNode);
                }
            }
            // if node behind exists
            if (prevNode != null)
            {
                // if inserted node is touching the enode behind
                if (insertedNode.Value.IsTouching(prevNode.Value))
                {
                    touching = true;
                    MoveNode(MoveType.BACKWARD, prevNode);
                }
            }
            if (!touching)
            {
                newlyInsertedNode = null;
                dispersing = false;
            }
        }
        else if (nodes.Count > 0)
        {
            MoveNode(MoveType.FORWARD, nodes.First);
        }
    }

    public static void MoveNode(MoveType moveType, LinkedListNode<NumberNode> node)
    {
        LinkedListNode<NumberNode> prevNode = node.Previous;
        LinkedListNode<NumberNode> nextNode = node.Next;

        switch (moveType)
        {
            case MoveType.FORWARD:
                node.Value.pathFollower.Follow(moveType);
                if (nextNode != null)
                {
                    if (node.Value.IsTouching(nextNode.Value))
                    {
                        MoveNode(MoveType.FORWARD, nextNode);
                    }
                }
                return;
            case MoveType.BACKWARD:
                if (nextNode != null)
                {
                    if (node.Value.IsTouching(nextNode.Value))
                    {
                        if (prevNode != null)
                        {
                            if (node.Value.IsTouching(prevNode.Value))
                            {
                                MoveNode(MoveType.BACKWARD, prevNode);
                            }
                        }
                    }
                }
                node.Value.pathFollower.Follow(moveType);
                return;
        }
    }
}
