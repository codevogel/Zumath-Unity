using Assets.Scripts.Dataset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    class QuestionUpdater : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;

        void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            MissionData current = CheckpointManager.GetCurrentQuestion();
            textMesh.SetText(current.question+'\n'+ (current.questionType == "Fill in the blanks" ? current.didYouKnow:"" ));
        }
    }
}
