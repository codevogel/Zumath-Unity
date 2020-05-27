using Controllers;
using Nodes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DevTools
{
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
            textMesh.SetText("Doel: " + NodeManager.target.ToString()
                + "\nVolgende Ball: " + NodeManager.GetNextBallValue()
                + "\nLevens: " + HealthController.GetHealth()
                );
        }
    }
}

