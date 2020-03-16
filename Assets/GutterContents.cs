using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterContents : MonoBehaviour
{

    public List<NumberNode> nodes;
    public List<NumberNode> frontNodes;
    public List<NumberNode> hindNodes;

    void Start()
    {
        RefreshGutter();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshGutter();
    }

    void RefreshGutter()
    {
        nodes = NodeManager.nodeList;
        frontNodes = NodeManager.frontNodes;
        hindNodes = NodeManager.hindNodes;
    }
}
