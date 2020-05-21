using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine.UI;
using UnityEngine;
using UnityEditorInternal;

namespace Assets.Scripts.ScoreCounter
{
    class StarParticles : MonoBehaviour
    {
        [SerializeField] public ParticleSystem ps;
        public bool moduleEnabled;
        public bool isEmitting = false;

        void Start()
        {
            ps = GetComponent<ParticleSystem>();
        }

        void Update()
        {
            var emission = ps.emission;
            emission.enabled = moduleEnabled;
        }

        void EnableEmitting()
        {
            if (ScoreAdd.score >= 50)
            {
                moduleEnabled = true;
                isEmitting = true;
                ps.Emit(30);
                DoEmit();
            }

            if (ScoreAdd.score >= 100)
            {
                moduleEnabled = true;
                isEmitting = true;
                DoEmit();
            }

            if (ScoreAdd.score >= 150)
            {
                moduleEnabled = true;
                isEmitting = true;
                DoEmit();
            }
        }

        void OnGUI()
        {
            moduleEnabled = GUI.Toggle(new Rect(25, 45, 100, 30), moduleEnabled, "Enabled");
        }

        void DoEmit()
        {
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = Color.yellow;
            emitParams.startSize = 0.2f;
            ps.Emit(emitParams, 30);
            ps.Play();
        }
    }
}
