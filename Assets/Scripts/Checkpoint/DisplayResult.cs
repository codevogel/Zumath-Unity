using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    class DisplayResult : MonoBehaviour
    {
        TextMeshProUGUI textMesh;
        static bool shouldDisplay;
        string right, wrong;

        private void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            shouldDisplay = false;
            right = "Het antwoord is goed.";
            wrong = "Het antwoord is fout. Het goede antwoord was: " 
                + CheckpointManager.GetCurrentQuestion().answers[0]+".";
        }

        private void Update()
        {
            if (shouldDisplay)
            {
                textMesh.SetText(CheckpointManager.CheckAnswer() ? right : wrong);
                textMesh.color= CheckpointManager.CheckAnswer() ? Color.green : Color.red;
            }
        }

        static public void SetShouldDisplayTrue()
        {
            shouldDisplay = true;
        }



    }
}
