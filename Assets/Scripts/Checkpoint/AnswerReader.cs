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
        public string answer="";
        public int integer = 0;
        public int answerLength = 0;
        public char c;

        private void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            correct = CheckpointManager.CheckAnswer();
            answer = textMesh.text.Trim((char)8203);
            answerLength = answer.Length;
            CheckpointManager.SetAnswer(answer);
            //integer = int.Parse(answer)!=null ? int.Parse(answer) : -1 ;
        }

    }
}
