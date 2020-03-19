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
<<<<<<< HEAD
        if (nodes.Contains(node))
        {
            return true;
        }
        return false;
=======
        insertedNode = node;
        node.inGutter = true;
        InsertNode(index, node);
        nodeList[index].pathFollower.SetDistanceTravelled(distanceTravelled);
        int indexFor=0;
        foreach (NumberNode numberNode in nodeList)
        {
            if (indexFor++ >= index+1)
            {
                numberNode.pathFollower.AddDistanceTravelled(-1f);
            }
        }
        node.pathFollower.StartFollowing();
        node.gameObject.transform.position = node.pathFollower.pathCreator.path.GetPointAtDistance(distanceTravelled);
      
>>>>>>> f5112203668974e8ac2ed5ebaccfe304b64f461c
    }

    public static void InsertBeforeNode(LinkedListNode<NumberNode> listNode, NumberNode nodeToInsert)
    {
        NumberNode nodeHere = listNode.Value;
        newlyInsertedNode = nodeToInsert;
        newlyInsertedNode.SetState(NodeState.FORWARD);
        float distTravelled = nodeHere.pathFollower.distanceTravelled - NumberNode.RADIUS / 2f;
        newlyInsertedNode.pathFollower.SetDistanceTravelled(distTravelled);
        newlyInsertedNode.transform.position = nodeToInsert.pathFollower.pathCreator.path.GetPointAtDistance(distTravelled);
        nodes.AddBefore(listNode, newlyInsertedNode);
        MarkNodesForDispersion();
    }

    public static void Update()
    {
        if (dispersing)
        {
            DisperseNodes();
            return;
        }

        if (nodes.Count > 0)
        {
            MoveNode(nodes.First);
        }
    }

    public static void DisperseNodes()
    {
        NumberNode nodeHere = newlyInsertedNode;
        LinkedListNode<NumberNode> listNode = nodes.Find(nodeHere);
        if (dispersingLeft)
        {
            MoveNode(listNode.Previous);
            if (nodeHere.IsTouching(listNode.Previous.Value))
            {
                dispersingLeft = false;
            }
        }
        if (dispersingRight)
        {
            MoveNode(listNode.Next);
            if (nodeHere.IsTouching(listNode.Next.Value))
            {
                dispersingRight = false;
            }
        }
        if (!dispersingLeft && !dispersingRight)
        {
            dispersing = false;
        }    
    }

    private static void MarkNodesForDispersion()
    {
        dispersing = true;
        dispersingLeft = dispersing;
        dispersingRight = dispersing;
        LinkedListNode<NumberNode> middleListNode = nodes.Find(newlyInsertedNode);
        middleListNode.Value.SetState(NodeState.STANDSTILL);

        MarkHindNodeForDispersion(middleListNode);
    }

    private static void MarkHindNodeForDispersion(LinkedListNode<NumberNode> listNode)
    {
        NumberNode node = listNode.Value;
        if (node.state != NodeState.STANDSTILL)
        {
            node.SetState(NodeState.BACKWARD);
        }

        LinkedListNode<NumberNode> hindListNode = listNode.Previous;
        if (hindListNode != null)
        {
            NumberNode hindNode = hindListNode.Value;
            if (node.IsTouching(hindNode))
            {
                MarkHindNodeForDispersion(hindListNode);
            }
        }
    }

    public static void MoveNode(LinkedListNode<NumberNode> listNode)
    {
        NumberNode node = listNode.Value;
        node.pathFollower.Follow();

        LinkedListNode<NumberNode> nextListNode = listNode.Next;
        if (nextListNode != null)
        {
            NumberNode nextNode = nextListNode.Value;
            if (nextNode != null)
            {
                if (node.IsTouching(nextNode))
                {
                    MoveNode(nextListNode);
                }
            }
        }
    }



}
