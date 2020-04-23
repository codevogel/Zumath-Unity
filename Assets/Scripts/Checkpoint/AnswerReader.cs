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

        public string answer;



        private void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            answer = textMesh.GetParsedText();
        }

    }
}
