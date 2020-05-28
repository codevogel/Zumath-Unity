using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.ScoreCounter
{
    class EndScreenScore : MonoBehaviour
    {
        public TextMeshProUGUI textMesh = null;

        private void Update()
        {
            textMesh.SetText("Score: " + ScoreAdd.score.ToString());
        }
    }
}
