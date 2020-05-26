using States.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Checkpoint
{
    class CheckpointButtons : MonoBehaviour
    {
        private float timeStamp = 0;
        private float timeAfterSubmit = 3;
        private bool submitted = false;

        public void CheckButtonPressed()
        {
            TextFieldEditableManager.SetUneditable();
            DisplayResult.SetShouldDisplayTrue();
            timeStamp = Time.time + timeAfterSubmit;
            submitted = true;

            if (CheckpointManager.CheckAnswer())
            {
                ScoreAdd.AddCheckpointScore();
            }
        }

        public void Update()
        {
            if (timeStamp < Time.time && submitted)
            {
                GameStateManager.Unpause();
                SceneManager.UnloadSceneAsync(sceneName: "Checkpoint");
            }
        }
    }
}
