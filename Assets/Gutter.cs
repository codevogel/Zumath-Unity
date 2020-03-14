using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{

    public List<NumberNode> nodesInGutter;

    // Start is called before the first frame update
    void Start()
    {
        RefreshNodes();
    }

    public void FixedUpdate()
    {
        RefreshNodes();
        NodeManager.MoveNodes();
    }

    private void RefreshNodes()
    {
        nodesInGutter = NodeManager.GetNodes();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NodeManager.StartMovingNodes();
        }
    }
}
