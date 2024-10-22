﻿using Assets.Scripts.DevTools;
using Nodes;
using States.Game;
using States.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    class CheckpointCollider : MonoBehaviour
    {
        private bool hasTriggered;
        public CheckpointDevTool devTool = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (devTool.checkpointsOn)
            {
                NumberNode otherNode = collision.gameObject.GetComponent<NumberNode>();
                if (otherNode != null)
                {
                    if (otherNode.state == NodeState.GUTTER)
                    {
                        Trigger();
                    }
                }
            }
        }

        public void Trigger()
        {
            if (hasTriggered)
            {
                return;
            }
            hasTriggered = devTool.TriggerCheckpoint();
            GameStateManager.SwitchToCheckpoint();
        }

        public bool GetHasTriggered()
        {
            return hasTriggered;
        }
    }
}
