using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.ScoreCounter
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    class ScoreManager : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;

        void Start()
        {
            ScoreAdd.Start();
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            textMesh.text = "Score: " + ScoreAdd.score.ToString();
        }
    }
}
