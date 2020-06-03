using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Following;
using States.Node;
using Controllers;
using MathLists;
using References;
using Motors;
using Assets.Scripts;
using States.Game;

namespace Nodes
{
    [RequireComponent(typeof(PathFollower))]
    [RequireComponent(typeof(NodeMotor))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    // Defines a numbernode
    public class NumberNode : MonoBehaviour
    {
        private CircleCollider2D circleCollider;
        private TextMeshPro textMeshPro;

        public PathFollower pathFollower;
        public NodeMotor nodeMotor;
        public NodeState state;
        public int value;
        public bool alive;

        public const float DIAMETER = 0.75f;


        void Awake()
        {
            Init();
        }

        public void Init()
        {
            alive = true;
            value = Random.Range(NumberList.BOUND_LOW, NumberList.BOUND_HIGH);
            SetValue(value);
            pathFollower = GetComponent<PathFollower>();
            circleCollider = GetComponent<CircleCollider2D>();
            nodeMotor = GetComponent<NodeMotor>();
            textMeshPro = GetComponentInChildren<TextMeshPro>();
            this.gameObject.layer = LayerMask.NameToLayer(LayerNames.NODE_LAYER);
        }

        // Change the sprite shade depending on the value
        public void SetColorToValue()
        {
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            switch (value)
            {
                case 1:
                    spriteRenderer.color = Color.white;
                    return;
                case 2:
                    spriteRenderer.color = Color.blue;
                    return;
                case 3:
                    spriteRenderer.color = Color.green;
                    return;
                case 4:
                    spriteRenderer.color = Color.yellow;
                    return;
                case 5:
                    spriteRenderer.color = Color.cyan;
                    return;
                case 6:
                    spriteRenderer.color = Color.magenta;
                    return;
                case 7:
                    spriteRenderer.color = Color.red;
                    return;
                case 8:
                    spriteRenderer.color = Color.gray;
                    return;
                case 9:
                    spriteRenderer.color = Color.black;
                    return;
            }

        }

        // Handle collision
        public void OnTriggerEnter2D(Collider2D collision)
        {
            NumberNode otherNode = collision.GetComponent<NumberNode>();

            if (otherNode != null)
            {
                // Prevent collision with Preview nodes
                if (otherNode.state == NodeState.PREVIEW || this.state == NodeState.PREVIEW)
                {
                    return;
                }
                // Prevent collision detection with other nodes in gutter
                if (NodeManager.Contains(otherNode))
                {
                    return;
                }
                // Collision happened between this node and the other node,
                // where this node is in the gutter and the other node is in a projectile state 
                // So place said the other node into the gutter at the place of this node.
                // Also disable the node motor since it will no longer be used in the gutter.
                otherNode.nodeMotor.enabled = false;
                NodeManager.InsertAtPlaceOf(NodeManager.GetNodes().Find(this), otherNode);
                GameStateManager.SwitchToDispersing();
            }
        }

        // Marks this node as dead
        public void Kill()
        {
            alive = false;
        }

        // Checks whether this bool is touching another node.
        public bool IsTouching(NumberNode otherNode)
        {
            if (otherNode != null)
            {
                if (circleCollider.IsTouching(otherNode.circleCollider))
                {
                    return true;
                }
            }
            return false;
        }

        // Sets the... value
        public void SetValue(int value)
        {
            this.value = value;
            if (textMeshPro != null)
            {
                textMeshPro.SetText(value.ToString());
            }
        }

        // Sets the... state
        public void SetState(NodeState state)
        {
            this.state = state;
        }
    }
}

