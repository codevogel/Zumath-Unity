using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts;
using Controllers;
using Follower;
using MathLists;
using References;
using States.Game;
using States.Node;
using UnityEngine;

namespace Nodes
{
    public static class NodeManager
    {

        // Nodes are placed in this list like they are placed in the path.
        // The first node encountered when you go from the start of the path to the end of the path,
        // is the first node in this list.
        // The final node encountered is the final node in this list.
        private static NumberList numberList = new NumberList();

        private static NodeDestroyer nodeDestroyer;

        private static NumberNode newlyInsertedNode = null;

        public static int target = -1;
        private static int nextBallValue = -1;

        //TODO: make consts after playtesting
        public static float TRAVEL_SPEED = 0.5f;
        public static float DISPERSE_SPEED = 2.5f;
        public static float MOVEBACK_SPEED = 2f;
        public static float RESET_SPEED = 2f;

        // Amount of frames it takes for the balls to move forward again.
        private static float MOVEBACK_COUNTDOWN_LENGHT = 60;
        private static float moveBackCountdownRemaining = 60;


        public static void SetTravelSpeed(float speed)
        {
            TRAVEL_SPEED = speed;
        }

        public static void SetDisperseSpeed(float speed)
        {
            DISPERSE_SPEED = speed;
        }

        public static void SetMoveBackSpeed(float speed)
        {
            MOVEBACK_SPEED = speed;
        }

        public static void SetResetSpeed(float speed)
        {
            RESET_SPEED = speed;
        }

        public static void Init()
        {
            nodeDestroyer = GameObject.FindGameObjectWithTag(Tags.NODE_DESTROYER).GetComponent<NodeDestroyer>();
            nextBallValue = UnityEngine.Random.Range(NumberList.BOUND_LOW, NumberList.BOUND_HIGH);
            NodeManager.GetValidTarget();
        }

        // Newly added nodes are placed in the front of the list, 
        // so nodes in the list are ordered like they are on the path 
        // (from start to end)
        public static void AddNode(NumberNode node)
        {
            numberList.numberLinkedList.AddFirst(node);
        }

        public static void RemoveNode(NumberNode node)
        {
            numberList.numberLinkedList.Remove(node);
        }

        internal static void SetNextBallValue(int _nextBallValue)
        {
            nextBallValue = _nextBallValue;
        }

        public static void InsertAtPlaceOf(LinkedListNode<NumberNode> nodeInGutter, NumberNode node)
        {
            newlyInsertedNode = node;
            float distTravelled = nodeInGutter.Value.pathFollower.distanceTravelled - NumberNode.DIAMETER / 2f;
            newlyInsertedNode.pathFollower.SetDistanceTravelled(distTravelled);
            newlyInsertedNode.transform.position = nodeInGutter.Value.pathFollower.pathCreator.path.GetPointAtDistance(distTravelled);

            numberList.numberLinkedList.AddBefore(nodeInGutter, newlyInsertedNode);

            GameStateManager.SwitchToDispersing();
        }

        public static bool Contains(NumberNode node)
        {
            if (numberList.numberLinkedList.Contains(node))
            {
                return true;
            }
            return false;
        }

        public static void Update()
        {
            switch (GameStateManager.GetGameState())
            {
                case GameState.PREINSERTION:
                    nodeDestroyer.DestroyDeadNodes();
                    MoveNodesForward();
                    return;
                case GameState.SHOOTING:
                    nodeDestroyer.DestroyDeadNodes();
                    MoveNodesForward();
                    return;
                case GameState.DISPERSING:
                    DisperseNodes();
                    return;
                case GameState.MOVEBACK:
                    MoveNodesBack();
                    if (moveBackCountdownRemaining <= 0)
                    {
                        GameStateManager.SwitchToPreInsertion();
                        moveBackCountdownRemaining = MOVEBACK_COUNTDOWN_LENGHT;
                    }
                    return;
                case GameState.RESETTING:
                    MoveNodesForward();
                    if (AllNodesTouch())
                    {
                        GameStateManager.SwitchToPreInsertion();
                    }
                    return;
                case GameState.WON:
                    return;
                case GameState.GAMEOVER:
                    return;
                case GameState.PAUSED:
                    return;
                case GameState.CHECKPOINT:
                    return;
                default:
                    throw new NotImplementedException();
            }
        }

        private static bool AllNodesTouch()
        {
            bool touching = true;
            LinkedListNode<NumberNode> currentNode = numberList.numberLinkedList.First;
            while (currentNode.Next != null && touching)
            {
                touching = currentNode.Value.IsTouching(currentNode.Next.Value);
                currentNode = currentNode.Next;
            }
            return touching;
        }

        public static void MoveNodesForward()
        {
            if (numberList != null)
            {
                if (numberList.numberLinkedList.Count > 0)
                {
                    MoveNode(MoveType.FORWARD, numberList.numberLinkedList.First);
                }
            }
        }

        public static void MoveNodesBack()
        {
            if (numberList != null)
            {
                if (numberList.numberLinkedList.Count > 0)
                {
                    MoveNode(MoveType.BACKWARD, numberList.numberLinkedList.Last);
                }
            }

            moveBackCountdownRemaining -= 1;
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
                    if (prevNode != null)
                    {
                        if (node.Value.IsTouching(prevNode.Value))
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

        private static void DisperseNodes()
        {
            LinkedListNode<NumberNode> insertedNode = numberList.numberLinkedList.Find(newlyInsertedNode);
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
                OnDispersed();
            }
        }

        private static void OnDispersed()
        {
            int index = numberList.GetIndexOfNode(newlyInsertedNode);


            // TODO: onderstaande functie een array aanleveren zodat je alleen het deel
            // van de ketting bekijkt waar:
            // - De bal net is ingekomen
            // - De delen die niet door dit deel van de ketting worden aangeraakt 
            //   worden niet in acht genomen
            if (numberList.CheckForComboAt(index, target))
            {
                // TODO
                nextBallValue = UnityEngine.Random.Range(NumberList.BOUND_LOW, NumberList.BOUND_HIGH);
            }

            nodeDestroyer.DestroyDeadNodes();

            if (numberList.numberLinkedList.Count == 0)
            {
                UnityEngine.Debug.Log("GUTTER CLEARED! Game won!");
                GameStateManager.SwitchToWon();
                return;
            }

            GetValidTarget();


            newlyInsertedNode = null;
            GameStateManager.SwitchToResetting();
            ScoreAdd.ReduceScore();
        }


        /**
         * Generates a randomly generated possible sum of consecutive numbers in the array
         * @return a randomly generated possible sum of consecutive numbers in the array
         */
        public static void GetValidTarget()
        {
            // Get the values from the numberlist object
            int[] values = numberList.GetValues();

            int firstIndex = UnityEngine.Random.Range(0, values.Length - 1);
            int times = 1 + UnityEngine.Random.Range(NumberList.COMBO_SIZE_MIN, NumberList.COMBO_SIZE_MAX);

            int sum = 0;
            // Let the user that the combo starts at this index
            for (int i = 0; i < times; i++)
            {
                int value = 0;
                if (firstIndex + i < values.Length)
                {
                    value = values[firstIndex + i];
                }
                sum += value;
            }
            target = sum + nextBallValue;
        }

        public static float GetSpeed()
        {
            switch (GameStateManager.GetGameState())
            {
                case GameState.PREINSERTION:
                    return TRAVEL_SPEED;
                case GameState.SHOOTING:
                    return TRAVEL_SPEED;
                case GameState.DISPERSING:
                    return DISPERSE_SPEED;
                case GameState.MOVEBACK:
                    return MOVEBACK_SPEED;
                case GameState.RESETTING:
                    return RESET_SPEED;
            }
            throw new NotImplementedException();
        }

        public static LinkedList<NumberNode> GetNodes()
        {
            if (numberList != null)
            {
                return numberList.numberLinkedList;
            }
            return new LinkedList<NumberNode>();
        }

        public static int GetNextBallValue()
        {
            return nextBallValue;
        }

        public static float GetPathLength()
        {
            return numberList.numberArray[0].pathFollower.pathCreator.path.length;
        }

    }
}

