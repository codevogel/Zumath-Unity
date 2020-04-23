using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    class AnswerReader : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;

        public bool correct;

        private void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            correct = CheckpointManager.CheckAnswer();
            CheckpointManager.SetAnswer(textMesh.GetParsedText());
        }

    }
}
