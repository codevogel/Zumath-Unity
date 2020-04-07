using References;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nodes
{
    public class NodeManagerHandler : MonoBehaviour
    {

        void Start()
        {
            NodeManager.Init(GameObject.FindGameObjectWithTag(Tags.NODE_DESTROYER).GetComponent<NodeDestroyer>());
        }

        // Update is called once per frame
        void Update()
        {
            NodeManager.Update();
        }
    }
}
