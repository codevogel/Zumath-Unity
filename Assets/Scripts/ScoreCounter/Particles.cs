using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity;

namespace Assets.Scripts.ScoreCounter
{
    public class Particles : MonoBehaviour
    {
        private ParticleSystem particles;
        public float hSliderValueR = 0.0f;
        public float hSliderValueG = 0.0f;
        public float hSliderValueB = 0.0f;
        public float hSliderValueA = 1.0f;

        void Start()
        {
            particles = GetComponent<ParticleSystem>();
            var main = particles.main;

            main.startDelay = 5.0f;
            main.startLifetime = 2.0f;
            main.startSpeed = 15;
            main.startSize = 2.0f;
            main.startColor = new Color(hSliderValueR, hSliderValueG, hSliderValueB, hSliderValueA);
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(25, 40, 100, 30), "Red");
            GUI.Label(new Rect(25, 70, 100, 30), "Green");
            GUI.Label(new Rect(25, 100, 100, 30), "Blue");
            GUI.Label(new Rect(25, 130, 100, 30), "Alpha");

            hSliderValueR = GUI.HorizontalSlider(new Rect(95, 45, 100, 30), hSliderValueR, 0.0f, 1.0f);
            hSliderValueG = GUI.HorizontalSlider(new Rect(95, 75, 100, 30), hSliderValueG, 0.0f, 1.0f);
            hSliderValueB = GUI.HorizontalSlider(new Rect(95, 105, 100, 30), hSliderValueB, 0.0f, 1.0f);
            hSliderValueA = GUI.HorizontalSlider(new Rect(95, 135, 100, 30), hSliderValueA, 0.0f, 1.0f);
        }
    }
}
