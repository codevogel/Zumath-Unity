using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    class TextFieldEditableManager : MonoBehaviour
    {
        static TMP_InputField inputField;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
        }
        
        public static void SetUneditable()
        {
            inputField.interactable = false;
        }


    }
}
