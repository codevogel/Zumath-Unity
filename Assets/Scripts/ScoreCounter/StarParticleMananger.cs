using System.Threading.Tasks;
using UnityEngine;
using Unity;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.ScoreCounter
{
    public class StarParticleManager : MonoBehaviour
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
                moduleEnabled = true;
            }

            if (ScoreAdd.score >= 100)
            {
                moduleEnabled = true;
            }

            if (ScoreAdd.score >= 200)
            {
                moduleEnabled = true;
            }

        }
    }
}