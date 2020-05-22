using System.Threading.Tasks;
using UnityEngine;
using Unity;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.ScoreCounter
{
    public class ParticleManager : MonoBehaviour
    {
        public ParticleSystem ps;
        public bool moduleEnabled;

        void Start()
        {
            ps = gameObject.GetComponent<ParticleSystem>();
            moduleEnabled = false;
        }

        void Update()
        {
            var emission = ps.emission;
            emission.enabled = moduleEnabled;

            if (ScoreAdd.score >= 50)
            {
                moduleEnabled = GUI.Toggle(new Rect(25, 45, 100, 30), moduleEnabled, "Enabled");
            }

            if (ScoreAdd.score >= 100)
            {
                moduleEnabled = GUI.Toggle(new Rect(25, 45, 100, 30), moduleEnabled, "Enabled");
            }

            if (ScoreAdd.score >= 200)
            {
                moduleEnabled = GUI.Toggle(new Rect(25, 45, 100, 30), moduleEnabled, "Enabled");
            }

        }
    }
}