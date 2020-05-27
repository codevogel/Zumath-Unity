using Nodes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevTools 
{
    public class NextBallDisplayer : MonoBehaviour
    {

        public GameObject numberNodePrefab;
        public GameObject numberNode;

        // Start is called before the first frame update
        void Start()
        {
            numberNode = Instantiate(numberNodePrefab, this.transform);
            numberNode.GetComponent<NumberNode>().SetState(States.Node.NodeState.PREVIEW);
        }

        // Update is called once per frame
        void Update()
        {
            numberNode.GetComponent<NumberNode>().SetValue(NodeManager.GetNextBallValue());
            numberNode.GetComponent<NumberNode>().SetColorToValue();
        }
    }
}

