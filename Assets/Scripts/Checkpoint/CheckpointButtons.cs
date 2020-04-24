using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    class CheckpointButtons : MonoBehaviour
    {
        public void CheckButtonPressed()
        {
            TextFieldEditableManager.SetUneditable();
            DisplayResult.SetShouldDisplayTrue();

            if (CheckpointManager.CheckAnswer())
            {
                
            }
        }
    }
}
