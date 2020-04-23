using Assets.Scripts.Dataset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    static class CheckpointManager

    {
        private static MissionData currentQuestion;

        public static void Start()
        {
                currentQuestion = DataHolder.GetRandomMission();
        }

        public static MissionData GetCurrentQuestion()
        {
            return currentQuestion;
        }

        
    }
}
