using Nodes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevTools 
{
    // Used to display the next ball that's going to be inserted
    public class NextBallDisplayer : MonoBehaviour
    {

        public GameObject numberNodePrefab;
        public GameObject nextBall;

        // Start is called before the first frame update
        void Start()
        {
            nextBall = Instantiate(numberNodePrefab, this.transform);
            nextBall.GetComponent<NumberNode>().SetState(States.Node.NodeState.PREVIEW);
            nextBall.gameObject.transform.rotation = Quaternion.identity;
        }

        // Update is called once per frame
        void Update()
        {
            nextBall.gameObject.transform.rotation = Quaternion.identity;
            nextBall.GetComponent<NumberNode>().SetValue(NodeManager.GetNextBallValue());
            nextBall.GetComponent<NumberNode>().SetColorToValue();
        }
    }
}

