using References;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nodes
{
    // This script is attached to an empty gameobject to ensure that the static NodeManager can make use of certain MonoBehaviour functionalities.
    public class NodeManagerHandler : MonoBehaviour
    {
        void Awake()
        {
            NodeManager.Init();
        }

        // Update is called once per frame
        void Update()
        {
            NodeManager.Update();
        }
    }
}
