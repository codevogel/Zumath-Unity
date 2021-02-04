using Assets.Scripts.DevTools;
using Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    class CheckpointOnLowNodes : MonoBehaviour
    {
        public CheckpointCollider col0 = null, col1 = null, col2 = null;
        public CheckpointDevTool devTool;
        public int amountOfNodes;
        private const int
            CHECKPOINT2 = 15,
            CHECKPOINT1 = 10,
            CHECKPOINT0 = 6;

        private void Update()
        {
            amountOfNodes = NodeManager.GetNodes().Count;
            if (devTool.checkpointsOn)
            {
                if (amountOfNodes < CHECKPOINT0)
                {
                    col0.Trigger();
                }
                if (amountOfNodes < CHECKPOINT1)
                {
                    col1.Trigger();
                }
                if (amountOfNodes < CHECKPOINT2)
                {
                    col2.Trigger();
                }
            }
        }

    }
}
