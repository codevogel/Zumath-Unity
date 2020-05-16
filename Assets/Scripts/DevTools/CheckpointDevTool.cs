using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DevTools
{
    class CheckpointDevTool : MonoBehaviour
    {
        public bool checkpointsOn = true;
        public int checkpointsTriggered = 0;

        public bool TriggerCheckpoint()
        {
            checkpointsTriggered++;
            return true;
        }
    }
}
