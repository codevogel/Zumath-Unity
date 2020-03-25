using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GutterContents : MonoBehaviour
{

    public LinkedList<NumberNode> nodes = new LinkedList<NumberNode>();
    public List<NumberNode> nodeList = new List<NumberNode>();

    void Start()
    {
        RefreshGutter();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStateManager.IsPaused())
        {
            RefreshGutter();
        }
    }

    void RefreshGutter()
    {
        nodes = NodeManager.GetNodes();
        nodeList = nodes.ToList<NumberNode>();
    }
}
