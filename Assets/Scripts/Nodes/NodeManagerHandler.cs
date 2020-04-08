using References;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nodes
{
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
