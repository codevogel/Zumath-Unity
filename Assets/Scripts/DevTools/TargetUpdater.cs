using Nodes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetUpdater : MonoBehaviour
{

    private TextMeshPro textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        textMesh.SetText("Target: " + NodeManager.target.ToString() + "\nNext Ball: " + NodeManager.GetNextBallValue());
    }
}
