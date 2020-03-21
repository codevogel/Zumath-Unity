using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManagerHandler : MonoBehaviour
{

    void Start()
    {
        NodeManager.Init(GameObject.FindGameObjectWithTag("NodeDestroyer").GetComponent<NodeDestroyer>());
    }

    // Update is called once per frame
    void Update()
    {
        NodeManager.Update();
    }
}
